// This Is a Name Spaces:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.SqlServer.Server;

namespace Employee_MVC.Models
{
    public class employeeDBContext
    {
        // In "cs" variable , we get the connection string from web.config file and store it in "cs" variable.
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        //Create a method to get all employees from the database
        // method return type is List and <employee> is model class where we have Structure of employee / database table.
        public List<employee> GetEmployees() 
        {
            List<employee> employeesList = new List<employee>();
            SqlConnection con = new SqlConnection(cs); // we create a SQL Connection Object for connecting to the database using connection string "cs".
            SqlCommand cmd = new SqlCommand("spGetEmploteeDetails",con);

            cmd.CommandType = CommandType.StoredProcedure; //we tell, in cmd object, we have stored procedure.
            con.Open(); // we open the connection to the database.

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) //this loop will run until all the records are read from the database.In this case 8 times because we have 8 records(Column) in the database.
            {
                employee emp = new employee(); // we create a new employee object.
                emp.Id = Convert.ToInt32(dr.GetValue(0).ToString()); //take id value from database and convert it to integer and assign it to emp.Id.
                emp.name = dr.GetValue(1).ToString();
                emp.gender = dr.GetValue(2).ToString();
                emp.age = Convert.ToInt32(dr.GetValue(3).ToString()); 
                emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                emp.city = dr.GetValue(5).ToString();
                employeesList.Add(emp); // we add all Employee objects to the employeesList.
            }

            con.Close(); // we close the connection to the database.


            return employeesList;
        }
    }
}