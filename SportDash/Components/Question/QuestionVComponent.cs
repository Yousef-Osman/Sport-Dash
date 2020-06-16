using Microsoft.AspNetCore.Mvc;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.Question
{
    public class QuestionVComponent : ViewComponent
    {
        private readonly IImageRepository _imageRepository;

        public QuestionVComponent(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public IViewComponentResult Invoke(DataViewModel dataViewModel)
        {
            dataViewModel.ImagePath = GetImagePath(dataViewModel.Question.UserId);
            return View("/Components/Question/QuestionViewComponent.cshtml", dataViewModel);
        }
        
        public string GetImagePath(string id)
        {
            Image image = _imageRepository.GetImages(id).Where(img => img.IsProfileImg).FirstOrDefault();
            if (image == null)
            {
                return "/images/site/user-icon.jpg";                
            }
            else
            {
                return "/images/" + image.Title;
            }
        }
    }

}
