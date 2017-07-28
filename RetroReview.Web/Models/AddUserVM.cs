using Microsoft.AspNet.Identity.EntityFramework;
using RetroReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroReview.Web.Models
{
    public class AddUserVM
    {
        public AppUser User { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<SelectListItem> RoleList { get { return new SelectList(Roles, "Id", "Name"); } }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}