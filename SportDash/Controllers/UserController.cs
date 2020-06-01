using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;

namespace SportDash.Controllers
{
    public class UserController : Controller
    {

        private readonly IReviewRepository _IR;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IReviewRepository IR, 
                              UserManager<ApplicationUser> userManager)
        {
            _IR = IR;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Review R)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //R.ReviewerId = _userManager.GetUserId(HttpContext.User);
            //R.TargetId = "b6bf071e-32fe-4b3f-b8ec-57ddc6737e8";
            _IR.PostReview(R);
            return Ok("Done");
        }

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var sport = repository.Find(id);
        //    if (sport == null) return NotFound();
        //    repository.Delete(sport);
        //    return Ok("Done");
        //}

        //public IActionResult Edit(int id)
        //{
        //    var sport = repository.Find(id);
        //    if (sport == null) return NotFound();
        //    return PartialView("_Edit", sport);
        //}

        //[HttpPost]
        //public IActionResult Edit(int id, Sport sport)
        //{
        //    var oldSport = repository.Find(id);
        //    if (sport == null) return NotFound();
        //    oldSport.Sports = sport.Sports;
        //    repository.Edit(oldSport);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}