using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_MVC.Models
{
    public class employee
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public int salary { get; set; }
        public string city { get; set; }
    }
}