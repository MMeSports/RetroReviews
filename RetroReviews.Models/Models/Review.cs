using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RetroReview.Models.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public int AuthorId { get; set; }
        [AllowHtml]
        public string ReviewBody { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Author Author { get; set; }
    }
}
