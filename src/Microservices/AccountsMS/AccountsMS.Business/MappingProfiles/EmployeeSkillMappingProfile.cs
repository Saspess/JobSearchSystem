using AccountsMS.Business.DTOs.EmployeeSkill;
using AccountsMS.Data.Models.EmployeeSkill;
using AutoMapper;

namespace AccountsMS.Business.MappingProfiles
{
    public class EmployeeSkillMappingProfile : Profile
    {
        public EmployeeSkillMappingProfile()
        {
            CreateMap<EmployeeSkillModel, EmployeeSkillViewDto>();
        }
    }
}
