using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Response.Enums;
using AccountsMS.Business.Response.Generic;
using AccountsMS.Business.Response.NonGeneric;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Data.Models.Organization;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;

namespace AccountsMS.Business.Services.Implementation
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationService(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<OrganizationViewDto>>> GetAllOrganizationsAsync()
        {
            var organizationsModels = await _organizationRepository.GetAllOrganizationsAsync();

            var organizationsViewDtos = _mapper.Map<IEnumerable<OrganizationViewDto>>(organizationsModels);

            return Result<IEnumerable<OrganizationViewDto>>.Successed(organizationsViewDtos);
        }

        public async Task<Result<OrganizationViewDto>> GetOrganizationByIdAsync(int id)
        {
            var organizationModel = await _organizationRepository.GetOrganizationByIdAsync(id);

            if (organizationModel == null)
            {
                return Result<OrganizationViewDto>.Failed(AccountsMSErrorCodes.EntityNotFound, "Organization not found.");
            }

            var organizationViewDto = _mapper.Map<OrganizationViewDto>(organizationModel);

            return Result<OrganizationViewDto>.Successed(organizationViewDto);
        }

        public async Task<Result<OrganizationViewDto>> GetOrganizationByEmailAsync(string email)
        {
            var organizationModel = await _organizationRepository.GetOrganizationByEmailAsync(email);

            if (organizationModel == null)
            {
                return Result<OrganizationViewDto>.Failed(AccountsMSErrorCodes.EntityNotFound, "Organization not found.");
            }

            var organizationViewDto = _mapper.Map<OrganizationViewDto>(organizationModel);

            return Result<OrganizationViewDto>.Successed(organizationViewDto);
        }

        public async Task<Result<OrganizationViewDto>> CreateOrganizationAsync(OrganizationCreateDto organizationCreateDto)
        {
            if (organizationCreateDto == null)
            {
                return Result<OrganizationViewDto>.Failed(AccountsMSErrorCodes.NullArgument, nameof(organizationCreateDto));
            }

            var organizationCreateModel = _mapper.Map<OrganizationCreateModel>(organizationCreateDto);

            var organizationModel = await _organizationRepository.CreateOrganizationAsync(organizationCreateModel);

            var organizationViewDto = _mapper.Map<OrganizationViewDto>(organizationModel);

            return Result<OrganizationViewDto>.Successed(organizationViewDto);
        }

        public async Task<Result> UpdateOrganizationAsync(OrganizationUpdateDto organizationUpdateDto)
        {
            if (organizationUpdateDto == null)
            {
                return Result.Failed(AccountsMSErrorCodes.NullArgument, nameof(organizationUpdateDto));
            }

            var existingOrganizationModel = await _organizationRepository.GetOrganizationByIdAsync(organizationUpdateDto.Id);

            if (existingOrganizationModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Organization not found.");
            }

            var organizationUpdateModel = _mapper.Map<OrganizationUpdateModel>(organizationUpdateDto);

            await _organizationRepository.UpdateOrganizationAsync(organizationUpdateModel);

            return Result.Successed();
        }

        public async Task<Result> DeleteOrganizationAsync(int id)
        {
            var existingOrganizationModel = await _organizationRepository.GetOrganizationByIdAsync(id);

            if (existingOrganizationModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Organization not found.");
            }

            await _organizationRepository.DeleteOrganizationAsync(id);

            return Result.Successed();
        }
    }
}
