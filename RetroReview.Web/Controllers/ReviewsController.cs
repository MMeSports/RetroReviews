using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroReview.Models.Models;
using RetroReview.Models.Interface;
using RetroReview.Data;
using RetroReview.Web.Models;

namespace RetroReview.Web.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        IReviewRepo _repo = RetroRepoFactory.Create();
        public ActionResult Index()
        {
            return View(_repo.GetAllReviews().OrderByDescending(r => r.ReviewDate).ToList());
        }

		[AcceptVerbs("GET")]
		public ActionResult Details(int id)
		{
			return View(_repo.GetReviewById(id));
		}

		[AcceptVerbs("GET")]
		public ActionResult Platforms(string name)
		{
			return View(_repo.GetByPlatform(name).OrderByDescending(r => r.Rating).ToList());
		}

        [Route("reviews/game/{name}")]
        [AcceptVerbs("GET")]
        public ActionResult Game(string name)
        {
            return View(_repo.GetByPlatform(name).OrderByDescending(r => r.Rating).ToList());
        }
    }
}