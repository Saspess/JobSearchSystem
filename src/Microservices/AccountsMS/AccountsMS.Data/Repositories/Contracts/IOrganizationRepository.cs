using AccountsMS.Data.Models.Organization;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync();
        Task<OrganizationModel?> GetOrganizationByIdAsync(int id);
        Task<OrganizationModel?> GetOrganizationByEmailAsync(string email);
        Task CreateOrganizationAsync(OrganizationCreateModel organizationCreateModel);
        Task UpdateOrganizationAsync(OrganizationUpdateModel organizationUpdateModel);
        Task DeleteOrganizationAsync(int id);
    }
}
