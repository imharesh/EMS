using System;
using System.Collections.Generic;
using System.Text;

using Volo.Abp.Application.Dtos;

namespace employee.Emps
{
    public class EmpDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public double Salary { get; set; }

        public Department Type { get; set; }

    }
}
