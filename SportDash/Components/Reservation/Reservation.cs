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
        public IViewComponentResult Invoke(string controllerName)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var dataModel = new ClubViewModel();
            dataModel.ControllerName = controllerName;
            var requests = _repository.GetRequests(userId);
            var todayReservations = _repository.GetReservationsByDay(userId, DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Year);
            var allReservations = _repository.GetAll(userId);
            dataModel.Reservations = todayReservations;
            dataModel.Requests = requests;
            dataModel.AllReservations = allReservations;
            return View("/Components/Reservation/Reservation.cshtml", dataModel);
        }
    }
}
