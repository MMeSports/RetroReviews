using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroReview.Models.Models
{
   public class Game
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string ReleaseYear { get; set; }
        public int GameRatingId { get; set; }
        public int PlatformId { get; set; }
        public int GameCoverId { get; set; }

        public virtual GameRating GameRating { get; set; }
        public virtual GameCover GameCover { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
