using RetroReview.Data;
using RetroReview.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroReview.Models.Models;

namespace RetroReview.Web.Controllers
{
    public class ProfileController : Controller
    {
        IReviewRepo _repo = RetroRepoFactory.Create();
        // GET: Profile

        public ActionResult List(int id)
        {
            var model = _repo.GetProfileById(id);
            return View(model);
        }

        [Authorize(Roles = "admin, contributor")]
        public ActionResult Edit(int id)
        {
            var model = _repo.GetProfileById(id);
            if(HttpContext.User.IsInRole("admin") || int.Parse(HttpContext.User.Identity.GetProfileId().Remove(0,11)) == model.ProfileId)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [Authorize(Roles = "admin, contributor")]
        [HttpPost]
        public ActionResult Edit(Profile data)
        {
            _repo.AdminEditProfile(data);
            return RedirectToAction("List", "Profile", new { @id = data.ProfileId });
        }
    }
}