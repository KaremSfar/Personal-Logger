using PersonalLogger.Models;
using System;
using System.Collections.Generic;
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
            var myLogs = from line in context.MyLogs
                         select line;

            return Ok(myLogs);
        }
    }
}
