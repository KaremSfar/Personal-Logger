using AutoMapper;
using Microsoft.AspNet.Identity;
using PersonalLogger.DTO;
using PersonalLogger.Models;
using PersonalLogger.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace PersonalLogger.Controllers.API
{
    public class MyLogsController : ApiController
    {
        private ApplicationDbContext context;

        public MyLogsController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/myLogs
        public IHttpActionResult GetLogs()
        {
            var userId = User.Identity.GetUserId();

            var logList = context.MyLogs.Include(m => m.Fields.Select(f=>f.CategoryField))
                .Where(m => m.ApplicationUserId == userId)
                .Select(Mapper.Map<MyLog, MyLogDTO>);


            return Ok(logList);
        }

        //POST /api/myLogs
        [HttpPost]
        public IHttpActionResult CreateLog(MyLogDTO myLogDTO)
        {
            //verification and validation stuff

            var userId = User.Identity.GetUserId();

            var category = context.LogCategories.Include(c => c.CategoryFields.Select(cf=>cf.FieldType)).SingleOrDefault(c => c.Id == myLogDTO.LogCategoryId);

            var fields = new List<Field>();

            var fieldFactory = new FieldFactory();

            foreach(var field in myLogDTO.Fields)
            {
                var fieldType = category.CategoryFields.SingleOrDefault(cf => cf.Id == field.CategoryField.Id).FieldType.TypeName;
                Field lol = fieldFactory.CreateField(field.Value, fieldType);
                lol.CategoryFieldId = field.CategoryField.Id;
                fields.Add(lol);   
            }

            var logCategory = context.LogCategories.SingleOrDefault(c => c.Id == myLogDTO.LogCategoryId);

            var myLog = new MyLog
            {
                ApplicationUserId = userId,
                Fields = fields,
                LogDate = DateTime.Now,
                LogCategoryId = myLogDTO.LogCategoryId
            };



            context.MyLogs.Add(myLog);

            context.SaveChanges();

            var rLog = Mapper.Map<MyLog, MyLogDTO>(myLog);

            return Ok(rLog);

        }
    }
}
