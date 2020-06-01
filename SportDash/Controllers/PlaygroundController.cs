using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
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

        public PlaygroundController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    IAuthorizationService authorizationService,
                                    IUserRepository userRepository,
                                    IImageRepository imageRepository,
                                    IPlaygroundReservationRepository reservationRepository,
                                    IReviewRepository reviewRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _reservationRepository = reservationRepository;
            _reviewRepository = reviewRepository;
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
        public IActionResult DeleteReservation(int id)
        {
            _reservationRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Policy = "PlaygroundPolicy")]
        public IActionResult AcceptReservation(int id)
        {
            _reservationRepository.AcceptReservation(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddReservation(PlaygroundReservation reservation)
        {
            bool res = true;
            if (ModelState.IsValid)
            {
                reservation.PlaygroundId = _userManager.GetUserId(HttpContext.User);
                res = _reservationRepository.Add(reservation);
            }
            if (res)
                return RedirectToAction(nameof(Index));
            else
                return BadRequest(new BadRequestObjectResult("There is another reservation at the same time, Please change your reservation time."));
        }

        [HttpPost]
        public IActionResult SearchByDate(DateTime date)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var data = _reservationRepository.GetReservationsByDay(userId, date.Day, date.Month, date.Year);

            if (data != null)
                return Ok(new JsonResult(data));
            else
                return NotFound(new NotFoundObjectResult("There is no reservations"));
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

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class PlaygroundController : Controller
    {
        private readonly IPlaygroundRepository playgroundRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessageRepository messageRepository;

        public PlaygroundController(
                    IPlaygroundRepository playgroundRepository, 
                    UserManager<ApplicationUser> userManager, 
                    IMessageRepository messageRepository)
        {
            this.playgroundRepository = playgroundRepository;
            this.userManager = userManager;
            this.messageRepository = messageRepository;
        }

        public async Task<IActionResult> Index(string playgroundId)
        {
            var playground = await playgroundRepository.GetPlayground(playgroundId);
            return View(playground);
        }

        public async Task<IActionResult> Message(string id)
        {
            var playgroundReciver = await playgroundRepository.GetPlayground(id);
            var currentUser = await userManager.GetUserAsync(User);
            var allMessages = messageRepository.GetMessages(currentUser.Id, playgroundReciver.Id).OrderByDescending(m => m.MessageDate);

            MessagingViewModel messagingViewModel = new MessagingViewModel
            {
                CurrentPage = playgroundReciver.FullName,
                Messages = allMessages
            };

            return View(messagingViewModel);
        }
    }
}