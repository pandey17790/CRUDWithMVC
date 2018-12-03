using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Models
{
    public class Employee
    {
        [DisplayName("Employee Code")]
        [RegularExpression(@"^[0-9]+$")]
        public Int32 EmpCode { get; set; }
        [DisplayName("First Name")]
        [MinLength(3),MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [MinLength(3), MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }
        [DisplayName("Desigantion")]
        public string Designation { get; set; }
        [DisplayName("Salary")]
        public Int32 Salary { get; set; }
    }
}