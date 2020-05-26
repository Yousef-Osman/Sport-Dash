using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        public ClubController(IImageRepository imageRepository,
                              IUserRepository userRepository,
                            UserManager<ApplicationUser> userManager)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _userManager = userManager;
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
        public async Task<IActionResult> AddNewImage(Image image)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            await _imageRepository.CreateImage(image, userId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageRepository.DeleteImage(id);
            return RedirectToAction(nameof(Index));
        }
    }
}