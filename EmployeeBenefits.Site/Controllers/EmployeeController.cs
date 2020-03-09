using EmployeeBenefits.Domain;
using EmployeeBenefits.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefits.Controllers {
    [Authorize()]
    public class EmployeeController : Controller {


        const decimal _payAmount = 2000;

        public ActionResult Index() {
            EmployeeContext employeeContext = new EmployeeContext();
            var employees = employeeContext.Employees.Include("Dependents").ToList();
                    
            decimal deductions = 0;
            foreach (var employee in employees) {
                deductions = CalcDeduction(employee);

                foreach (var dependent in employee.Dependents) {                    
                   deductions += CalcDeduction(dependent);                    
                }
                employee.PayAmount = _payAmount - deductions;
                employee.Deductions = deductions;
            }
            return View(employees);
        }
        [NonAction]
        public decimal CalcDeduction(IPerson person) {            
            return person.GetDeduction();
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get() {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post() {

            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid) {
                EmployeeContext employeeContext = new EmployeeContext();
                employeeContext.Employees.Add(employee);
                employeeContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            EmployeeContext employeeContext = new EmployeeContext();
            var employee = employeeContext.Employees.Single(x => x.EmployeeId == id);
            return View(employee);
        }

        [HttpPost]        
        public ActionResult Edit() {

            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid) {
                EmployeeContext employeeContext = new EmployeeContext();
                employeeContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                employeeContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id = 0) {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Find(id);
            if (employee == null) {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /ToDoEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Find(id);
            employeeContext.Employees.Remove(employee);
            employeeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Employee
        public ActionResult Details(int id) {
            EmployeeContext employeeContext = new EmployeeContext();
            var employee = employeeContext.Employees.Include("Dependents").Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(employee);
        }


    }
}