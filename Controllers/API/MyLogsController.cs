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
        public IHttpActionResult GetLogs(int? categoryId = null)
        {
            var userId = User.Identity.GetUserId();

            var logListQuery = context.MyLogs.Include(m => m.Fields.Select(f => f.CategoryField))
                .Where(m => m.ApplicationUserId == userId);

            if (categoryId != null)
            {
                logListQuery = logListQuery.Where(ml => ml.LogCategoryId == categoryId);
            }

            var logList = logListQuery.ToList()
                .Select(Mapper.Map<MyLog, MyLogDTO>);


            return Ok(logList);
        }

        //POST /api/myLogs
        [HttpPost]
        public IHttpActionResult CreateLog(MyLogDTO myLogDTO)
        {
            if (!ModelState.IsValid){
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            var category = context.LogCategories.Include(c => c.CategoryFields.Select(cf=>cf.FieldType)).SingleOrDefault(c => c.Id == myLogDTO.LogCategoryId);
            if (category == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

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


        [HttpDelete]
        public IHttpActionResult DeleteLog(int id)
        {
            var userId = User.Identity.GetUserId();

            var log = context.MyLogs.Include(l=>l.Fields).SingleOrDefault(l => l.Id == id && l.ApplicationUserId == userId);
            if (log == null)
            {
                NotFound();
            }
            context.MyLogs.Remove(log);
            context.SaveChanges();

            return Ok(Mapper.Map<MyLog,MyLogDTO>(log));
        }
    }
}
