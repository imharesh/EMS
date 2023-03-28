using AutoMapper;
using employee.Emps;

namespace employee.Web;

public class employeeWebAutoMapperProfile : Profile
{
    public employeeWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<EmpDto, CreateUpdateEmpDto>();
    }
}
