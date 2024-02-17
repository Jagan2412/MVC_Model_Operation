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
    public class EmployeeController : Controller
    {
        EmployeeImp employeeImp = new EmployeeImp();
        
        public ActionResult Index()
        {
            List<Employee> employees = employeeImp.GetEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employeeImp.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            employee = employeeImp.GetEmployeebyID(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            employeeImp.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            employeeImp.RemoveEmployee(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Employee employee = new Employee();
            employee = employeeImp.GetEmployeebyID(id);
            return View(employee);
        }
    }
}