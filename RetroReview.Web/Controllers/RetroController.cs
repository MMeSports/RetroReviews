using RetroReview.Data;
using RetroReview.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RetroReview.Web.Controllers
{
   
    public class RetroController : ApiController
    {
        IReviewRepo _repo = RetroRepoFactory.Create();
        // GET api/<controller>
        public IHttpActionResult GetStaticPage(int id)
        {
            return Ok(_repo.AdminGetStaticPage(id));
        }

        public IHttpActionResult GetStaticPages()
        {
            return Ok(_repo.GetAllStaticPages());
        }

    }
}