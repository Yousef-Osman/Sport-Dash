using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public class RegistrationLists
    {
        public List<SelectListItem> locations { get; set; }
        public List<SelectListItem> SportTypeOptions { get; set; }
        public List<SelectListItem> availability { get; set; }
        public RegistrationLists()
        {
            SportTypeOptions = new List<SelectListItem>
            {
                new SelectListItem {Text = "FootBall", Value= "0"},
                new SelectListItem {Text = "BasketBall", Value= "1"},
                new SelectListItem {Text = "VolleyBall", Value= "2"},
                new SelectListItem {Text = "Tennis", Value= "3"},
                new SelectListItem {Text = "Others", Value= "4"},
            };

            locations = new List<SelectListItem>
            {
                new SelectListItem {Text = "Abo Kier", Value= "1"},
                new SelectListItem {Text = "Alexandria", Value= "2"},
                new SelectListItem {Text = "Anfoshy", Value= "3"},
                new SelectListItem {Text = "Azarita", Value= "4"},
                new SelectListItem {Text = "Bahary ", Value= "5"},
                new SelectListItem {Text = "Bakous ", Value= "6"},
                new SelectListItem {Text = "Bolkli", Value= "7"},
                new SelectListItem {Text = "Ebrahimia", Value= "8"},
                new SelectListItem {Text = "El-Agamy", Value= "9"},
                new SelectListItem {Text = "El-Amrya", Value= "10"},
                new SelectListItem {Text = "El-Asafra", Value= "11"},
                new SelectListItem {Text = "El-Atareen", Value= "12"},
                new SelectListItem {Text = "El-Dekhila", Value= "13"},
                new SelectListItem {Text = "El-Hadara", Value= "14"},
                new SelectListItem {Text = "El-Kabary", Value= "15"},
                new SelectListItem {Text = "El-Mamoura", Value= "16"},
                new SelectListItem {Text = "El-Mandara", Value= "17"},
                new SelectListItem {Text = "El-Manshia", Value= "18"},
                new SelectListItem {Text = "El-Max", Value= "19"},
                new SelectListItem {Text = "El-Montaza", Value= "20"},
                new SelectListItem {Text = "El-Saraya ", Value= "21"},
                new SelectListItem {Text = "El-Shatby", Value= "22"},
                new SelectListItem {Text = "El-Siouf", Value= "23"},
                new SelectListItem {Text = "El-Wardiaan", Value= "24"},
                new SelectListItem {Text = "Gleam", Value= "25"},
                new SelectListItem {Text = "Janklies", Value= "26"}
            };

            availability = new List<SelectListItem>
            {
                new SelectListItem {Text = "Not Available", Value= "false"},
                new SelectListItem {Text = "Available", Value= "true"},
            };

            #region extra
            //LockerRoomOptions = new List<SelectListItem>
            //{
            //    new SelectListItem {Text = "Not Available", Value= "false"},
            //    new SelectListItem {Text = "Available", Value= "true"},
            //};

            //SafeOptions = new List<SelectListItem>
            //{
            //    new SelectListItem {Text = "Not Available", Value= "false"},
            //    new SelectListItem {Text = "Available", Value= "true"},
            //};

            //ToiletOptions = new List<SelectListItem>
            //{
            //    new SelectListItem {Text = "Not Available", Value= "false"},
            //    new SelectListItem {Text = "Available", Value= "true"},
            //};

            //ForLadiesOptions = new List<SelectListItem>
            //{
            //    new SelectListItem {Text = "Not Available", Value= "false"},
            //    new SelectListItem {Text = "Available", Value= "true"},
            //};
            #endregion
        }
    }
}
