using PersonalLogger.Models;
using PersonalLogger.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalLogger.Util
{
    public class FieldFactory
    {

        public Field CreateField(dynamic value,string type)
        {
            switch (type)
            {
                case "Decimal":
                    return new DecimalField(value);
                    break;
                default:
                    return new IntField();
            }
        }
    }
}