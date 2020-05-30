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
    public class SearchBar : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _user;

        public SearchBar(ApplicationDbContext context)
        {
            _context = context;
        }


        public IViewComponentResult Invoke(string controllerName)
        {
            var dataModel = new ReviewViewModel();
            var newReview = new Review();
            var user_Id = "";
            if (User.IsInRole("NormalUser"))
            {
                user_Id = "";
            }
            else
            {
                user_Id = _user.GetUserId(HttpContext.User);
            }
            dataModel.Reviews = _IR.GetReviewsOfReviewee(user_Id);
            dataModel.Review = newReview;
            dataModel.ControllerName = controllerName;
            dataModel.CurrentUser = user_Id;
            return View("/Components/DisplayReview/DisplayReview.cshtml", dataModel);
        }
    }
}