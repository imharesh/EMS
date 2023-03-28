using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace employee.Data;

/* This is used if database provider does't define
 * IemployeeDbSchemaMigrator implementation.
 */
public class NullemployeeDbSchemaMigrator : IemployeeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
