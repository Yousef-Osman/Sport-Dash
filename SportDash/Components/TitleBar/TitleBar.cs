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
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TitleBar(IUserRepository userRepository,
                            UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke(string controllerName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var dataModel = new ClubViewModel();
            dataModel.EntityName = _userRepository.GetFullName(userId);
            dataModel.ControllerName = controllerName;

            return View("/Components/TitleBar/TitleBar.cshtml", dataModel);
        }
    }
}
