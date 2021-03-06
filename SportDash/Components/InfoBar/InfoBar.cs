﻿using Microsoft.AspNetCore.Mvc;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.InfoBar
{
    public class InfoBar:ViewComponent
    {
        private readonly IImageRepository _imageRepository;

        public InfoBar(IImageRepository imageRepository)
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
            return View("/Components/InfoBar/InfoBar.cshtml", dataModel);
        }
    }
}
