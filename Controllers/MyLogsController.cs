using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalLogger.Controllers
{
    public class MyLogsController : Controller
    {
        // GET: MyLogs
        public ActionResult Index()
        {
            return View();
        }
    }
}