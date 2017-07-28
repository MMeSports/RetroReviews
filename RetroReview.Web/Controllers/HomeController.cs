using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using RetroReview.Web.Models;
using RetroReview.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroReview.Models.Interface;
using RetroReview.Data;
using RetroReview.Models.Models;

namespace RetroReview.Web.Controllers
{
    public class HomeController : Controller
    {

        IReviewRepo _repo = RetroRepoFactory.Create();

        public ActionResult Index()
        {
            return View(_repo.GetMostRecentReviews());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Search(string Category, string SearchTerm)
        {
            var model = _repo.FindReview(Category, SearchTerm);
            return View(model);
        }

    }
}