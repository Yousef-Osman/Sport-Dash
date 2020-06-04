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
            GymPriceViewModel gymPriceViewModel = new GymPriceViewModel();
            if (dataViewModel.Entity != null)
            {
                userId = dataViewModel.Entity.Id;
            }
            else if (dataViewModel.Entity == null)
            {
                userId = dataViewModel.CurrentUser.Id;
                dataViewModel.Entity = dataViewModel.CurrentUser;
            }
            gymPriceViewModel.DataViewModel = dataViewModel;
            IEnumerable<GymPrices> AllGymPricesForAGym = await _gymPricesRepository.PricesOfAGym(userId);
            AllGymPricesForAGym = AllGymPricesForAGym.ToList();
            List<GymPriceViewModel> GymPriceViewModels = new List<GymPriceViewModel>();

            //if AllGymPricesForAGym doesn't have any price make GymPriceViewModels
            //at least have one item that have dataViewModel to be passed to the view

            if (AllGymPricesForAGym.Count() == 0)
            {
                GymPriceViewModels.Add(new GymPriceViewModel() { DataViewModel = dataViewModel, GymPrice = null });
            }
            else
            {
                foreach (GymPrices gprice in AllGymPricesForAGym)
                {
                    GymPriceViewModels.Add(new GymPriceViewModel() { DataViewModel = dataViewModel, GymPrice = gprice });
                }
            }

            return View("/Components/GymPricesSection/GymPricesSection.cshtml", GymPriceViewModels);
        }
    }
}
