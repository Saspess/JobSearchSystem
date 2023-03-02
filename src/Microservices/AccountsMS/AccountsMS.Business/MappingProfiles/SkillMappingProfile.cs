using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Data.Models.Skill;
using AutoMapper;

namespace AccountsMS.Business.MappingProfiles
{
    public class SkillMappingProfile : Profile
    {
        public SkillMappingProfile()
        {
            CreateMap<SkillModel, SkillViewDto>();
            CreateMap<SkillCreateDto, SkillCreateModel>();
            CreateMap<SkillUpdateDto, SkillUpdateModel>();
        }
    }
}
