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

namespace SportDash.Components
{
    public class DisplayReview : ViewComponent
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<ApplicationUser> _user;
        private readonly IImageRepository _imageRepository;

        public DisplayReview(IReviewRepository reviewRepository,
                             UserManager<ApplicationUser> user ,
                             IImageRepository imageRepository)
        {
            _reviewRepository = reviewRepository;
            _user = user;
            _imageRepository = imageRepository;
        }


        public IViewComponentResult Invoke(DataViewModel dataModel)
        {
            
            var newReview = new Review();
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
            
            dataModel.Reviews = _reviewRepository.GetReviewsOfReviewee(userId);
            dataModel.Review = newReview;
            dataModel.ProfileImage = _imageRepository.GetImages(userId).Where(a => a.IsProfileImg == true).SingleOrDefault();
            //dataModel.ControllerName = controllerName;
            //dataModel.CurrentUser = user_Id;
            return View("/Components/DisplayReview/DisplayReview.cshtml", dataModel);
        }
    }
}