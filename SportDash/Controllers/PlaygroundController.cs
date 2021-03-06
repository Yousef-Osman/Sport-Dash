﻿using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<IActionResult> Index(string id)
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            dataModel.ControllerName = "Playground";
            dataModel.IsAdmin = false;

            if (User.IsInRole("Playground") && (id == null || user.Id == id))
            {
                dataModel.CurrentUser = user;
                dataModel.IsAdmin = true;
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

        public IActionResult LoadReservations(string id)
        {
            var dataModel = new DataViewModel();
            dataModel.Reservations = _reservationRepository.GetReservationsByDay(id, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            if (id == _userManager.GetUserId(HttpContext.User))
                dataModel.IsAdmin = true;
            return PartialView("_Reservation", dataModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public IActionResult EditEntityName(string newName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            _userRepository.EditFullName(userId, newName);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> EditProfileImage(IFormFile file)
        {
            var image = new Image();
            image.ImageFile = file;
            image.IsProfileImg = true;
            var userId = _userManager.GetUserId(HttpContext.User);
            await _imageRepository.CreateImage(image, userId);

            var profileImage = _imageRepository.GetImages(userId).Where(a=>a.IsProfileImg == true).SingleOrDefault().Title;
            return Ok(profileImage);
        }

        [Authorize]
        public async Task<IActionResult> Message(string id)
        {
            var playgroundReciver = await _userManager.FindByIdAsync(id);
            if (playgroundReciver == null) return NotFound();

            var currentUser = await _userManager.GetUserAsync(User);
            var allMessages = _messageRepository.GetMessages(currentUser.Id, playgroundReciver.Id).OrderByDescending(m => m.MessageDate);

            Dictionary<string, Image> profileImgs = new Dictionary<string, Image>();

            var img = _imageRepository.GetImages(playgroundReciver.Id).FirstOrDefault(m => m.IsProfileImg == true);
            if (!profileImgs.ContainsKey(playgroundReciver.Id))
            {
                profileImgs.Add(playgroundReciver.Id, img);
            }

            MessagingViewModel messagingViewModel = new MessagingViewModel
            {
                CurrentPage = playgroundReciver.FullName,
                EntityId = id,
                Messages = allMessages,
                ProfileImages = profileImgs
            };

            return View(messagingViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> EditInfoData(ApplicationUser infoData)
        {
            var user = await _userManager.GetUserAsync(User);
            var dataModel = new DataViewModel();
            dataModel.Entity = _userRepository.EditApplicationUser(user, infoData);
            dataModel.IsAdmin = true;

            return PartialView("_InfoBar", dataModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> AddNewImage(IFormFile file)
        {
            var image = new Image();
            image.ImageFile = file;
            var userId = _userManager.GetUserId(HttpContext.User);
            await _imageRepository.CreateImage(image, userId);

            var dataModel = new DataViewModel();
            dataModel.Images = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == false);
            dataModel.IsAdmin = true;
            return PartialView("_Images", dataModel);
        }

        [HttpGet]
        [Authorize(Policy = "PlaygroundPolicy")]
        public IActionResult ShowImageControl()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var dataModel = new DataViewModel();
            dataModel.Images = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == false);
            dataModel.IsAdmin = true;

            return PartialView("_Images", dataModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageRepository.DeleteImage(id);
            var userId = _userManager.GetUserId(HttpContext.User);

            var dataModel = new DataViewModel();
            dataModel.Images = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == false);
            dataModel.IsAdmin = true;
            return PartialView("_Images", dataModel);
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var playgroundId = _userManager.GetUserId(User);
            var acceptedReservation = _reservationRepository.GetPlaygroundReservationById(id);
            if (acceptedReservation.UserId != null)
                await NotifyUser(playgroundId, acceptedReservation, $"Sorry, your reservation request has been rejected  for {acceptedReservation.Date} day from {acceptedReservation.StartTime} to {acceptedReservation.EndTime}");
            _reservationRepository.Delete(id);
            var dataModel = new DataViewModel();
            dataModel.Reservations = _reservationRepository.GetReservationsByDay(playgroundId, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            dataModel.Requests = _reservationRepository.GetRequests(playgroundId);
            dataModel.IsAdmin = true;
            if (acceptedReservation.Status == "Accepted")
                return PartialView("_Reservation", dataModel);
            else
                return PartialView("_Request", dataModel);
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
            var dataModel = new DataViewModel();
            _reservationRepository.AcceptReservation(id);
            var playgroundId = _userManager.GetUserId(User);
            var acceptedReservation = _reservationRepository.GetAll(playgroundId).FirstOrDefault(r => r.Id == id);

            // notifing the accepted request user whether their request to reserve is accepted or not
            await NotifyUser(playgroundId, acceptedReservation, $"Your reservation request has been approved for {acceptedReservation.Date} day from {acceptedReservation.StartTime} to {acceptedReservation.EndTime}");

            //check for another requests and delete the requests with the same time of another reservation            
            var remainingRequests = _reservationRepository.GetRequests(playgroundId);
            foreach (var r in remainingRequests)
            {
                if (_reservationRepository.IsValid(r) == false)
                {
                    // notifing the other users that thier requests have been rejected
                    await NotifyUser(playgroundId, r, $"Sorry, your reservation request has been rejected  for {r.Date} day from {r.StartTime} to {r.EndTime}");
                    _reservationRepository.Delete(r.Id);
                }
            }
            dataModel.Requests = _reservationRepository.GetRequests(playgroundId);
            dataModel.IsAdmin = true;
            return PartialView("_Request", dataModel);
        }

        [HttpPost]
        public IActionResult AddReservation(PlaygroundReservation reservation)
        {
            bool res = true;
            DataViewModel dataModel = new DataViewModel();
            if (User.IsInRole("Playground"))
            {
                reservation.Status = "Accepted";
                reservation.PlaygroundId = _userManager.GetUserId(HttpContext.User);
                dataModel.IsAdmin = true;
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
            {
                dataModel.Reservations = _reservationRepository.GetReservationsByDay(reservation.PlaygroundId, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                return PartialView("_Reservation",dataModel);
            }
            else
                return BadRequest(new BadRequestObjectResult("There is another reservation at the same time, Please change your reservation time."));
        }

        [HttpPost]
        public IActionResult SearchByDate(DateTime date, string playgroundId)
        {
            string userId = null;
            if (User.IsInRole("Playground"))
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

        [HttpPost]
        public IActionResult PutPlaygroundPrice(int Id, PlaygroundPrice NewPlaygroundPrice)
        {
            List<PlaygroundPrice> ConflictedPrices = _playgroundPriceRepository.GetConflictedList(NewPlaygroundPrice);
            if (ConflictedPrices.Count > 0)
            {
                if (ConflictedPrices.Count == 1)
                {
                    if (ConflictedPrices[0].Id != Id)
                    {
                        return Conflict();
                    }                    
                }
                else
                {
                    return Conflict();
                }

            }
            bool result = _playgroundPriceRepository.UpdatePlaygroundPrice(Id, NewPlaygroundPrice);
            if (result == true)
                return Ok();
            return BadRequest();

        }

        [HttpPost]
        public IActionResult AddPlaygroundPrice(int Id, PlaygroundPrice NewPlaygroundPrice)
        {
            List<PlaygroundPrice> ConflictedPrices = _playgroundPriceRepository.GetConflictedList(NewPlaygroundPrice);
            if (ConflictedPrices.Count > 0)
            {
                return Conflict();
            }
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
        public async Task<IActionResult> AddReview(Review R)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            DataViewModel reviewVM = new DataViewModel();
            var userId = R.ReviewerId;
            var TargetId = R.TargetId; 
            var review = _reviewRepository.PostReview(R);
            reviewVM.ProfileImage = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == true).SingleOrDefault();
            reviewVM.CurrentUser =  await _userManager.GetUserAsync(User);
            reviewVM.Reviews = _reviewRepository.GetReviewsOfReviewee(TargetId);
            reviewVM.Review = review;
            return PartialView("_ShowReviews", reviewVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(int id ,string TargetId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            DataViewModel reviewVM = new DataViewModel();
            reviewVM.CurrentUser = await _userManager.GetUserAsync(User);
            _reviewRepository.DeleteReview(id);
            reviewVM.Reviews = _reviewRepository.GetReviewsOfReviewee(TargetId);

            return PartialView("_ShowReviews", reviewVM);
        }
    }
}