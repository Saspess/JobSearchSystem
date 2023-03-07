using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Exceptions;
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

        public async Task<IEnumerable<OrganizationViewDto>> GetAllOrganizationsAsync()
        {
            var organizationsModels = await _organizationRepository.GetAllOrganizationsAsync();

            var organizationsViewDtos = _mapper.Map<IEnumerable<OrganizationViewDto>>(organizationsModels);

            return organizationsViewDtos;
        }

        public async Task<OrganizationViewDto> GetOrganizationByIdAsync(int id)
        {
            var organizationModel = await _organizationRepository.GetOrganizationByIdAsync(id)
                ?? throw new NotFoundException("Organization was not found.");

            var organizationViewDto = _mapper.Map<OrganizationViewDto>(organizationModel);

            return organizationViewDto;
        }

        public async Task<OrganizationViewDto> GetOrganizationByEmailAsync(string email)
        {
            var organizationModel = await _organizationRepository.GetOrganizationByEmailAsync(email)
                ?? throw new NotFoundException("Organization was not found.");

            var organizationViewDto = _mapper.Map<OrganizationViewDto>(organizationModel);

            return organizationViewDto;
        }

        public async Task<OrganizationViewDto> CreateOrganizationAsync(OrganizationCreateDto organizationCreateDto)
        {
            if (organizationCreateDto == null)
            {
                throw new ArgumentNullException(nameof(organizationCreateDto));
            }

            var organizationCreateModel = _mapper.Map<OrganizationCreateModel>(organizationCreateDto);

            var organizationModel = await _organizationRepository.CreateOrganizationAsync(organizationCreateModel);

            var organizationViewDto = _mapper.Map<OrganizationViewDto>(organizationModel);

            return organizationViewDto;
        }

        public async Task UpdateOrganizationAsync(OrganizationUpdateDto organizationUpdateDto)
        {
            if (organizationUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(organizationUpdateDto));
            }

            var existingOrganizationModel = await _organizationRepository.GetOrganizationByIdAsync(organizationUpdateDto.Id)
                ?? throw new NotFoundException("Organization was not found.");

            var organizationUpdateModel = _mapper.Map<OrganizationUpdateModel>(organizationUpdateDto);

            await _organizationRepository.UpdateOrganizationAsync(organizationUpdateModel);
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            var existingOrganizationModel = await _organizationRepository.GetOrganizationByIdAsync(id)
                ?? throw new NotFoundException("Organization was not found.");

            await _organizationRepository.DeleteOrganizationAsync(id);
        }
    }
}
