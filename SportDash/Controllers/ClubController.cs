﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;

namespace SportDash.Controllers
{
    public class ClubController : Controller
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPlaygroundReservationRepository _reservationRepository;

        public ClubController(IImageRepository imageRepository,
                              IUserRepository userRepository,
                            UserManager<ApplicationUser> userManager,
                            IPlaygroundReservationRepository reservationRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _reservationRepository = reservationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditEntityName(string newName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            //var newName = "Idiot";
            _userRepository.EditFullName(userId, newName);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewImage(IFormFile file)
        {
            var image = new Image();
            image.ImageFile = file;
            var userId = _userManager.GetUserId(HttpContext.User);
            await _imageRepository.CreateImage(image, userId);
            //return RedirectToAction(nameof(Index));
            //return ViewComponent("ImageGallery", new { controllerName = "Club" });
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageRepository.DeleteImage(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteReservation(int id)
        {
            _reservationRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
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

        // Club Actions
        //[HttpPost]
        //public async Task<IActionResult> AssignPlayground(string playgroundId)
        //{
        //    string clubId = _userManager.GetUserId(HttpContext.User);
        //    await _playgroundRepository.AssignPlaygroundToClub(playgroundId, clubId);
        //    return Ok("Done");
        //}

        //[HttpPost]
        //public async Task<IActionResult> RemovePlayground(string playgroundId)
        //{
        //    await _playgroundRepository.RemovePlaygroundFromClub(playgroundId);
        //    return Ok("Done");
        //}
    }
}