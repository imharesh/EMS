using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using employee.Emps;
using System;
using System.Threading.Tasks;

namespace employee.Web.Pages.Emps
{
    public class EditModalModel : employeePageModel
    {

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateEmpDto Emp { get; set; }

        private readonly IEmpAppService _empAppService;

        public EditModalModel(IEmpAppService empAppService)
        {
            _empAppService = empAppService;
        }
        public async Task OnGetAsync()
        {
            var empDto = await _empAppService.GetAsync(Id);
            Emp = ObjectMapper.Map<EmpDto, CreateUpdateEmpDto>(empDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _empAppService.UpdateAsync(Id, Emp);
            return NoContent();
        }
    }
}
