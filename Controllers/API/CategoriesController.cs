using PersonalLogger.DTO;
using PersonalLogger.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
            var userId = User.Identity.GetUserId();

            var list = from line in context.LogCategories.Include(c => c.CategoryFields)
                       where line.ApplicationUserId == userId
                       select line;
            return Ok(list);
        }

        //GET /api/categories/1
        public IHttpActionResult GetCategory(int id)
        {
            var userId = User.Identity.GetUserId();

            var category = context.LogCategories.Include(c => c.CategoryFields).SingleOrDefault(c => c.Id == id && c.ApplicationUserId==userId);
            if (category == null)
            {
                NotFound();
            }
            return Ok(category);

        }

        //POST /api/cetegories
        [HttpPost]
        public IHttpActionResult CreateCategory(LogCategoryDTO logCategoryDTO)
        {
            var userId = User.Identity.GetUserId();

            var categoryFields = new List<CategoryField>();

            foreach(var c in logCategoryDTO.CategoryFields)
            {
                categoryFields.Add(new CategoryField { FieldName = c.Key, FieldType = c.Value });
            }

            var logCategory = new LogCategory()
            {
                CategoryName = logCategoryDTO.CategoryName,
                CategoryFields = categoryFields,
                ApplicationUserId = userId
            };

            var savedCategory = context.LogCategories.Add(logCategory);

            context.SaveChanges();

            return Ok(savedCategory);

        }

        //PUT /api/categories/1
        [HttpPut]
        public IHttpActionResult UpdateCategory(LogCategoryDTO logCategoryDTO)
        {
            return NotFound();
        }

        //DELETE /api/categories/1
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var userId = User.Identity.GetUserId();

            var category = context.LogCategories.Include(c => c.CategoryFields).SingleOrDefault(c => c.Id == id && c.ApplicationUserId==userId);
            if (category == null)
            {
                NotFound();
            }
            context.LogCategories.Remove(category);
            context.SaveChanges();
            return Ok(category);
        }


    }
}
