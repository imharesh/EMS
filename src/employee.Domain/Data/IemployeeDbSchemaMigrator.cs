using System.Threading.Tasks;

namespace employee.Data;

public interface IemployeeDbSchemaMigrator
{
    Task MigrateAsync();
}
