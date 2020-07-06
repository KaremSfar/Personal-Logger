using PersonalLogger.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace PersonalLogger.DTO
{
    public class LogCategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [MinLength(3)]
        public string CategoryName { get; set; }


        public List<CategoryFieldDTO> CategoryFields { get; set; }
    }
}