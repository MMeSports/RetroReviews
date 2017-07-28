using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RetroReview.Models
{
    public class AppUser : IdentityUser
    {
        public string Password { get; set; }
        public int ProfileId { get; set; }
        public int AuthorId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual Author Author { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("ProfileId", ProfileId.ToString()));
            userIdentity.AddClaim(new Claim("AuthorId", AuthorId.ToString()));
            return userIdentity;
        }
    }
    
}
