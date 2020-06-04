using Microsoft.AspNetCore.Mvc;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.GymPrice
{
    public class GymPrice : ViewComponent
    {
        public IViewComponentResult Invoke(GymPriceViewModel gymPriceViewModel)
        {
            return View("/Components/GymPrice/GymPrice.cshtml", gymPriceViewModel);
        }
    }
}
