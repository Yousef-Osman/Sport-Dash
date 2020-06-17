using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private readonly UserManager<ApplicationUser> _User;
        List<ApplicationUser> trainers;
        List<ApplicationUser> playgrounds;
        List<ApplicationUser> gyms;
        private SearchViewModel searchVM;
        
        public SearchController(UserManager<ApplicationUser> User , ApplicationDbContext context)
        {
            _User = User;
            _context = context;
            trainers = _context.Users.Include(a=>a.Images).Where(a => a.Category == "Coach").ToList();
            playgrounds = _context.Users.Include(a=>a.PlaygroundPrices).Include(a=>a.Images).Where(a => a.Category == "Playground").ToList();
            gyms = _context.Users.Include(a => a.GymPrices).Include(a=>a.Images).Where(a => a.Category == "Gym").ToList();
            searchVM = new SearchViewModel();
        }
      
        public IActionResult Index()
        {
            IQueryable<string> locationQuery = _context.Users.Select(a => a.Location);

            searchVM.Category = new List<SelectListItem>
            {
              new SelectListItem { Text = "Playground", Value = "1" },
              new SelectListItem { Text = "Gym", Value = "2" },
              new SelectListItem { Text = "Coach", Value = "3" }
            };

            searchVM.Price = new List<SelectListItem>
            {
              new SelectListItem { Text = "Under 100", Value = "1" },
              new SelectListItem { Text = "100 - 150", Value = "2" },
              new SelectListItem { Text = "150 - 200", Value = "3" },
              new SelectListItem { Text = "Over 200", Value = "4" }
            };

            searchVM.Location = new List<SelectListItem>
            {
                new SelectListItem {Text = "Abo Kier", Value= "1"},
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
                new SelectListItem {Text = "Janklies", Value= "26"},
                new SelectListItem {Text = "Loran", Value= "27"},
                new SelectListItem {Text = "Miami", Value= "28"},
                new SelectListItem {Text = "Moharam Bek", Value= "29"},
                new SelectListItem {Text = "Sidi Bishr", Value= "30"}
            };

            searchVM.SportType = new List<SelectListItem>
            {
              new SelectListItem { Text = GamesCategory.BasketBall.ToString() , Value =((int)GamesCategory.FootBall).ToString()},
              new SelectListItem { Text = GamesCategory.FootBall.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.Tennis.ToString() , Value = ((int)GamesCategory.VolleyBall).ToString() },
              new SelectListItem { Text = GamesCategory.VolleyBall.ToString() , Value = ((int)GamesCategory.Tennis).ToString() },
              new SelectListItem { Text = GamesCategory.Boxing.ToString() , Value = ((int)GamesCategory.Boxing).ToString() },
              new SelectListItem { Text = GamesCategory.Judo.ToString() , Value = ((int)GamesCategory.Judo).ToString() },
              new SelectListItem { Text = GamesCategory.Karate.ToString() , Value = ((int)GamesCategory.Karate).ToString() },
              new SelectListItem { Text = GamesCategory.KungFu.ToString() , Value = ((int)GamesCategory.KungFu).ToString() },
              new SelectListItem { Text = GamesCategory.Wrestling.ToString() , Value = ((int)GamesCategory.Wrestling).ToString() },
              new SelectListItem { Text = GamesCategory.HandBall.ToString() , Value = ((int)GamesCategory.HandBall).ToString() },
              new SelectListItem { Text = GamesCategory.TennisTable.ToString() , Value = ((int)GamesCategory.TennisTable).ToString() },
              new SelectListItem { Text = GamesCategory.Others.ToString() , Value = ((int)GamesCategory.Others).ToString() }
            };

            searchVM.Playgrounds = playgrounds;
            searchVM.Gyms = gyms;
            searchVM.Trainers = trainers;
            return View(searchVM);
        }


        public JsonResult AutoCompleteSearch(string searchString)
        {
            var newTrainers = trainers.Where(a => a.FullName.ToLower().Contains(searchString.ToLower())).Select(a => a.FullName);
            var newPlaygrounds = playgrounds.Where(a => a.FullName.ToLower().Contains(searchString.ToLower())).Select(a => a.FullName);
            var newGyms = gyms.Where(a => a.FullName.ToLower().Contains(searchString.ToLower())).Select(a => a.FullName);
            var alldata = new List<string>();
            alldata.AddRange(newTrainers);
            alldata.AddRange(newPlaygrounds);
            alldata.AddRange(newGyms);
            return Json(alldata);
        }

        [HttpGet]
        public IActionResult SearchResult(string searchString)
        {
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.ToLower();
                trainers = trainers.Where(a => a.FullName.ToLower().Contains(searchString)).ToList();
                playgrounds = playgrounds.Where(a => a.FullName.ToLower().Contains(searchString)).ToList();
                gyms = gyms.Where(a => a.FullName.ToLower().Contains(searchString)).ToList();
                searchVM.Trainers = trainers.ToList();
                searchVM.Playgrounds = playgrounds.ToList();
                searchVM.Gyms = gyms.ToList();
            }
            else
            {
                searchVM.Trainers = trainers.ToList();
                searchVM.Playgrounds = playgrounds.ToList();
                searchVM.Gyms = gyms.ToList();
            }

            return PartialView("_SearchResult", searchVM);
        }

        public IActionResult AllSearches(string location,string price,string sportType)
        {
            if (!location.Contains("All"))
            {
                playgrounds = playgrounds.Where(p => p.Location == location).ToList();
                trainers = trainers.Where(p => p.Location == location).ToList();
                gyms = gyms.Where(p => p.Location == location).ToList();
            }
            if (!sportType.Contains("All"))
            {
                GamesCategory e = (GamesCategory)Enum.Parse(typeof(GamesCategory), sportType);
                playgrounds = playgrounds.Where(p => p.SportType == e).ToList();
                trainers = trainers.Where(p => p.SportType == e).ToList();
                gyms = gyms.Where(p => p.SportType == e).ToList();
            }
            if(!price.Contains("All"))
            {
                string[] numbers = Regex.Split(price, @"\D+");
                var startPrice = 0;
                var toPrice = 0;
                var playgroundPrices = new List<string>(); //all playgrounds Id
                var gymPrices = new List<string>(); //all gyms Id 
                if (price.Contains("Under"))
                {
                    startPrice = int.Parse(numbers[1]);
                    playgroundPrices = _context.playgroundPrices.Where(p => p.Price < startPrice).Select(p => p.PlaygroundId).Distinct().ToList();
                    gymPrices = _context.GymPrices.Where(g => g.Subscribtion_Price < startPrice).Select(g => g.GymId).Distinct().ToList();
                }
                else if (price.Contains("Over"))
                {
                    startPrice = int.Parse(numbers[1]);
                    playgroundPrices = _context.playgroundPrices.Where(p => p.Price > startPrice).Select(p => p.PlaygroundId).Distinct().ToList();
                    gymPrices = _context.GymPrices.Where(g => g.Subscribtion_Price > startPrice).Select(g => g.GymId).Distinct().ToList();
                }
                else
                {
                    startPrice = int.Parse(numbers[0]);
                    toPrice = int.Parse(numbers[1]);
                    playgroundPrices = _context.playgroundPrices.Where(p => p.Price >= startPrice && p.Price <= toPrice).Select(p => p.PlaygroundId).Distinct().ToList();
                    gymPrices = _context.GymPrices.Where(g => g.Subscribtion_Price >= startPrice && g.Subscribtion_Price <= toPrice).Select(g => g.GymId).Distinct().ToList();
                }
                for(int i = 0; i < playgrounds.Count; i++)
                {
                    var check = playgroundPrices.Contains(playgrounds[i].Id);
                    if (check == false)
                    {
                        playgrounds.Remove(playgrounds[i]);
                        i--;
                    }
                }
                for (int i = 0; i < gyms.Count; i++)
                {
                    var check = gymPrices.Contains(gyms[i].Id);
                    if (check == false)
                    {
                        gyms.Remove(gyms[i]);
                        i--;
                    }
                }
            }
            searchVM.Playgrounds = playgrounds;
            searchVM.Gyms = gyms;
            searchVM.Trainers = trainers;
            return PartialView("_SearchResult", searchVM);
        }
    }
}