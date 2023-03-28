using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using employee.Data;
using Volo.Abp.DependencyInjection;

namespace employee.EntityFrameworkCore;

public class EntityFrameworkCoreemployeeDbSchemaMigrator
    : IemployeeDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreemployeeDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the employeeDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<employeeDbContext>()
            .Database
            .MigrateAsync();
    }
}
