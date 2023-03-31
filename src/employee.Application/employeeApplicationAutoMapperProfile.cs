using AutoMapper;
using employee.Emps;
using employee.HRS;

namespace employee;

public class employeeApplicationAutoMapperProfile : Profile
{
    public employeeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Emp, EmpDto>();
        CreateMap<CreateUpdateEmpDto, Emp>();
        CreateMap<HR, HRDto>();

    }
}
