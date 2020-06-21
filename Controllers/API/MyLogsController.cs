using PersonalLogger.Models;
using PersonalLogger.Models.Fields;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            var logList = from line in context.MyLogs.Include(m=>m.Fields)
                          select line;


            return Ok(logList);
        }
    }
}
