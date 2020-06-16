using Microsoft.AspNetCore.Mvc.Rendering;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class DataViewModel
    {
        public DataViewModel()
        {
            var lists = new RegistrationLists();

            locations = lists.locations;
            SportTypeOptions = lists.SportTypeOptions;
            BallRentingOptions = lists.availability;
            LockerRoomOptions = lists.availability;
            SafeOptions = lists.availability;
            ToiletOptions = lists.availability;
            ForLadiesOptions = lists.availability;
        }

        public ApplicationUser CurrentUser { get; set; }
        public ApplicationUser Entity { get; set; }
        public string ImagePath { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSigned { get; set; }
        public string ControllerName { get; set; }
        public Review Review { get; set; }
        public Image ProfileImage { get; set; }

        public GymPrices GymPrice { get; set; }
        public List<GymPrices> GymPricesList { get; set; }
        public List<Question> QuestionList   { get; set; }

        public Question Question { get; set; }

        

        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<PlaygroundReservation> Reservations { get; set; }
        public IEnumerable<PlaygroundReservation> Requests { get; set; }
        public IEnumerable<PlaygroundReservation> AllReservations { get; set; }
        public IEnumerable<PlaygroundPrice> PlaygroundPrices { get; set; }

        public List<SelectListItem> locations { get; set; }
        public List<SelectListItem> SportTypeOptions { get; set; }
        public List<SelectListItem> BallRentingOptions { get; set; }
        public List<SelectListItem> LockerRoomOptions { get; set; }
        public List<SelectListItem> SafeOptions { get; set; }
        public List<SelectListItem> ToiletOptions { get; set; }
        public List<SelectListItem> ForLadiesOptions { get; set; }
    }
}
