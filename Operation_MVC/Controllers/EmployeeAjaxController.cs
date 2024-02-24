using Operation_MVC.DBAccess;
using Operation_MVC.Implementation;
using Operation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operation_MVC.Controllers
{
    public class EmployeeAjaxController : Controller
    {
        private EmployeeImp employeeImp;

        public EmployeeAjaxController()
        {
            employeeImp = new EmployeeImp();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // Get employee details by ID
        public JsonResult GetEmployee(int id)
        {
            Employee employee = employeeImp.GetEmployeebyID(id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        // Get all employees
        public JsonResult GetEmployees()
        {
            var employees = employeeImp.GetEmployees();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        // Create new employee
        [HttpPost]
        public JsonResult CreateEmployee(Employee employee)
        {
            employeeImp.AddEmployee(employee);
            return Json("Employee added successfully");
        }

        // Update existing employee
        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {
            employeeImp.UpdateEmployee(employee);
            return Json("Employee updated successfully");
        }

        // Delete employee
        [HttpPost]
        public JsonResult DeleteEmployee(int id)
        {
            employeeImp.RemoveEmployee(id);
            return Json("Employee deleted successfully");
        }
    }
}