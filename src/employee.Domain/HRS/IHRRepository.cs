using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace employee.HRS
{
    public interface IHRRepository : IRepository<HR , Guid>
    {
        Task<HR> FindByNameAsync(string name);

        Task<List<HR>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
