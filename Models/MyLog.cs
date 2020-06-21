using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalLogger.Models
{
    public class MyLog : Entity
    {
        [Required]
        public DateTime LogDate { get; set; }

        public LogCategory LogCategory { get; set; }

        public List<Field> Fields { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}