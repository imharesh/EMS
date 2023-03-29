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

public class EditModalModel : employeePageModel
{
    [BindProperty]
    public EditEmpViewModel Emp { get; set; }

    public List<SelectListItem> HRS { get; set; }

    private readonly IEmpAppService _empAppService;

    public EditModalModel(IEmpAppService empAppService)
    {
        _empAppService = empAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var empDto = await _empAppService.GetAsync(id);
        Emp = ObjectMapper.Map<EmpDto, EditEmpViewModel>(empDto);

        var hrLookup = await _empAppService.GetHRLookupAsync();
        HRS = hrLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _empAppService.UpdateAsync(
            Emp.Id,
            ObjectMapper.Map<EditEmpViewModel, CreateUpdateEmpDto>(Emp)
        );

        return NoContent();
    }

    public class EditEmpViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

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
