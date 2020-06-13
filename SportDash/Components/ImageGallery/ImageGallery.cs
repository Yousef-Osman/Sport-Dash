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

        public ImageGallery(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public IViewComponentResult Invoke(DataViewModel dataModel)
        {
            string userId = null;

            if (dataModel.Entity != null)
            {
                userId = dataModel.Entity.Id;
            }
            else if (dataModel.Entity == null)
            {
                userId = dataModel.CurrentUser.Id;
                dataModel.Entity = dataModel.CurrentUser;
            }

            dataModel.Images = _imageRepository.GetImages(userId).Where(a=>a.IsProfileImg == false);
            return View("/Components/ImageGallery/ImageGallery.cshtml", dataModel);
        }
    }
}
