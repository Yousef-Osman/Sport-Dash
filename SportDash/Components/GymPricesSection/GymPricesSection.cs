using Microsoft.AspNetCore.Mvc;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.GymPricesSection
{
    public class GymPricesSection : ViewComponent
    {
        private readonly IGymPricesRepository _gymPricesRepository;

        public GymPricesSection(IGymPricesRepository gymPricesRepository)
        {
            _gymPricesRepository = gymPricesRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync(DataViewModel dataViewModel)
        {
            string userId = null;
            if (dataViewModel.Entity != null)
            {
                userId = dataViewModel.Entity.Id;
            }
            else if (dataViewModel.Entity == null)
            {
                userId = dataViewModel.CurrentUser.Id;
                dataViewModel.Entity = dataViewModel.CurrentUser;
            }

            IEnumerable<GymPrices> AllGymPricesForAGym = await _gymPricesRepository.PricesOfAGym(userId);
            dataViewModel.GymPricesList = AllGymPricesForAGym.ToList();
            
            return View("/Components/GymPricesSection/GymPricesSection.cshtml", dataViewModel);
        }
    }
}
