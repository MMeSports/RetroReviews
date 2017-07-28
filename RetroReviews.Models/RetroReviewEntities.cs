using Microsoft.AspNet.Identity.EntityFramework;
using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroReview.Models
{
    public class RetroReviewEntities : IdentityDbContext<AppUser>
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRating> GameRatings { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<StaticPage> StaticPages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<GameCover> GameCovers { get; set; }


        public RetroReviewEntities() : base("RetroReview")
        {

        }

    }
}
