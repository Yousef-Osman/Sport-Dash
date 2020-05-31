using Microsoft.AspNetCore.Mvc;
using SportDash.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewComponents
{
    public class PlaygroundPricesViewComponent : ViewComponent
    {
        public readonly IPlaygroundPriceRepository playgroundPriceRepository;

        public PlaygroundPricesViewComponent(IPlaygroundPriceRepository playgroundPriceRepository)
        {
            this.playgroundPriceRepository = playgroundPriceRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(string baseUrl,string? playgroundId = null)
        {
            //return View(awaplaygroundReservationRepository.GetOne("1"));
            TempData["baseUrl"] = baseUrl;
            
            if (playgroundId != null)
            {
                TempData["playgroundId"] = playgroundId;
                return View(playgroundPriceRepository.GetByPlayground(playgroundId));
            }
            else
            {
                return View(playgroundPriceRepository.GetAll());
            }
        }
    }
}
