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
        List<ApplicationUser> trainers;
        List<ApplicationUser> playgrounds;
        List<ApplicationUser> gyms;
        public SearchController(UserManager<ApplicationUser> User , ApplicationDbContext context)
        {
            _User = User;
            _context = context;
             trainers = _context.Users.Where(a => a.Category == "Trainer").ToList();
             playgrounds = _context.Users.Include(a=>a.PlaygroundPrices).Where(a => a.Category == "Playground").ToList();
             gyms = _context.Users.Include(a => a.GymPrices).Where(a => a.Category == "Gym").ToList();
        }
      
        public async Task<IActionResult> Index(string entityCategory , string entityPrice , string entityLocation , string searchString)
        {


            // Use LINQ to get list of genres.
            //IQueryable<string> categoryQuery = _context.Users.Select(a => a.Category);
            //IQueryable<string> PriceQuery = _context.Users.Select(a => a.Email);
            IQueryable<string> locationQuery = _context.Users.Select(a => a.Location);
           // IQueryable<string> SportCategoryQuery = _context.Users.Select(a => a.FullName);


            //var trainers = _context.Users.Where(a=>a.Category == "Trainer").Select(a=>a);
            //var Playgrounds = _context.Users.Where(a=>a.Category == "Playground").Select(a=>a);
            //var Gyms = _context.Users.Where(a=>a.Category == "Gym").Select(a=>a);


            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    trainers = _context.Users.Where(a => a.Category == "Trainer" && a.FullName.Contains(searchString));
            //    Playgrounds = _context.Users.Where(a => a.Category == "Playground" && a.FullName.Contains(searchString));
            //    Gyms = _context.Users.Where(a => a.Category == "Gym" && a.FullName.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(entityCategory))
            //{
            //    if(entityCategory == "Trainers")
            //    trainers = _context.Users.Where(a => a.Category == "Trainer" && a.FullName.Contains(searchString));
            //    Playgrounds = _context.Users.Where(a => a.Category == "Playground" && a.FullName.Contains(searchString));
            //    Gyms = _context.Users.Where(a => a.Category == entityCategory);
            //    movies = movies.Where(x => x. == movieGenre);
            //}





            var searchVM = new DataViewModel();

            searchVM.Category = new List<SelectListItem> 
            { 
              new SelectListItem { Text = "Playground", Value = "1" }, 
              new SelectListItem { Text = "Trainer", Value = "2" }, 
              new SelectListItem { Text = "Gym", Value = "3" }
            };

            searchVM.Price = new List<SelectListItem>
            {
              new SelectListItem { Text = "Under 100", Value = "1" },
              new SelectListItem { Text = "100 - 150", Value = "2" },
              new SelectListItem { Text = "150 - 200", Value = "3" },
              new SelectListItem { Text = "Over 200", Value = "4" }
            };

            searchVM.Location = new SelectList(await locationQuery.Distinct().ToListAsync());

            searchVM.SportType = new List<SelectListItem>
            {
              new SelectListItem { Text = GamesCategory.BasketBall.ToString() , Value =((int)GamesCategory.BasketBall).ToString()},
              new SelectListItem { Text = GamesCategory.FootBall.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.Tennis.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.VolleyBall.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() },
              new SelectListItem { Text = GamesCategory.Others.ToString() , Value = ((int)GamesCategory.BasketBall).ToString() }
            };

            searchVM.Trainers = trainers.ToList();
            searchVM.Playgrounds = playgrounds.ToList();
            searchVM.Gyms = gyms.ToList();
            

            return View(searchVM);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            var newTrainers = trainers.Where(a=>a.FullName.Contains(searchString)).Select(a => a.FullName);
            var newPlaygrounds = playgrounds.Where(a =>a.FullName.Contains(searchString)).Select(a => a.FullName);
            var newGyms = gyms.Where(a => a.Category == "Gym" && a.FullName.Contains(searchString)).Select(a => a.FullName);
            var alldata = new List<string>();
            alldata.AddRange(newTrainers);
            alldata.AddRange(newPlaygrounds);
            alldata.AddRange(newGyms);
            return Ok(alldata);
        }

        [HttpPost]
        public IActionResult SearchResult(string searchString)
        {
            var newTrainers = trainers.Where(a => a.FullName.Contains(searchString) || a.Location.Contains(searchString) || a.SportType.ToString().Contains(searchString)).ToList();
            var newPlaygrounds = playgrounds.Where(a => a.FullName.Contains(searchString) || a.Location.Contains(searchString) || a.SportType.ToString().Contains(searchString)).ToList();
            var newGyms = gyms.Where(a => a.FullName.Contains(searchString) || a.Location.Contains(searchString) || a.SportType.ToString().Contains(searchString)).ToList();
            var alldata = new List<string>();
            return RedirectToAction(nameof(Index));
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