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
        private readonly IReviewRepository _IR;
        private readonly UserManager<ApplicationUser> _user;

        public DisplayReview(IReviewRepository IR, UserManager<ApplicationUser> user)
        {
            _IR = IR;
            _user = user;
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
            
            dataModel.Reviews = _IR.GetReviewsOfReviewee(userId);
            dataModel.Review = newReview;
            //dataModel.ControllerName = controllerName;
            //dataModel.CurrentUser = user_Id;
            return View("/Components/DisplayReview/DisplayReview.cshtml", dataModel);
        }
    }
}