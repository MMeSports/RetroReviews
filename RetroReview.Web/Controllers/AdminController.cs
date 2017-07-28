using RetroReview.Data;
using RetroReview.Models;
using RetroReview.Models.Interface;
using RetroReview.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroReview.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IReviewRepo _repo = RetroRepoFactory.Create();

        // GET: Admin
 
        [AcceptVerbs("GET")]
        public ActionResult Users()
        {
            var model = new UserVM();
            model.AppUsers = _repo.AdminGetUsers();
            model.AppRoles = _repo.AdminGetRoles();
            return View(model);
        }
        
        [AcceptVerbs("POST")]
        public ActionResult DeleteReview(int id)
        {
            _repo.AdminDeleteAnyReview(id);
            return RedirectToAction("DeleteReview", "Contributor", new { Id = id });
        }


        [AcceptVerbs("GET")]
        public ActionResult EditUser(string id)
        {
            UserEditVM data = new UserEditVM();
            data.User = _repo.AdminGetUserByGuid(id);
			data.UserProfile = _repo.GetProfileById(data.User.ProfileId);
            data.Roles = _repo.AdminGetRoles();
            return View(data);
        }

        [AcceptVerbs("POST")]
        public ActionResult EditUser(UserEditVM data)
        {
            var roleName = _repo.AdminFindRoleById(data.RoleId).Name;
            AppUser user = data.User;
			user.Profile = data.UserProfile;
            _repo.AdminEditUser(user, roleName);
            return RedirectToAction("Users");
        }


        [AcceptVerbs("GET")]
        public ActionResult DeleteUser(string guid)
        {
            return View(_repo.AdminGetUserByGuid(guid));
        }

        [AcceptVerbs("POST")]
        public ActionResult DeleteUser(string submitButton, AppUser data)
        {
            if (submitButton == "Delete")
            {
                _repo.AdminDeleteUser(data.Id);
            }

            return RedirectToAction("Users");
        }

        [AcceptVerbs("GET")]
        public ActionResult AddUser()
        {
            AddUserVM data = new AddUserVM();
            data.Roles = _repo.AdminGetRoles();
			data.User = new AppUser();
            return View(data);
        }

        [AcceptVerbs("Post")]
        public ActionResult AddUser(AddUserVM data)
        {
			data.User.Profile.UserName = data.User.UserName;
            var roleName = _repo.AdminFindRoleById(data.RoleId).Name;
            _repo.AdminAddUser(data.User, data.Password, roleName);
            return RedirectToAction("Users");
        }

        //<div>
        //    <div>
        //        <label>User Name : </label> @Html.TextBoxFor(m => m.User.UserName) <br /><br />
        //        <label>Phone : </label>@Html.TextBoxFor(m => m.User.PhoneNumber)<br /><br />
        //        <label>Email : </label> @Html.TextBoxFor(m => m.User.Email)<br /><br />
        //        <label>Author Name : </label> @Html.TextBoxFor(m => m.User.Author.Name)<br /><br />
        //        <label>Password : </label> @Html.TextBoxFor(m => m.Password)<br /><br /><br />
        //        <label>Confirm Password : </label> @Html.TextBoxFor(m => m.ConfirmPassword)
        //    </div>
        //</div>
        //@Html.HiddenFor(m => m.User.Id)
        //@Html.DropDownListFor(d => d.RoleId, Model.RoleList)

       
        [AcceptVerbs("GET")]
        public ActionResult Statics()
        {

            var model = _repo.GetAllStaticPages();
            
            return View(model);
        }
        

        [AcceptVerbs("PUT")]
        public void Statics(int staticPageId, string mytextarea)
        {
            _repo.AdminEditStaticPage(staticPageId, mytextarea);
        }

        
    }
}