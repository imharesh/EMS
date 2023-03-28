using System;
using System.Collections.Generic;
using System.Text;
using employee.Localization;
using Volo.Abp.Application.Services;

namespace employee;

/* Inherit your application services from this class.
 */
public abstract class employeeAppService : ApplicationService
{
    protected employeeAppService()
    {
        LocalizationResource = typeof(employeeResource);
    }
}
