using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using employee.HRS;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace employee.Web.Pages.HRS
{
    public class EditModalModel : employeePageModel
    {
        [BindProperty]
        public EditHRViewModel HR { get; set; }

        private readonly IHRAppService _hrAppService;

        public EditModalModel(IHRAppService hrAppService)
        {
            _hrAppService = hrAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var hrDto = await _hrAppService.GetAsync(id);
            HR = ObjectMapper.Map<HRDto, EditHRViewModel>(hrDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _hrAppService.UpdateAsync(
                HR.Id,
                ObjectMapper.Map<EditHRViewModel, UpdateHRDto>(HR)
            );

            return NoContent();
        }

        public class EditHRViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

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
