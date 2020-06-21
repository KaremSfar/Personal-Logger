using PersonalLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalLogger.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext context;

        public CategoriesController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/categories
        public IHttpActionResult GetCategories()
        {
            return Ok();
        }
    }
}
