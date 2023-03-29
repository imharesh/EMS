using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace employee.HRS
{
    public class GetHRListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

    }
}
