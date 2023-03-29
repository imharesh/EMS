using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace employee.Emps;

 public interface IEmpAppService :
    ICrudAppService< //Defines CRUD methods
        EmpDto, //Used to show Emps
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmpDto> //Used to create/update a book
{
    Task<ListResultDto<HRLookupDto>> GetHRLookupAsync();
}