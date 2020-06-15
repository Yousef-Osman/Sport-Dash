using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportDash.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int errorCode)
        {
            ViewBag.code = errorCode;
            return View();
        }
    }
}