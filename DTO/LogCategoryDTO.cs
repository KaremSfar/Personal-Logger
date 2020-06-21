using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace PersonalLogger.DTO
{
    public class LogCategoryDTO
    {
        public string CategoryName { get; set; }

        public Dictionary<string,string> CategoryFields { get; set; }
    }
}