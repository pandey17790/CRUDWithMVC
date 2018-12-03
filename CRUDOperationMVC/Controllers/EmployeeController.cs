using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperationMVC.Models;
using CRUDOperationMVC.Filters;

namespace CRUDOperationMVC.Controllers
{
    [ExceptionLog]
    public class EmployeeController : Controller
    {
        Connections con = new Connections();
        public ActionResult Index()
        {
            IEnumerable<Employee> empList = con.GetEmployees().ToList();
            return View(empList);
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            bool isSuccess = false;
            try
            {
                if (ModelState.IsValid)
                {
                    isSuccess = con.AddEmployee(emp);
                    if (isSuccess)
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EmpDetail(Int32 empCode)
        {
            var emp = con.GetEmployeeByCode(empCode);
            return View(emp);
        }

        [HttpGet]
        public ActionResult Edit(Int32 empCode)
        {
            var editData = con.GetEmployees().Where(e => e.EmpCode.Equals(empCode)).First();
            return View(editData);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                isSuccess = con.UpdateEmployee(emp);
                if (isSuccess)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int empCode)
        {
            bool isSuccess = false;
            isSuccess = con.DeleteEmployee(empCode);
            
            if (isSuccess)
                return RedirectToAction("Index");
            else
                return View();

        }
    }
}