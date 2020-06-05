using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SportDash.Data;
using SportDash.Hubs;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class PlaygroundController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserRepository _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IPlaygroundReservationRepository _reservationRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IPlaygroundPriceRepository _playgroundPriceRepository;
        private readonly IConnectedUsersRepository _connectedUsersRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public PlaygroundController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    IAuthorizationService authorizationService,
                                    IUserRepository userRepository,
                                    IImageRepository imageRepository,
                                    IPlaygroundReservationRepository reservationRepository,
                                    IReviewRepository reviewRepository,
                                    IMessageRepository messageRepository,
                                    IPlaygroundPriceRepository playgroundPriceRepository,
                                    IConnectedUsersRepository connectedUsersRepository,
                                    IHubContext<ChatHub> hubContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _reservationRepository = reservationRepository;
            _reviewRepository = reviewRepository;
            _messageRepository = messageRepository;
            _playgroundPriceRepository = playgroundPriceRepository;
            _connectedUsersRepository = connectedUsersRepository;
            _hubContext = hubContext;
        }

        //[HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            dataModel.ControllerName = "Playground";
            dataModel.isCurrentUser = false;

            if (User.IsInRole("PlaygroundManager") && (id == null || user.Id == id))
            {
                dataModel.CurrentUser = user;
                dataModel.isCurrentUser = true;
            }
            else if (_signInManager.IsSignedIn(User) && id != null)
            {
                dataModel.CurrentUser = user;
                dataModel.Entity = await _userManager.FindByIdAsync(id);
            }
            else if (id != null)
            {
                dataModel.Entity = await _userManager.FindByIdAsync(id);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(dataModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public IActionResult EditEntityName(string newName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            //var newName = "Idiot";
            _userRepository.EditFullName(userId, newName);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Message(string id)
        {
            var playgroundReciver = await _userManager.FindByIdAsync(id);
            if (playgroundReciver == null) return NotFound();

            var currentUser = await _userManager.GetUserAsync(User);
            var allMessages = _messageRepository.GetMessages(currentUser.Id, playgroundReciver.Id).OrderByDescending(m => m.MessageDate);

            MessagingViewModel messagingViewModel = new MessagingViewModel
            {
                CurrentPage = playgroundReciver.FullName,
                EntityId = id,
                Messages = allMessages
            };

            return View(messagingViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> AddNewImage(IFormFile file)
        {
            var image = new Image();
            image.ImageFile = file;
            var userId = _userManager.GetUserId(HttpContext.User);
            await _imageRepository.CreateImage(image, userId);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageRepository.DeleteImage(id);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var playgroundId = _userManager.GetUserId(User);
            var acceptedReservation = _reservationRepository.GetRequests(playgroundId).FirstOrDefault(r => r.Id == id);
            await NotifyUser(playgroundId, acceptedReservation, $"Sorry, your reservation request has been rejected  for {acceptedReservation.Date} day from {acceptedReservation.StartTime} to {acceptedReservation.EndTime}");
            _reservationRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task NotifyUser(string playgroundId, PlaygroundReservation acceptedReservation, string msg)
        {
            // creating a new message and saving it to the database
            var sentMsg = _messageRepository.PostMessage(new Message
            {
                Body = msg,
                MessageDate = DateTime.Now,
                ReceiverId = acceptedReservation.UserId,
                SenderId = playgroundId
            });

            var playground = await _userManager.GetUserAsync(User);

            // getting the user that made the reservation request
            // then we change the status of his mesages to true
            ApplicationUser receiver = _userRepository.GetUserById(acceptedReservation.UserId);
            _userRepository.ChangeMsgsStatus(receiver, true);

            // getting the conId of the reserver user and see if he is online
            // if so, i will send a the message in real time
            ConnectedUser receiverConnectedUser = _connectedUsersRepository.GetConnectionIdOfUser(acceptedReservation.UserId);
            
            if (receiverConnectedUser != null)
            {
                await _hubContext.Clients.Client(receiverConnectedUser.ConnectionId).SendAsync("recMsg", sentMsg.Body, playgroundId, playground.UserName, sentMsg.MessageDate.ToString("dd/MM/yyyy hh:mm:ss tt"));
            }
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> AcceptReservation(int id)
        {
            _reservationRepository.AcceptReservation(id);
            var playgroundId = _userManager.GetUserId(User);
            var acceptedReservation = _reservationRepository.GetAll(playgroundId).FirstOrDefault(r => r.Id == id);

            // notifing the accepted request user whether their request to reserve is accepted or not
            await NotifyUser(playgroundId, acceptedReservation, $"Your reservation request has been approved for {acceptedReservation.Date} day from {acceptedReservation.StartTime} to {acceptedReservation.EndTime}");

            //check for another requests and delete the requests with the same time of another reservation            
            var remainingRequests = _reservationRepository.GetRequests(playgroundId);
            foreach(var r in remainingRequests)
            {
                if (_reservationRepository.IsValid(r) == false)
                {
                    // notifing the other users that thier requests have been rejected
                    await NotifyUser(playgroundId, r, $"Sorry, your reservation request has been rejected  for {r.Date} day from {r.StartTime} to {r.EndTime}" );
                    _reservationRepository.Delete(r.Id);
                }                    
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddReservation(PlaygroundReservation reservation)
        {
            bool res = true;
            if (User.IsInRole("PlaygroundManager"))
            {
                reservation.Status = "Accepted";
                reservation.PlaygroundId = _userManager.GetUserId(HttpContext.User);
            }
            else
            {
                reservation.Status = "Waiting";
                reservation.UserId = _userManager.GetUserId(HttpContext.User);
                reservation.Name = _reservationRepository.GetUsername(reservation.UserId);
            }
            if (ModelState.IsValid)
            {
                res = _reservationRepository.Add(reservation);
            }
            if (res)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(new BadRequestObjectResult("There is another reservation at the same time, Please change your reservation time."));
        }

        [HttpPost]
        public IActionResult SearchByDate(DateTime date , string playgroundId)
        {
            string userId = null;
            if (User.IsInRole("PlaygroundManager"))
            {
                userId = _userManager.GetUserId(HttpContext.User);
                if (userId != playgroundId)
                    userId = playgroundId;
            }
            else
            {
                userId = playgroundId;
            }
            var data = _reservationRepository.GetReservationsByDay(userId, date.Day, date.Month, date.Year);

            if (data != null)
                return Ok(new JsonResult(data));
            else
                return NotFound(new NotFoundObjectResult("There is no reservations"));
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult PutPlaygroundPrice(int Id, PlaygroundPrice NewPlaygroundPrice)
        {
            //bool result = playgroundPriceRepository.UpdatePlaygroundPrice(oldAndNewplaygroundPrice.NewPlaygroundPrice, oldAndNewplaygroundPrice.OldPlaygroundPrice);
            bool result = _playgroundPriceRepository.UpdatePlaygroundPrice(Id, NewPlaygroundPrice);
            if (result == true)
                return Ok();
            return BadRequest();

        }

        [HttpPost]
        public IActionResult AddPlaygroundPrice(int Id, PlaygroundPrice NewPlaygroundPrice)
        {
            //bool result = playgroundPriceRepository.UpdatePlaygroundPrice(oldAndNewplaygroundPrice.NewPlaygroundPrice, oldAndNewplaygroundPrice.OldPlaygroundPrice);
            int result = _playgroundPriceRepository.AddPlaygroundPrice(NewPlaygroundPrice);
            return Ok(new { id = result });
        }

        [HttpPost]
        public IActionResult DeletePlaygroundPrice(int Id)
        {
            bool result = _playgroundPriceRepository.DeletePlaygroundPrice(Id);
            if (result == true)
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddReview(Review R)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //R.ReviewerId = _userManager.GetUserId(HttpContext.User);
            //R.TargetId = "b6bf071e-32fe-4b3f-b8ec-57ddc6737e8";
             var review = _reviewRepository.PostReview(R);
            return Ok(new OkObjectResult(review));
        }

        [HttpPost]
        public IActionResult DeleteReview(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _reviewRepository.DeleteReview(id);
            return Ok();
        }
    }
}