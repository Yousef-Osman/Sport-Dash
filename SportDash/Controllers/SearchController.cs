using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlaygroundPriceRepository _priceRepository;
        private readonly UserManager<ApplicationUser> _User;
        private List<ApplicationUser> trainers;
        private List<ApplicationUser> playgrounds;
        private List<ApplicationUser> gyms;
        private DataViewModel SearchVM;
        
        public SearchController(UserManager<ApplicationUser> User , ApplicationDbContext context)
        {
            _User = User;
            _context = context;
            trainers = _context.Users.Where(a => a.Category == "Coach").ToList();
            playgrounds = _context.Users.Include(a=>a.PlaygroundPrices).Where(a => a.Category == "PlaygroundManager").ToList();
            gyms = _context.Users.Include(a => a.GymPrices).Where(a => a.Category == "GymManager").ToList();
            SearchVM = new DataViewModel();
        }
      
        public IActionResult Index()
        {
            IQueryable<string> locationQuery = _context.Users.Select(a => a.Location);

            SearchVM.Category = new List<SelectListItem>
            {
              new SelectListItem { Text = "PlaygroundManager", Value = "1" },
              new SelectListItem { Text = "GymManager", Value = "2" },
              new SelectListItem { Text = "Coach", Value = "3" }
            };

            SearchVM.Price = new List<SelectListItem>
            {
              new SelectListItem { Text = "Under 100", Value = "1" },
              new SelectListItem { Text = "100 - 150", Value = "2" },
              new SelectListItem { Text = "150 - 200", Value = "3" },
              new SelectListItem { Text = "Over 200", Value = "4" }
            };

            searchVM.Location = new List<SelectListItem>
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

            SearchVM.SportType = new List<SelectListItem>
            {
              new SelectListItem { Text = GamesCategory.BasketBall.ToString() , Value =((int)GamesCategory.BasketBall).ToString()},
              new SelectListItem { Text = GamesCategory.FootBall.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.Tennis.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.VolleyBall.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.Others.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() }
            };

            SearchVM.Playgrounds = playgrounds;
            SearchVM.Gyms = gyms;
            SearchVM.Trainers = trainers;
            return View(SearchVM);
        }

        //[HttpGet]
        //public IActionResult AutoCompleteSearch(string searchString)
        //{
        //    var newTrainers = trainers.Where(a=>a.FullName.Contains(searchString)).Select(a => a.FullName);
        //    var newPlaygrounds = playgrounds.Where(a =>a.FullName.Contains(searchString)).Select(a => a.FullName);
        //    var newGyms = gyms.Where(a => a.FullName.Contains(searchString)).Select(a => a.FullName);
        //    var alldata = new List<string>();
        //    alldata.AddRange(newTrainers);
        //    alldata.AddRange(newPlaygrounds);
        //    alldata.AddRange(newGyms);
        //    return Ok(alldata);
        //}

        [HttpGet]
        public IActionResult SearchResult(string searchString)
        {
           
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.ToLower();
                trainers = trainers.Where(a => a.FullName.ToLower().Contains(searchString)).ToList();
                playgrounds = playgrounds.Where(a => a.FullName.ToLower().Contains(searchString)).ToList();
                gyms = gyms.Where(a => a.FullName.ToLower().Contains(searchString)).ToList();
                SearchVM.Trainers = trainers.ToList();
                SearchVM.Playgrounds = playgrounds.ToList();
                SearchVM.Gyms = gyms.ToList();
            }

            return PartialView("_SearchResult", SearchVM);
        }

        public IActionResult SearchByCategory (string category)
        {
            return  RedirectToAction(nameof(Index));
        }

        public IActionResult SearchByPrice(string price)
        {
            string[] numbers = Regex.Split(price, @"\D+");
            var startPrice = 0;
            var toPrice=0;
            var playgroundPrices = new List<string>(); //all playgrounds Id 
            var gymPrices = new List<string>(); //all gyms Id 
            var filteredPlaygrounds = new List<ApplicationUser>();
            var filteredGyms = new List<ApplicationUser>();
            if (price.Contains("Under"))
            {
                startPrice = int.Parse(numbers[1]);
                playgroundPrices = _context.playgroundPrices.Where(p => p.Price < startPrice).Select(p => p.PlaygroundId).Distinct().ToList();
                gymPrices = _context.GymPrices.Where(g => g.Subscribtion_Price < startPrice).Select(g => g.GymId).Distinct().ToList();
            }
            else if(price.Contains("Over"))
            {
                startPrice = int.Parse(numbers[1]);
                playgroundPrices = _context.playgroundPrices.Where(p => p.Price > startPrice).Select(p => p.PlaygroundId).Distinct().ToList();
                gymPrices = _context.GymPrices.Where(g => g.Subscribtion_Price > startPrice).Select(g => g.GymId).Distinct().ToList();
            }
            else if (price.Contains("All"))
            {
                filteredPlaygrounds = playgrounds;
                filteredGyms = gyms;
            }
            else
            {
                startPrice = int.Parse(numbers[0]);
                toPrice = int.Parse(numbers[1]);
                playgroundPrices = _context.playgroundPrices.Where(p => p.Price >= startPrice && p.Price<=toPrice).Select(p => p.PlaygroundId).Distinct().ToList();
                gymPrices = _context.GymPrices.Where(g => g.Subscribtion_Price >= startPrice && g.Subscribtion_Price<=toPrice).Select(g => g.GymId).Distinct().ToList();
            }
            foreach (var p in playgroundPrices)
            {
                filteredPlaygrounds.Add(_context.Users.Find(p));
            }
            foreach (var g in gymPrices)
            {
                filteredGyms.Add(_context.Users.Find(g));
            }
            searchVM.Playgrounds = filteredPlaygrounds;
            searchVM.Gyms = filteredGyms;
            return Ok(searchVM.Playgrounds);
        }

        public IActionResult SearchBySportType(string sportType)
        {
            var filteredPlaygrounds = playgrounds;
            var filteredTrainers = trainers;
            var filteredGyms = gyms;
            if (!sportType.Contains("All"))
            {
                GamesCategory e = (GamesCategory)Enum.Parse(typeof(GamesCategory), sportType);
                filteredPlaygrounds = playgrounds.Where(p => p.SportType == e).ToList();
                filteredTrainers = trainers.Where(p => p.SportType == e).ToList();
                filteredGyms = gyms.Where(p => p.SportType == e).ToList();
            }
            searchVM.Playgrounds = filteredPlaygrounds;
            searchVM.Gyms = filteredGyms;
            searchVM.Trainers = filteredTrainers;
            return Ok(searchVM.Playgrounds);
        }

        public IActionResult SearchByLocation(string location)
        {
            var filteredPlaygrounds = playgrounds;
            var filteredTrainers = trainers;
            var filteredGyms = gyms;
            if (!location.Contains("All"))
            {
                filteredPlaygrounds = playgrounds.Where(p => p.Location == location).ToList();
                filteredTrainers = trainers.Where(p => p.Location==location).ToList();
                filteredGyms = gyms.Where(p => p.Location==location).ToList();
            }
            searchVM.Playgrounds = filteredPlaygrounds;
            searchVM.Gyms = filteredGyms;
            searchVM.Trainers = filteredTrainers;
            return Ok(searchVM.Playgrounds);
        }

    }
}