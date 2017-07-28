using Microsoft.AspNet.Identity.EntityFramework;
using RetroReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetroReview.Web.Models
{
    public class UserVM
    {
        public List<AppUser> AppUsers { get; set; }
        public List<IdentityRole> AppRoles { get; set; }
    }
}