using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.TitleBar
{
    public class TitleBar : ViewComponent
    {
        private readonly IImageRepository _imageRepository;

        public TitleBar(IImageRepository imageRepository)
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

            dataModel.Images = _imageRepository.GetImages(userId);
            dataModel.ProfileImage = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == true).FirstOrDefault();

            return View("/Components/TitleBar/TitleBar.cshtml", dataModel);
        }
    }
}
