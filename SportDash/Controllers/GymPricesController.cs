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
    public class GymPricesController : Controller
    {
        IGymPricesRepository gymPriceRepository;

        public GymPricesController(IGymPricesRepository gymPriceRepository)
        {
            this.gymPriceRepository = gymPriceRepository;
        }

        // GET: GymPrices/EditPerDayPrice/5
        [HttpPost]
        public ActionResult EditPerDayPrice(GymPrices gymPrice)
        {
            gymPriceRepository.AddPerDayPrice(gymPrice.GymId,gymPrice);
            return View();
        }

        // POST: GymPrices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GymPrices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GymPrices/Delete/5
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