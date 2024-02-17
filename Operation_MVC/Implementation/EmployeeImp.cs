using Operation_MVC.DBAccess;
using Operation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Operation_MVC.Implementation
{
    public class EmployeeImp
    {
        public void AddEmployee(Employee obj_employee)
        {
            try
            {
                EmployeeDB db = new EmployeeDB();
                db.InsertEmployee(obj_employee.FirstName, obj_employee.LastName, obj_employee.Salary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployeebyID(int EmployeeID)
        {
            try
            {
                List<Employee> employeeList = new List<Employee>();
                EmployeeDB db = new EmployeeDB();
                Employee obj = db.GetEmployeeByID(EmployeeID);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                List<Employee> employeeList = new List<Employee>();
                EmployeeDB db = new EmployeeDB();
                DataTable dt = db.GetEmployees();
                foreach (DataRow row in dt.Rows)
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Salary = Convert.ToDecimal(row["Salary"])
                    };

                    employeeList.Add(employee);
                }

                return employeeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateEmployee(Employee obj_employee)
        {
            try
            {
                EmployeeDB db = new EmployeeDB();
                db.UpdateEmployee(obj_employee.EmployeeID, obj_employee.FirstName, obj_employee.LastName, obj_employee.Salary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveEmployee(int EmployeeID)
        {
            try
            {
                EmployeeDB db = new EmployeeDB();
                db.DeleteEmployee(EmployeeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}