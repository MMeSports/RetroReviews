using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroReview.Web.Models
{
    public class AddReviewVM
    {
        public Review GameReview { get; set; }
        public List<GameRating> RatingList {get; set;}
        public List<Platform> PlatformList { get; set; }
        public IEnumerable<SelectListItem> Ratings
        {
            get { return new SelectList(RatingList, "GameRatingId", "GameRatingName"); }
        }

        public IEnumerable<SelectListItem> Platforms
        {
            get { return new SelectList(PlatformList, "PlatformId", "PlatformName");  }
        }
    }
}