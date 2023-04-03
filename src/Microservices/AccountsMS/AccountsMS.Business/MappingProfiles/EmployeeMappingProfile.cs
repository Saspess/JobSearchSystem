using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Data.Models.Employee;
using AutoMapper;

namespace AccountsMS.Business.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeModel, EmployeeViewDto>();
            CreateMap<EmployeeCreateDto, EmployeeCreateModel>();
            CreateMap<EmployeeUpdateDto, EmployeeUpdateModel>();
            CreateMap<EmployeeMessageDto, EmployeeCreateModel>();
        }
    }
}
