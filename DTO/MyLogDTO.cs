using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalLogger.DTO
{
    public class MyLogDTO
    {
        public DateTime LogDate { get; set; }

        public int LogCategoryId { get; set; }

        public List<FieldDTO> Fields { get; set; }

    }
}