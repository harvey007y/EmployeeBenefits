using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeBenefits.Site;
using EmployeeBenefits.Site.Controllers;
using EmployeeBenefits.Controllers;
using EmployeeBenefits.Domain;
using EmployeeBenefits.Business;

namespace EmployeeBenefits.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest {       

        [TestMethod]       
        public void CalculateDeductionNormal()
        {
            // Arrange
            EmployeeController employeeController = new EmployeeController();
            Employee employee = new Employee() {
                EmployeeId = 1,
                FirstName = "Wade",
                LastName = "Harvey"
            };

            Dependent dependent = new Dependent() {
                EmployeeId = 1,
                FirstName = "Barbara",
                LastName = "Harvey",
                Type = "Child",
                DependentId = 1
            };

            Dependent spouse = new Dependent() {
                EmployeeId = 1,
                FirstName = "Rebecca",
                LastName = "Harvey",
                Type = "Spouse",
                DependentId = 2
            };
            employee.Dependents.Add(dependent);
            employee.Dependents.Add(spouse);
            // Act
            decimal employeeResult = employeeController.CalcDeduction(employee);
            decimal dependentResult = 0;
            foreach (var depend in employee.Dependents) {
                dependentResult += employeeController.CalcDeduction(depend);
            }            
            decimal actualDeduction = employeeResult + dependentResult;

            // Assert
            decimal  employeeDeduction = 1000 / 26;
            decimal dependentDeduction = 500 / 26;
            decimal estimatedDeduction = employeeDeduction + (dependentDeduction * 2);
            Assert.AreEqual(actualDeduction, estimatedDeduction);
        }

        
    

    [TestMethod]
    public void CalculateDeductionDiscounted() {
        // Arrange
        EmployeeController employeeController = new EmployeeController();
        Employee employee = new Employee() {
            EmployeeId = 1,
            FirstName = "Allene",
            LastName = "Harvey"
        };

        Dependent dependent = new Dependent() {
            EmployeeId = 1,
            FirstName = "Alice",
            LastName = "Harvey",
            Type = "Child",
            DependentId = 1
        };

        Dependent spouse = new Dependent() {
            EmployeeId = 1,
            FirstName = "Alicia",
            LastName = "Harvey",
            Type = "Spouse",
            DependentId = 2
        };
        employee.Dependents.Add(dependent);
        employee.Dependents.Add(spouse);
        // Act
        decimal employeeResult = employeeController.CalcDeduction(employee);
        decimal dependentResult = 0;
        foreach (var depend in employee.Dependents) {
            dependentResult += employeeController.CalcDeduction(depend);
        }
        decimal actualDeduction = employeeResult + dependentResult;

        // Assert
        decimal employeeDeduction = 100 / 26;
        decimal dependentDeduction = 50 / 26;
        decimal estimatedDeduction = employeeDeduction + (dependentDeduction * 2);
        Assert.AreEqual(actualDeduction, estimatedDeduction);
    }


}
}
