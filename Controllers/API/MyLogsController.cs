using Microsoft.AspNet.Identity;
using PersonalLogger.DTO;
using PersonalLogger.Models;
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

            var logList = from line in context.MyLogs.Include(m=>m.Fields).Include(m=>m.LogCategory)
                          where line.ApplicationUserId == userId
                          select line;


            return Ok(logList);
        }

        //POST /api/myLogs
        [HttpPost]
        public IHttpActionResult CreateLog(MyLogDTO myLogDTO)
        {
            //verification and validation stuff

            var userId = User.Identity.GetUserId();

            var fields = new List<Field>();

            foreach(var field in myLogDTO.Fields)
            {
                //Fields Factory create fields with regards to dico
            }

            var logCategory = context.LogCategories.SingleOrDefault(c => c.Id == myLogDTO.LogCategoryId);

            var myLog = new MyLog
            {
                ApplicationUserId = userId,
                Fields = fields,
                LogDate = DateTime.Now,
                LogCategory = logCategory
            };


            context.MyLogs.Add(myLog);

            context.SaveChanges();

            return Ok(myLog);

        }
    }
}
