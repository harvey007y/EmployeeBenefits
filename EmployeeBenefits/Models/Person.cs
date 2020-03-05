using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBenefits.Models {
    public abstract class Person : IPerson {
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public abstract decimal GetDeduction();
    }
}