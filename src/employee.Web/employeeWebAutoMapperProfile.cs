using AutoMapper;
using employee.Emps;
using employee.HRS; // ADDED NAMESPACE IMPORT

namespace employee.Web;

public class employeeWebAutoMapperProfile : Profile
{
    public employeeWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<EmpDto, CreateUpdateEmpDto>();
        CreateMap<Pages.HRS.CreateModalModel.CreateHRViewModel,
                   CreateHRDto>();

        CreateMap<HRDto, Pages.HRS.EditModalModel.EditHRViewModel>();
        CreateMap<Pages.HRS.EditModalModel.EditHRViewModel,
                    UpdateHRDto>();

        CreateMap<Pages.Emps.CreateModalModel.CreateEmpViewModel, CreateUpdateEmpDto>();
        CreateMap<EmpDto, Pages.Emps.EditModalModel.EditEmpViewModel>();
        CreateMap<Pages.Emps.EditModalModel.EditEmpViewModel, CreateUpdateEmpDto>();

    }
}
