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

                case "Int":
                    return new IntField(value);
                    break;

                case "String":
                    return new StringField(value);
                    break;

                case "TimeSpan":
                    return new TimeSpanField(value);
                    break;

                default:
                    return new StringField(value);
            }
        }
    }
}