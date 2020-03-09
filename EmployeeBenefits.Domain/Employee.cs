using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeBenefits.Domain {
    [Table("tblEmployee")]
    public class Employee:  Person  {

        public Employee() {
            this.Dependents = new HashSet<Dependent>();
        }

        // Primary key
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }



        [NotMapped]
        [DisplayName("Pay Amount")]
        public decimal PayAmount { get; set; }
        [NotMapped]
        public decimal Deductions { get; set; }

        // Navigation property
        public virtual ICollection<Dependent> Dependents { get; set;}

        public override decimal GetDeduction() {
            const decimal _normalEmployeeDeduction = 1000 / 26;
            const decimal _discountEmployeeDeduction = 100 / 26;
            decimal deduction = 0;
            if (FirstName.ToUpper().StartsWith("A")) {
                deduction = _discountEmployeeDeduction;
            } else {
                deduction += _normalEmployeeDeduction;
            }
            return deduction;
        }
    }
}