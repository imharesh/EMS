using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace employee.Web;

[Dependency(ReplaceServices = true)]
public class employeeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "employee";
}
