using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefits.Domain {
    [Table("tblDependents")]
    public class Dependent : Person {

        // Primary key
        [DisplayName("Dependent Id")]
        public int DependentId { get; set; }

        public string Type { get; set; }

        // Foreign key
        [ForeignKey("Employee")]
        [HiddenInput(DisplayValue =false)]
        public int EmployeeId { get; set; }

        // Navigation property
        public virtual Employee Employee { get; set; }

        public override decimal GetDeduction() {
            const decimal _normalDependentDeduction = 500 / 26;
            const decimal _discountDependentDeduction = 50 / 26;
            decimal deduction = 0;
            if (FirstName.ToUpper().StartsWith("A")) {
                deduction = _discountDependentDeduction;
            } else {
                deduction += _normalDependentDeduction;
            }
            return deduction;
        }
    }
}