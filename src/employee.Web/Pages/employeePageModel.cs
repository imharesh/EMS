using employee.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace employee.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class employeePageModel : AbpPageModel
{
    protected employeePageModel()
    {
        LocalizationResourceType = typeof(employeeResource);
    }
}
