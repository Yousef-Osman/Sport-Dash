using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        public async Task<IActionResult> Index(string entityCategory , string entityPrice , string entityLocation , string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = _context.Users.Select(a => a.Category);
            IQueryable<string> PriceQuery = _context.Users.Include(a=>a.PlaygroundPrices).Select(a => a.PlaygroundPrices.ToList);
            IQueryable<string> LocationQuery = _context.Users.Select(a => a.Address);
            //IQueryable<string> PriceQuery = _context.Users.Select(a => a.Category);


            var trainers = _context.Users.Where(a=>a.Category == "Trainer").Select(a=>a);
            var Playgrounds = _context.Users.Where(a=>a.Category == "Playground").Select(a=>a);
            var Gyms = _context.Users.Where(a=>a.Category == "Gym").Select(a=>a);

            if (!string.IsNullOrEmpty(searchString))
            {
                 trainers = _context.Users.Where(a => a.Category == "Trainer"&& a.FullName.Contains(searchString));
                 Playgrounds = _context.Users.Where(a => a.Category == "Playground"&& a.FullName.Contains(searchString));
                 Gyms = _context.Users.Where(a => a.Category == "Gym"&& a.FullName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var searchVM = new SearchViewModel
            {
                Category = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View();
        }
    }
}