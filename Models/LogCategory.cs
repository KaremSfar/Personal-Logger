using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalLogger.Models
{
    public class LogCategory : Entity
    {
        public string CategoryName { get; set; }

        public List<CategoryField> CategoryFields { get; set; }
    }
}