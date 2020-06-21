using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalLogger.Models
{
    public class CategoryField : Entity
    {
        public string FieldName { get; set; }

        public string FieldType { get; set; }
    }
}