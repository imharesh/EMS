using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace employee.HRS
{
    public interface IHRAppService : IApplicationService
    {
        Task<HRDto> GetAsync(Guid id);

        Task<PagedResultDto<HRDto>> GetListAsync(GetHRListDto input);

        Task<HRDto> CreateAsync(CreateHRDto input);

        Task UpdateAsync(Guid id, UpdateHRDto input);

        Task DeleteAsync(Guid id);
    }
}
