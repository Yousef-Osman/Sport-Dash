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
        private readonly IPlaygroundPriceRepository _playgroundPriceRepository;


        public PlaygroundController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    IAuthorizationService authorizationService,
                                    IUserRepository userRepository,
                                    IImageRepository imageRepository,
                                    IPlaygroundReservationRepository reservationRepository,
                                    IPlaygroundPriceRepository playgroundPriceRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _reservationRepository = reservationRepository;
            _playgroundPriceRepository = playgroundPriceRepository;
        }

        //[HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            //TempData["baseUrl"] = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.PathBase);
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
    }
}