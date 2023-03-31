using System;
using System.ComponentModel.DataAnnotations;

namespace employee.HRS
{
    public class UpdateHRDto
    {
        [Required]
        [StringLength(HRConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public string Desc { get; set; }
    }
}
