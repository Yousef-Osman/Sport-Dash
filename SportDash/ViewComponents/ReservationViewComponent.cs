using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewComponents
{
    public class ReservationViewComponent : ViewComponent
    {
        //ApplicationDbContext context;
        public readonly IPlaygroundReservationRepository playgroundReservationRepository;

        public ReservationViewComponent(IPlaygroundReservationRepository playgroundReservationRepository)
        {
            this.playgroundReservationRepository = playgroundReservationRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync(string? playgroundId=null)
        {
            //return View(awaplaygroundReservationRepository.GetOne("1"));

            if (playgroundId!=null)
            {
                return View(await playgroundReservationRepository.GetByPlayground(playgroundId));
            }
            else
            {
                return View(await playgroundReservationRepository.GetAll());
            }
        }
    }
}
