using employee.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace employee.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class employeeController : AbpControllerBase
{
    protected employeeController()
    {
        LocalizationResource = typeof(employeeResource);
    }
}
