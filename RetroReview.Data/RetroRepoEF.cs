using RetroReview.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroReview.Models;
using RetroReview.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RetroReview.Data
{
    class RetroRepoEF : IReviewRepo
    {
        RetroReviewEntities _repo = new RetroReviewEntities();
        

        public List<Review> GetAllReviews()
        {
            return _repo.Reviews.ToList();
        }

        public List<Review> FindReview(string searchcategory, string searchterm)
        {
            List<Review> matchingReviews = new List<Review>();
            switch (searchcategory)
            {
                case "Author":
                    matchingReviews = _repo.Reviews.ToList().FindAll(t => t.Author.Name.Contains(searchterm));
                    break;
                case "ReviewDate":
                    matchingReviews = _repo.Reviews.ToList().FindAll(x => x.ReviewDate.ToShortDateString().Contains(searchterm));
                    break;
                case "ReviewTitle":
                    matchingReviews = _repo.Reviews.ToList().FindAll(x => x.ReviewTitle.Contains(searchterm));
                    break;
                case "Platform":
                    matchingReviews = _repo.Reviews.ToList().FindAll(x => x.Game.Platform.PlatformName.Contains(searchterm));
                    break;
                case "Rating":
                    matchingReviews = _repo.Reviews.ToList().FindAll(x => x.Rating == int.Parse(searchterm));
                    break;
                case "Game":
                    matchingReviews = _repo.Reviews.ToList().FindAll(x => x.Game.GameTitle == searchterm);
                    break;
                default:
                    matchingReviews = _repo.Reviews.ToList().FindAll(x => x.Author.Name.Contains(searchterm));
                    break;
            }
            return matchingReviews;
        }


        public Review GetReviewById(int id)
        {
			return _repo.Reviews.SingleOrDefault(r => r.ReviewId == id);
        }

        public void AdminEditUser(AppUser user, string addRole)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(_repo));
            var found = _repo.Users.SingleOrDefault(e => e.Id == user.Id);

			found.Author = user.Author;

			found.Profile.FirstName = user.Profile.FirstName;
			found.Profile.LastName = user.Profile.LastName;
			found.Profile.City = user.Profile.City;
			found.Profile.State = user.Profile.State;	
			found.Profile.Description = user.Profile.Description;

			found.UserName = user.UserName;
			found.PhoneNumber = user.PhoneNumber;
			found.Email = user.Email;


				userMgr.RemoveFromRole(found.Id, "admin");
                userMgr.Update(found);

                userMgr.RemoveFromRole(found.Id, "contributor");
                userMgr.Update(found);

                userMgr.AddToRole(found.Id, addRole);
                userMgr.Update(found);
        }

        public void AdminAddUser(AppUser user, string password, string roleName)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(_repo));
            if (!_repo.Users.Any(u => u.UserName == user.UserName))
            {
                IdentityResult test = userMgr.Create(user, password);
                userMgr.AddToRole(_repo.Users.SingleOrDefault( u => u.UserName == user.UserName).Id, roleName);
            }
        }

        public AppUser AdminGetUserByGuid(string guid)
        {
            return _repo.Users.FirstOrDefault(e => e.Id == guid);
        }

        public void AdminUpdateUser(AppUser user)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var found = _repo.Users.FirstOrDefault(u => u.Id == user.Id);

            found.Author.Name = user.Author.Name;
        }

        public List<AppUser> AdminGetUsers()
        {
            return _repo.Users.ToList();
        }

        public List<IdentityRole> AdminGetRoles()
        {
            return _repo.Roles.ToList();
        }

        public void AdminDeleteUser(string id)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(_repo));
            var found = _repo.Users.SingleOrDefault(e => e.Id == id);
            userMgr.Delete(found);
            _repo.SaveChanges();
        }

        public void AdminDeleteAnyReview(int Id)
        {
            var model = _repo.Reviews.FirstOrDefault(m => m.ReviewId == Id);
            _repo.Reviews.Remove(model);
            _repo.SaveChanges();
        }

        public void AdminEditAnyReview(Review review)
        {
            var found = _repo.Reviews.FirstOrDefault(m => m.ReviewId == review.ReviewId);

            found.ReviewTitle = review.ReviewTitle;
            found.ReviewDate = review.ReviewDate;
            found.Author = review.Author;
            found.Game = review.Game;
            found.Rating = review.Rating;
            found.ReviewBody = review.ReviewBody;

            if (found != null)
            {
                found = review;
            }
            _repo.SaveChanges();
        }

        //public void AdminEditGame(int gameId)
        //{
        //    throw new NotImplementedException();
        //}

        public void ContributorEditReview(Review review)
        {
		
            var found = _repo.Reviews.FirstOrDefault(m => m.ReviewId == review.ReviewId);
			
			if (_repo.Authors.Any(a => a.Name == review.Author.Name))
			{
				found.AuthorId = _repo.Authors.FirstOrDefault(a => a.Name == review.Author.Name).AuthorId;
			}
			else
			{
				found.Author = review.Author;
			}

			if (_repo.Platforms.Any(a => a.PlatformId == review.Game.PlatformId))
			{
				found.Game.PlatformId = _repo.Platforms.FirstOrDefault(a => a.PlatformId == review.Game.PlatformId).PlatformId;
			}
			else
			{
				found.Game.Platform = review.Game.Platform;
			}

			if (_repo.GameRatings.Any(a => a.GameRatingId == review.Game.GameRatingId))
			{
				found.Game.GameRatingId = _repo.GameRatings.FirstOrDefault(a => a.GameRatingId == review.Game.GameRatingId).GameRatingId;
			}
			else
			{
				found.Game.GameRating = review.Game.GameRating;
			}

            if (_repo.GameCovers.Any(c => c.GameCoverUrl == review.Game.GameCover.GameCoverUrl))
            {
                found.Game.GameCover.GameCoverUrl = _repo.GameCovers.FirstOrDefault(c => c.GameCoverUrl == review.Game.GameCover.GameCoverUrl).GameCoverUrl;
            }
            else
            {
                found.Game.GameCover = review.Game.GameCover;
            }


            found.Game.GameTitle = review.Game.GameTitle;
			found.Game.ReleaseYear = review.Game.ReleaseYear;

            found.Rating = review.Rating;

			found.ReviewTitle = review.ReviewTitle;
            found.ReviewBody = review.ReviewBody;

            if (found != null)
            {
                found = review;
            }
            _repo.SaveChanges();
        }

        //public void ContributorAddGame(Game game)
        //{
        //    throw new NotImplementedException();
        //}

        public void ContributorDeleteReview(int reviewId)
        {
            var model = _repo.Reviews.FirstOrDefault(m => m.ReviewId == reviewId);
            _repo.Reviews.Remove(model);
            _repo.SaveChanges();
        }

        public void ContributorAddReview(Review review)
        {
            review.ReviewId = _repo.Reviews.Max(x => x.ReviewId) + 1;
            _repo.Reviews.Add(review);
            _repo.SaveChanges();
        }

        public Profile GetProfileById(int id)
        {
            return _repo.Profiles.FirstOrDefault(p => p.ProfileId == id);
        }

		public List<Review> GetByPlatform(string platformName)
		{
			return _repo.Reviews.Where(r => r.Game.Platform.PlatformName == platformName).ToList();
		}

        public IdentityRole AdminFindRoleById(string roleId)
        {
            return _repo.Roles.SingleOrDefault(e => e.Id == roleId);
        }

        public StaticPage AdminGetStaticPage(int id)
        {
            return _repo.StaticPages.SingleOrDefault(s => s.StaticPageId == id);
        }

        public List<Review> GetMostRecentReviews()
        {
            return _repo.Reviews.OrderByDescending(r => r.ReviewDate).Take(10).ToList();
        }

        public List<Review> GetReviewsByAuthor(int authorId)
        {
            return _repo.Reviews.Where(e => e.AuthorId == authorId).ToList();
        }
        public List<StaticPage> GetAllStaticPages()
        {
            return _repo.StaticPages.ToList();
        }

        public List<GameRating> GetAllRatings()
        {
            return _repo.GameRatings.ToList();
        }

        public List<Platform> GetAllPlatforms()
        {
            return _repo.Platforms.ToList();
        }
        
        public void AdminEditStaticPage(int id, string pageBody)
        {
            var query = _repo.StaticPages.SingleOrDefault(s => s.StaticPageId == id);
            query.Body = pageBody;
            _repo.SaveChanges();
        }

        public void AdminEditProfile(Profile data)
        {
            var found = _repo.Profiles.SingleOrDefault(p => p.ProfileId == data.ProfileId);
            found.FirstName = data.FirstName;
            found.LastName = data.LastName;
            found.City = data.City;
            found.State = data.State;
            found.Description = data.Description;
            _repo.SaveChanges();
        }
    }
}
