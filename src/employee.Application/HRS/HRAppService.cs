using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;


namespace employee.HRS
{
    [Authorize(employeePermissions.HRS.Default)]

    public class HRAppService :  employeeAppService, IHRAppService
    {
        private readonly IHRRepository _hrRepository;
        private readonly HRManager _hrManager;

        public HRAppService(
            IHRRepository hrRepository,
            HRManager hrManager)
        {
            _hrRepository = hrRepository;
            _hrManager = hrManager;
        }

        public async Task<HRDto> GetAsync(Guid id)
        {
            var hr = await _hrRepository.GetAsync(id);
            return ObjectMapper.Map<HR, HRDto>(hr);
        }

        public async Task<PagedResultDto<HRDto>> GetListAsync(GetHRListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(HR.Name);
            }

            var hr = await _hrRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _hrRepository.CountAsync()
                : await _hrRepository.CountAsync(
                    hr => hr.Name.Contains(input.Filter));

            return new PagedResultDto<HRDto>(
                totalCount,
                ObjectMapper.Map<List<HR>, List<HRDto>>(hr)
            );
        }

        [Authorize(employeePermissions.HRS.Create)]
        public async Task<HRDto> CreateAsync(CreateHRDto input)
        {
            var hr = await _hrManager.CreateAsync(
                input.Name,
                input.HireDate,
                input.Desc
            );

            await _hrRepository.InsertAsync(hr);

            return ObjectMapper.Map<HR, HRDto>(hr);
        }

        [Authorize(employeePermissions.HRS.Edit)]
        public async Task UpdateAsync(Guid id, UpdateHRDto input)
        {
            var hr = await _hrRepository.GetAsync(id);

            if (hr.Name != input.Name)
            {
                await _hrManager.ChangeNameAsync(hr, input.Name);
            }

            hr.HireDate = input.HireDate;
            hr.Desc = input.Desc;

            await _hrRepository.UpdateAsync(hr);
        }

        [Authorize(employeePermissions.HRS.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _hrRepository.DeleteAsync(id);
        }




    }
}
