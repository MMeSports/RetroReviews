using Microsoft.AspNet.Identity.EntityFramework;
using RetroReview.Models;
using RetroReview.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroReview.Models.Interface
{
    public interface IReviewRepo
    {
        void AdminEditProfile(Profile data);
        void AdminEditStaticPage(int id, string pageBody);
        List<GameRating> GetAllRatings();
        List<Platform> GetAllPlatforms();
        List<Review> GetMostRecentReviews();
        void AdminEditUser(AppUser user, string addRole);
        void AdminAddUser(AppUser user, string password, string role);
        void AdminDeleteUser(string id);
        StaticPage AdminGetStaticPage(int id);
        List<AppUser> AdminGetUsers();
        AppUser AdminGetUserByGuid(string guid);
        void AdminUpdateUser(AppUser user);
        List<IdentityRole> AdminGetRoles();
        void AdminDeleteAnyReview(int id);
        void AdminEditAnyReview(Review review);
        // void AdminEditGame(int gameId);
        void ContributorEditReview(Review review);
        // void ContributorAddGame(Game game);
        void ContributorDeleteReview(int review);
        void ContributorAddReview(Review review);
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        Profile GetProfileById(int id);
        List<Review> FindReview(string searchcategory, string searchterm);
		List<Review> GetByPlatform(string platformName);
        IdentityRole AdminFindRoleById(string roleId);
        List<Review> GetReviewsByAuthor(int authorId);
        List<StaticPage> GetAllStaticPages();

    }
}
