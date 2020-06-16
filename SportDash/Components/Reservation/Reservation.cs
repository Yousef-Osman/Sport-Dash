using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.Reservation
{
    public class Reservation:ViewComponent
    {
        private readonly IPlaygroundReservationRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        public Reservation(IPlaygroundReservationRepository repository,UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public IViewComponentResult Invoke(DataViewModel dataModel)
        {
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
            var requests = _repository.GetRequests(userId);
            var todayReservations = _repository.GetReservationsByDay(userId, DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Year).OrderBy(c=>c.StartTime);
            var allReservations = _repository.GetAll(userId);
            dataModel.Reservations = todayReservations;
            dataModel.Requests = requests;
            dataModel.AllReservations = allReservations;
            return View("/Components/Reservation/Reservation.cshtml", dataModel);
        }
    }
}
