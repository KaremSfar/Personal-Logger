using AutoMapper;
using Microsoft.Ajax.Utilities;
using PersonalLogger.DTO;
using PersonalLogger.Models;
using System.Linq;
using System.Web.Http;

namespace PersonalLogger.Controllers.API
{
    public class FieldTypesController : ApiController
    {

        private ApplicationDbContext context;

        public FieldTypesController()
        {
            context = new ApplicationDbContext();
        }


        //GET /api/FieldTypes
        [HttpGet]
        public IHttpActionResult GetFieldTypes()
        {
            var fieldTypes = context.FieldTypes.Select(Mapper.Map<Models.FieldType,FieldTypeDTO>);

            return Ok(fieldTypes);
        }

    }
}
