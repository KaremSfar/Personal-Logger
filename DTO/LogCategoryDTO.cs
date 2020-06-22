using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace PersonalLogger.DTO
{
    public class LogCategoryDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public Dictionary<string,int> CategoryFields { get; set; }
    }
}