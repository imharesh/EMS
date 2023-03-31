using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using employee.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace employee.HRS
{
    public class EfCoreHRRepository : EfCoreRepository<employeeDbContext, HR, Guid>,
        IHRRepository
    {
        public EfCoreHRRepository(
        IDbContextProvider<employeeDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<HR> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(hr => hr.Name == name);
        }

        public async Task<List<HR>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    hr => hr.Name.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
