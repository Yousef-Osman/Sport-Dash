using Microsoft.AspNetCore.Mvc;
using SportDash.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SportDash.Data;
using SportDash.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportDash.Components.AvailableSports
{
    public class AvailablePlaygrounds : ViewComponent
    {                
        private readonly UserManager<ApplicationUser> userManager;

        public AvailablePlaygrounds(UserManager<ApplicationUser> userManager)
        {            
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //var user = userManager.GetUserId(HttpContext.User);
            //List<SelectListItem> allPlaygrounds = new List<SelectListItem>();

            //foreach (var playground in playgroundRepository.GetAll())
            //{
            //    allPlaygrounds.Add(new SelectListItem(playground.FullName, playground.Id));
            //}
            //var clubModel = new ClubViewModel
            //{
            //    AllPlaygrounds = allPlaygrounds,
            //    PlaygroundsOfClub = playgroundRepository.GetPlaygroundsOfClub(user)
            //};
            //return View("/Components/AvailablePlaygrounds/AvailablePlaygrounds.cshtml", clubModel);
            return View("/Components/AvailablePlaygrounds/AvailablePlaygrounds.cshtml");
        }
    }
}
