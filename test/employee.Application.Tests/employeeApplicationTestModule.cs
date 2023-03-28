using Volo.Abp.Modularity;

namespace employee;

[DependsOn(
    typeof(employeeApplicationModule),
    typeof(employeeDomainTestModule)
    )]
public class employeeApplicationTestModule : AbpModule
{

}
