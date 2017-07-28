using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroReview.Models.Interface;
using RetroReview.Data;
using RetroReview.Models.Models;
using System.IO;
using RetroReview.Models;
using RetroReview.Web.Models;
using Microsoft.AspNet.Identity;
namespace RetroReview.Web.Controllers
{
    [Authorize(Roles ="admin, contributor")]
    public class ContributorController : Controller
    {
		IReviewRepo _repo = RetroRepoFactory.Create();
        // GET: Contributor
        //[Route("contributor/index")]
        //[AcceptVerbs("GET")]
        //public ActionResult Index()
        //{
            
        //    return View();
        //}

	
		[AcceptVerbs("GET")]
        public ActionResult AddReview()
        {
            var model = new AddReviewVM();
            model.RatingList = _repo.GetAllRatings();
            model.PlatformList = _repo.GetAllPlatforms();
            return View(model);
        }

      
        [AcceptVerbs("POST")]
        public ActionResult AddReview(AddReviewVM data, HttpPostedFileBase file)
        {
            data.GameReview.ReviewDate = DateTime.Now;
            if (data.GameReview.Game.GameCover == null)
            {
                data.GameReview.Game.GameCover = new GameCover();
            }
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/imgs/"), fileName);
                    data.GameReview.Game.GameCover.GameCoverUrl = "imgs/" + fileName;
                    file.SaveAs(path);
                }
            } catch
            {
                data.GameReview.Game.GameCover.GameCoverUrl = "imgs/default.png";
                _repo.ContributorAddReview(data.GameReview);
                return RedirectToAction("Index", "Reviews");
            }
            _repo.ContributorAddReview(data.GameReview);
            return RedirectToAction("Index", "Reviews");
        }

	
		[AcceptVerbs("GET")]
        public ActionResult DeleteReview(int id)
        {
            var reviewToDelete = _repo.GetReviewById(id);
            if (HttpContext.User.IsInRole("admin") || int.Parse(HttpContext.User.Identity.GetAuthorId().Remove(0,10)) == reviewToDelete.AuthorId)
            {
                return View(reviewToDelete);
            }
            else
            {
                return RedirectToAction("Index", "Reviews");
            }
        }

    
        [AcceptVerbs("POST")]
        public ActionResult DeleteReview(Review data, string submitButton)
        {
            if(submitButton == "Delete")
            {
                _repo.AdminDeleteAnyReview(data.ReviewId);
            }
           
            return RedirectToAction("Index", "Reviews");
        }

      
		[AcceptVerbs("GET")]
        public ActionResult EditReview(int id)
        {
            var model = new AddReviewVM();
            var reviewTo = _repo.GetReviewById(id);
            if (HttpContext.User.IsInRole("admin") || int.Parse(HttpContext.User.Identity.GetAuthorId().Remove(0,10)) == reviewTo.AuthorId)
            {
                model.GameReview = _repo.GetReviewById(id);
                model.PlatformList = _repo.GetAllPlatforms();
                model.RatingList = _repo.GetAllRatings();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Reviews");
            }
        }

	
		[HttpPost]
		public ActionResult EditReview(AddReviewVM editedReview, HttpPostedFileBase file)
		{
            try
            {
                if (file.ContentLength > 0)
                {
                    editedReview.GameReview.Game.GameCover = new GameCover();
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/imgs/"), fileName);
                    editedReview.GameReview.Game.GameCover.GameCoverUrl = "imgs/" + fileName;
                    file.SaveAs(path);
                }
            }
            catch
            {
                _repo.ContributorEditReview(editedReview.GameReview);
            }
            _repo.ContributorEditReview(editedReview.GameReview);

			return RedirectToAction("Index", "Reviews");
		}

        [HttpGet]
        public ActionResult MyReviews(int id)
        {
            MyReviewVM model = new Models.MyReviewVM();
            model.MyReview = _repo.GetReviewsByAuthor(id);
            model.AuthorId = id;
            return View(model);
        }
	}
}