using System;
using Volo.Abp.Application.Dtos;

namespace employee.Emps
{
    public class HRLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
