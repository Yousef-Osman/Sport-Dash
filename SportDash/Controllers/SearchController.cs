using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
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

            SearchVM.Location = new SelectList(locationQuery.Distinct().ToList());

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
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SearchBySportType(string sportType)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SearchByLocation(string location)
        {
            return RedirectToAction(nameof(Index));
        }

    }
}