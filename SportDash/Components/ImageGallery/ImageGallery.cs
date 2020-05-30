using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.TitleBar
{
    public class ImageGallery:ViewComponent
    {
        private readonly IImageRepository _imageRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageGallery(IImageRepository imageRepository,
                            UserManager<ApplicationUser> userManager)
        {
            _imageRepository = imageRepository;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke(string controllerName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var dataModel = new ClubViewModel();
            var newImage = new Image();
            dataModel.Images = _imageRepository.GetImages(userId);
            dataModel.ControllerName = controllerName;
            dataModel.Image = newImage;
            return View("/Components/ImageGallery/ImageGallery.cshtml", dataModel);
        }
    }
}
