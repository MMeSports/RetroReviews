using RetroReview.Models;
using RetroReview.Models.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroReview.Data
{
    public static class RetroRepoFactory
    {
     public static IReviewRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["mode"];
            switch (mode)
            {
                case "entityFramework":
                    return new RetroRepoEF();
                default:
                    return null;
            }
        }
    }
}
