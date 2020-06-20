using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalLogger.Models
{
    public class MyLog : Entity
    {
        [Required]
        public DateTime LogDate { get; set; }

        //public Category Category { get; set; }

        //public List<Logs> Logs { get; set; }
    }
}