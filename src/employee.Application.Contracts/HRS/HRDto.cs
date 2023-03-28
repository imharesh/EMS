using System;
using Volo.Abp.Application.Dtos;

namespace employee.HRS
{
    public class HRDto : EntityDto<Guid>
    
    {
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public string Desc { get; set; }
    }
}
