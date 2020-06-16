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
    public class CoachController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserRepository _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMessageRepository _messageRepository;

        public CoachController(UserManager<ApplicationUser> userManager,
                               SignInManager<ApplicationUser> signInManager,
                               IAuthorizationService authorizationService,
                               IUserRepository userRepository,
                               IImageRepository imageRepository,
                               IReviewRepository reviewRepository,
                               IMessageRepository messageRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _reviewRepository = reviewRepository;
            _messageRepository = messageRepository;
        }

        //[HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            var dataModel = new DataViewModel();
            var user = await _userManager.GetUserAsync(User);
            dataModel.ControllerName = "Coach";
            dataModel.IsAdmin = false;

            if (User.IsInRole("Coach") && (id == null || user.Id == id))
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

        [HttpPost]
        [Authorize(Policy = "CoachPolicy")]
        public IActionResult EditEntityName(string newName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
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
        [Authorize(Policy = "CoachPolicy")]
        public async Task<IActionResult> EditProfileImage(IFormFile file)
        {
            var image = new Image();
            image.ImageFile = file;
            image.IsProfileImg = true;
            var userId = _userManager.GetUserId(HttpContext.User);
            await _imageRepository.CreateImage(image, userId);

            var profileImage = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == true).SingleOrDefault().Title;
            return Ok(profileImage);
        }


        [HttpPost]
        [Authorize(Policy = "CoachPolicy")]
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

        [HttpPost]
        [Authorize(Policy = "CoachPolicy")]
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
        [Authorize(Policy = "CoachPolicy")]
        public async Task<IActionResult> EditInfoData(ApplicationUser infoData)
        {
            var user = await _userManager.GetUserAsync(User);
            var dataModel = new DataViewModel();
            dataModel.Entity = _userRepository.EditApplicationUser(user, infoData);
            dataModel.IsAdmin = true;

            return PartialView("_InfoBar", dataModel);
        }

        [HttpPost]
        public IActionResult AddReview(Review R)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
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