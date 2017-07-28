using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroReview.Models.Interface;
using RetroReview.Data;

namespace RetroReview.Web.Controllers
{
    public class WhatsHotController : Controller
    {
        // GET: WhatsHot
        IReviewRepo _repo = RetroRepoFactory.Create();

        public ActionResult Index()
        {
            return View(_repo.GetAllReviews().OrderByDescending(r => r.Rating));
        }
    }
}