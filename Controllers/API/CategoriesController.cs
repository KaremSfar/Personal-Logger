using PersonalLogger.DTO;
using PersonalLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
            var list = from line in context.LogCategories.Include(c => c.CategoryFields)
                       select line;
            return Ok(list);
        }


        //POST /api/cetegories
        public IHttpActionResult CreateCategory(LogCategoryDTO logCategoryDTO)
        {
            var categoryFields = new List<CategoryField>();

            foreach(var c in logCategoryDTO.CategoryFields)
            {
                categoryFields.Add(new CategoryField { FieldName = c.Key, FieldType = c.Value });
            }

            var logCategory = new LogCategory()
            {
                CategoryName = logCategoryDTO.CategoryName,
                CategoryFields = categoryFields
            };

            var savedCategory = context.LogCategories.Add(logCategory);

            context.SaveChanges();

            return Ok(savedCategory);

        }
    }
}
