using Employee_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_MVC.Models;  

namespace Employee_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            employeeDBContext db = new employeeDBContext(); // we create an object of employeeDBContext class to access the method GetEmployees() in this class.
            
            List<employee> obj = db.GetEmployees(); // we call the method GetEmployees() and store the result in obj variable.
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    employeeDBContext context = new employeeDBContext(); // we create an object of employeeDBContext class to access the method AddEmployee() in this class. 
                    bool check = context.AddEmployee(emp); // we call the method AddEmployee() and pass the emp object to it.
                    if (check)
                    {
                        TempData["Insert_Message"] = "Data has been Insert Sucessfully ";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();

            }
        }

        //GET: Edit
        public ActionResult Edit(int id)
        {
            employeeDBContext context = new employeeDBContext();
            var row = context.GetEmployees().Find(model => model.Id == id);
            return View(row);
        }

        //POST: Edit
        [HttpPost]
        public ActionResult Edit(int id, employee emp)
        {
            if (ModelState.IsValid == true)
            {
                employeeDBContext context = new employeeDBContext(); 
                bool check = context.UpdateEmployee(emp); 
                if (check)
                {
                    TempData["Update_Message"] = "Data has been Updated Sucessfully ";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        //GET: Details
        public ActionResult Details(int id)
        {
            employeeDBContext context = new employeeDBContext();
            var row = context.GetEmployees().Find(model => model.Id == id);
            return View(row);
        }



        //GET: Delete
        public ActionResult Delete(int id)
        {
            employeeDBContext context = new employeeDBContext();
            var row = context.GetEmployees().Find(model => model.Id == id);
            return View(row);
        }

        //POST: Delete
        //[HttpPost]
        //public ActionResult Delete(int id, employee emp)
        //{

        //        employeeDBContext context = new employeeDBContext();
        //        bool check = context.DeleteEmployee(id);
        //        if (check)
        //        {
        //        TempData["Delete_Message"] = "Data has been Updated Sucessfully ";
        //            return RedirectToAction("Index");
        //        }

        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(employee emp)
        {
            employeeDBContext context = new employeeDBContext();
            bool check = context.DeleteEmployee(emp.Id);
            if (check)
            {
                TempData["Delete_Message"] = "Data has been deleted successfully.";
                return RedirectToAction("Index");
            }
            return View(emp);
        }




    }
}