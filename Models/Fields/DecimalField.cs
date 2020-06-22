using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalLogger.Models.Fields
{
    public class DecimalField : Field
    {
        public decimal? Value { get; set; }
    }
}