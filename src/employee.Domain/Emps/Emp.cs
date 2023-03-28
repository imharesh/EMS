using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace employee.Emps
{
    public class Emp : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public double Salary { get; set; }

        public Department Type { get; set; }

        

     
    }
}
