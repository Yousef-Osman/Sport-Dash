using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportDash.Models;
using SportDash.Repository;

namespace SportDash.Controllers
{
    public class PlaygroundPriceController : Controller
    {
        IPlaygroundPriceRepository playgroundPriceRepository;

        public PlaygroundPriceController(IPlaygroundPriceRepository playgroundPriceRepository)
        {
            this.playgroundPriceRepository = playgroundPriceRepository;
        }

        // POST: PlaygroundPrice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: PlaygroundPrice/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        
    }
}