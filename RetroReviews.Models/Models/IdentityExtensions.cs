using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RetroReview.Models.Models
{
    public static class IdentityExtensions
    {
        public static string GetProfileId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirst("ProfileId").ToString();
            }
            return null;
        }
        public static string GetAuthorId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirst("AuthorId").ToString();
            }
            return null;
        }
    }
        
    
}
