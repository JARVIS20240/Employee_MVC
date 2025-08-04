using Employee_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_MVC.Models; //we can access Application Models Folder in this controller.

namespace Employee_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            employeeDBContext db = new employeeDBContext(); // we create an object of employeeDBContext class to access the method GetEmployees() in this class.
            //obj Object of List<employee> will store all data of GetEmployees().
            List<employee> obj = db.GetEmployees(); // we call the method GetEmployees() and store the result in obj variable.



            return View(obj);
        }
    }
}