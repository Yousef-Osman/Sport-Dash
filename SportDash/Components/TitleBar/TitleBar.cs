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

        public IViewComponentResult Invoke(ClubViewModel clubViewModel)
        {
            return View("/Components/TitleBar/TitleBar.cshtml", clubViewModel);
        }
    }
}
