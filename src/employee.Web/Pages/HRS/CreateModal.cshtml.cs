using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using employee.HRS;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace employee.Web.Pages.HRS
{
    public class CreateModalModel : employeePageModel
    {
        [BindProperty]
        public CreateHRViewModel HR { get; set; }

        private readonly IHRAppService _hrAppService;

        public CreateModalModel(IHRAppService hrAppService)
        {
            _hrAppService = hrAppService;
        }

        public void OnGet()
        {
            HR = new CreateHRViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateHRViewModel, CreateHRDto>(HR);
            await _hrAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateHRViewModel
        {
            [Required]
            [StringLength(HRConsts.MaxNameLength)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime HireDate { get; set; }

            [TextArea]
            public string Desc { get; set; }
        }
    }
}
