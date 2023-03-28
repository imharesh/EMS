using employee.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace employee.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(employeeEntityFrameworkCoreModule),
    typeof(employeeApplicationContractsModule)
    )]
public class employeeDbMigratorModule : AbpModule
{

}
