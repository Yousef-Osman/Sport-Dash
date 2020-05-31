using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportDash.Models;
using SportDash.Repository;
using Microsoft.AspNetCore.Identity;
using SportDash.Data;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using SportDash.API;

namespace SportDash.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["baseUrl"] = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.PathBase);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        



    }
}
