using AutoMapper;
using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Enums;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Data.Entities;
using System.Security.Cryptography;
using System.Text;

namespace IdentityMS.Business.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            CreateMap<UserEntity, UserAuthenticateDto>();

            CreateMap<EmployeeRegisterDto, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => GetPasswordHash(src.Password)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Roles.Employee.ToString()));

            CreateMap<OrganizationRegisterDto, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => GetPasswordHash(src.Password)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Roles.Organization.ToString()));

            CreateMap<UserRegisterDto, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => GetPasswordHash(src.Password)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<UserEntity, UserViewDto>();

            CreateMap<UserUpdateDto, UserEntity>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => GetPasswordHash(src.Password)));

            CreateMap<EmployeeRegisterDto, EmployeeMessageDto>();

            CreateMap<OrganizationRegisterDto, OrganizationMessageDto>();
        }

        private string GetPasswordHash(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var hashValue = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashValue);
            }
        }
    }
}
