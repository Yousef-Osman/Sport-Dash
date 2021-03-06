﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
                new SelectListItem {Text = "Boxing", Value= "4"},
                new SelectListItem {Text = "Judo", Value= "5"},
                new SelectListItem {Text = "Karate", Value= "6"},
                new SelectListItem {Text = "Kung Fu", Value= "7"},
                new SelectListItem {Text = "Wrestling", Value= "8"},
                new SelectListItem {Text = "HandBall", Value= "9"},
                new SelectListItem {Text = "Tennis Table", Value= "10"},
                new SelectListItem {Text = "Others", Value= "11"},
            };

            locations = new List<SelectListItem>
            {
                new SelectListItem {Text = "Abo Kier", Value= "Abo Kier"},
                new SelectListItem {Text = "Anfoshy", Value= "Anfoshy"},
                new SelectListItem {Text = "Azarita", Value= "Azarita"},
                new SelectListItem {Text = "Bahary ", Value= "Bahary"},
                new SelectListItem {Text = "Bakous ", Value= "Bakous"},
                new SelectListItem {Text = "Bolkli", Value= "Bolkli"},
                new SelectListItem {Text = "Ebrahimia", Value= "Ebrahimia"},
                new SelectListItem {Text = "El-Agamy", Value= "El-Agamy"},
                new SelectListItem {Text = "El-Amrya", Value= "El-Amrya"},
                new SelectListItem {Text = "El-Asafra", Value= "El-Asafra"},
                new SelectListItem {Text = "El-Atareen", Value= "El-Atareen"},
                new SelectListItem {Text = "El-Dekhila", Value= "El-Dekhila"},
                new SelectListItem {Text = "El-Hadara", Value= "El-Hadara"},
                new SelectListItem {Text = "El-Kabary", Value= "El-Kabary"},
                new SelectListItem {Text = "El-Mamoura", Value= "El-Mamoura"},
                new SelectListItem {Text = "El-Mandara", Value= "El-Mandara"},
                new SelectListItem {Text = "El-Manshia", Value= "El-Manshia"},
                new SelectListItem {Text = "El-Max", Value= "El-Max"},
                new SelectListItem {Text = "El-Montaza", Value= "El-Montaza"},
                new SelectListItem {Text = "El-Saraya ", Value= "El-Saraya"},
                new SelectListItem {Text = "El-Shatby", Value= "El-Shatby"},
                new SelectListItem {Text = "El-Siouf", Value= "El-Siouf"},
                new SelectListItem {Text = "El-Wardiaan", Value= "El-Wardiaan"},
                new SelectListItem {Text = "Gleam", Value= "Gleam"},
                new SelectListItem {Text = "Janklies", Value= "Janklies"},
                new SelectListItem {Text = "Loran", Value= "Loran"},
                new SelectListItem {Text = "Miami", Value= "Miami"},
                new SelectListItem {Text = "Moharam Bek", Value= "Moharam Bek"},
                new SelectListItem {Text = "Sidi Bisher", Value= "Sidi Bisher"}
            };

            availability = new List<SelectListItem>
            {
                new SelectListItem {Text = "Not Available", Value= "false"},
                new SelectListItem {Text = "Available", Value= "true"},
            };
        }
    }
}
