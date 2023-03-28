using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using employee.Emps;
using System.Threading.Tasks;

namespace employee.Web.Pages.Emps
{
    public class CreateModalModel : employeePageModel
    {

        [BindProperty]
        public CreateUpdateEmpDto Emp { get; set; }

        private readonly IEmpAppService _empAppService;

        public CreateModalModel(IEmpAppService empAppService)
        {
            _empAppService = empAppService;
        }
        public void OnGet()
        {
            Emp = new CreateUpdateEmpDto();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _empAppService.CreateAsync(Emp);
            return NoContent();
        }
    }
}
