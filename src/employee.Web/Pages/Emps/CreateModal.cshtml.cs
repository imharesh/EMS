using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using employee.Emps;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace employee.Web.Pages.Emps;

public class CreateModalModel : employeePageModel
{
    [BindProperty]
    public CreateEmpViewModel Emp { get; set; }

    public List<SelectListItem> HRS { get; set; }

    private readonly IEmpAppService _empAppService;

    public CreateModalModel(
        IEmpAppService empAppService)
    {
        _empAppService = empAppService;
    }

    public async Task OnGetAsync()
    {
        Emp = new CreateEmpViewModel();

        var hrLookup = await _empAppService.GetHRLookupAsync();
        HRS = hrLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _empAppService.CreateAsync(
            ObjectMapper.Map<CreateEmpViewModel, CreateUpdateEmpDto>(Emp)
            );
        return NoContent();
    }

    public class CreateEmpViewModel
    {
        [SelectItems(nameof(HRS))]
        [DisplayName("HR")]
        public Guid HRId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public Department Type { get; set; } = Department.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Required]
        public double Salary { get; set; }
    }
}
