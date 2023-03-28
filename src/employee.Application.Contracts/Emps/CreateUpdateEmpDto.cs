using System;
using System.ComponentModel.DataAnnotations;

namespace employee.Emps
{
    public class CreateUpdateEmpDto
    {
      [Required]
      [StringLength(128)]
      public string Name { get; set; }


      public int Age { get; set; }


 
      public double Salary { get; set; }

        [Required]
        public Department Type { get; set; } = Department.Undefined;

    }
}
