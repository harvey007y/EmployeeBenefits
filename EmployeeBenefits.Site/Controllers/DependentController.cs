using EmployeeBenefits.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeBenefits.Business;

namespace EmployeeBenefits.Controllers
{
    [Authorize()]
    public class DependentController : Controller
    {
        // GET: Dependent
        public ActionResult Index(int employeeId, string employeeFirstName, string employeeLastName)
        {
            ViewBag.EmployeeId = employeeId;
            ViewBag.EmployeeFirstName = employeeFirstName;
            ViewBag.EmployeeLastName = employeeLastName;
            EmployeeContext employeeContext = new EmployeeContext();            
            List<Dependent> dependents = employeeContext.Dependents.Where(dep => dep.EmployeeId == employeeId).ToList();
            return View(dependents);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get(string employeeFirstName, string employeeLastName, int employeeId = 0) {
            ViewBag.EmployeeId = employeeId;
            ViewBag.EmployeeFirstName = employeeFirstName;
            ViewBag.EmployeeLastName = employeeLastName;
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post() {

            Dependent dependent = new Dependent();           
            TryUpdateModel(dependent);
            if (ModelState.IsValid) {
                EmployeeContext employeeContext = new EmployeeContext();
                employeeContext.Dependents.Add(dependent);
                employeeContext.SaveChanges();
                var employee = employeeContext.Employees.Single(x => x.EmployeeId == dependent.EmployeeId);
                return RedirectToAction("Index", new { employeeId = dependent.EmployeeId, employeeFirstName = employee.FirstName, employeeLastName = employee.LastName });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string employeeFirstName, string employeeLastName, int id, int employeeId = 0) {
            EmployeeContext employeeContext = new EmployeeContext();
            ViewBag.EmployeeId = employeeId;
            ViewBag.EmployeeFirstName = employeeFirstName;
            ViewBag.EmployeeLastName = employeeLastName;
            var dependent = employeeContext.Dependents.Single(x => x.DependentId == id);
            dependent.Type = dependent.Type.Trim();
            return View(dependent);
        }

        [HttpPost]
        public ActionResult Edit() {

            Dependent dependent = new Dependent();
            TryUpdateModel(dependent);
            if (ModelState.IsValid) {
                EmployeeContext employeeContext = new EmployeeContext();
                employeeContext.Entry(dependent).State = System.Data.Entity.EntityState.Modified;
                employeeContext.SaveChanges();
                var employee = employeeContext.Employees.Single(x => x.EmployeeId == dependent.EmployeeId);
                return RedirectToAction("Index", new { employeeId = dependent.EmployeeId, employeeFirstName = employee.FirstName, employeeLastName = employee.LastName });
            }
            return View();
        }

        public ActionResult Delete(string employeeFirstName, string employeeLastName, int id, int employeeId = 0) {
            EmployeeContext employeeContext = new EmployeeContext();
            ViewBag.EmployeeId = employeeId;
            ViewBag.EmployeeFirstName = employeeFirstName;
            ViewBag.EmployeeLastName = employeeLastName;
            Dependent dependent = employeeContext.Dependents.Find(id);
            if (dependent == null) {
                return HttpNotFound();
            }
            return View(dependent);
        }

        //
        // POST: /ToDoEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            EmployeeContext employeeContext = new EmployeeContext();
            Dependent dependent = employeeContext.Dependents.Find(id);
            employeeContext.Dependents.Remove(dependent);
            employeeContext.SaveChanges();
            var employee = employeeContext.Employees.Single(x => x.EmployeeId == dependent.EmployeeId);
            return RedirectToAction("Index", new { employeeId = dependent.EmployeeId, employeeFirstName = employee.FirstName, employeeLastName = employee.LastName });
        }

        public ActionResult Details(string employeeFirstName, string employeeLastName, int id, int employeeId = 0) {
            EmployeeContext employeeContext = new EmployeeContext();
            ViewBag.EmployeeId = employeeId;
            ViewBag.EmployeeFirstName = employeeFirstName;
            ViewBag.EmployeeLastName = employeeLastName;
            var dependent = employeeContext.Dependents.Single(x => x.DependentId == id);
            return View(dependent);
        }
    }
}