using employee.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace employee;

[DependsOn(
    typeof(employeeEntityFrameworkCoreTestModule)
    )]
public class employeeDomainTestModule : AbpModule
{

}
