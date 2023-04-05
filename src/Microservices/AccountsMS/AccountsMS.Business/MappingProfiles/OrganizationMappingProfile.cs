using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Data.Models.Organization;
using AutoMapper;

namespace AccountsMS.Business.MappingProfiles
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {
            CreateMap<OrganizationModel, OrganizationViewDto>();
            CreateMap<OrganizationCreateDto, OrganizationCreateModel>();
            CreateMap<OrganizationUpdateDto, OrganizationUpdateModel>();
            CreateMap<OrganizationMessageDto, OrganizationCreateModel>();
        }
    }
}
