using AccountsMS.Data.Models.Organization;

namespace AccountsMS.Data.Repositories.Contracts
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationViewModel>> GetAllOrganizationsAsync();
        Task<OrganizationViewModel?> GetOrganizationByIdAsync(int id);
        Task<OrganizationViewModel?> GetOrganizationByEmailAsync(string email);
        Task CreateOrganizationAsync(OrganizationCreateModel organizationCreateModel);
        Task UpdateOrganizationAsync(OrganizationUpdateModel organizationUpdateModel);
        Task DeleteOrganizationAsync(int id);
    }
}
