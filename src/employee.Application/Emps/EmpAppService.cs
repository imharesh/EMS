using employee.Permissions;
using employee.HRS;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;


namespace employee.Emps;

[Authorize(employeePermissions.Emps.Default)]
public class EmpAppService :
     CrudAppService<
        Emp, //The Book entity
        EmpDto, //Used to show Books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmpDto>, //Used to create/update a book
    IEmpAppService //implement the IBookAppService
{
    private readonly IHRRepository _hrRepository;
    public EmpAppService(IRepository<Emp, Guid> repository, IHRRepository hrRepository)
       : base(repository)
    {
        _hrRepository = hrRepository;
        GetPolicyName = employeePermissions.Emps.Default;
        GetListPolicyName = employeePermissions.Emps.Default;
        CreatePolicyName = employeePermissions.Emps.Create;
        UpdatePolicyName = employeePermissions.Emps.Edit;
        DeletePolicyName = employeePermissions.Emps.Delete;
    }

    public override async Task<EmpDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from emp in queryable
                    join hr in await _hrRepository.GetQueryableAsync() on emp.HRId equals hr.Id
                    where emp.Id == id
                    select new { emp, hr };

        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Emp), id);
        }

        var empDto = ObjectMapper.Map<Emp, EmpDto>(queryResult.emp);
        empDto.HRName = queryResult.hr.Name;
        return empDto;
    }

    public override async Task<PagedResultDto<EmpDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from emp in queryable
                    join hr in await _hrRepository.GetQueryableAsync() on emp.HRId equals hr.Id
                    select new { emp, hr };

        //Paging
        query = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of BookDto objects
        var empDtos = queryResult.Select(x =>
        {
            var empDto = ObjectMapper.Map<Emp, EmpDto>(x.emp);
            empDto.HRName = x.hr.Name;
            return empDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<EmpDto>(
            totalCount,
            empDtos
        );
    }

    public async Task<ListResultDto<HRLookupDto>> GetHRLookupAsync()
    {
        var hr = await _hrRepository.GetListAsync();

        return new ListResultDto<HRLookupDto>(
            ObjectMapper.Map<List<HR>, List<HRLookupDto>>(hr)
        );
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"emp.{nameof(Emp.Name)}";
        }

        if (sorting.Contains("hrName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "hrName",
                "hr.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"emp.{sorting}";
    }
}
