using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_MVC.Models
{
    public class employee
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        
        [Required]
        public string gender { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public int salary { get; set; }

        [Required]
        public string city { get; set; }
    }
}