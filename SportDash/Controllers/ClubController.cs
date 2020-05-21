using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportDash.Controllers
{
    [Authorize(Policy="ClubPolicy")]
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}