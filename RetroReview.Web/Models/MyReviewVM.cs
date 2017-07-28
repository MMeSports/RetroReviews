using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetroReview.Web.Models
{
    public class MyReviewVM
    {
        public int AuthorId { get; set; }
        public List<Review> MyReview { get; set; }
    }
}