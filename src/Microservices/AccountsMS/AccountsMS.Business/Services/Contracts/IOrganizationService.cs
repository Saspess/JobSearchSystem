using AccountsMS.Business.DTOs.Organization;

namespace AccountsMS.Business.Services.Contracts
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationViewDto>> GetAllOrganizationsAsync();
        Task<OrganizationViewDto> GetOrganizationByIdAsync(int id);
        Task<OrganizationViewDto> GetOrganizationByEmailAsync(string email);
        Task<OrganizationViewDto> CreateOrganizationAsync(OrganizationCreateDto organizationCreateDto);
        Task UpdateOrganizationAsync(OrganizationUpdateDto organizationUpdateDto);
        Task DeleteOrganizationAsync(int id);
    }
}
