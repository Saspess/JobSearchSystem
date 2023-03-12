using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Response.NonGeneric;

namespace AccountsMS.Business.Services.Contracts
{
    public interface IOrganizationService
    {
        Task<Result> GetAllOrganizationsAsync();
        Task<Result> GetOrganizationByIdAsync(int id);
        Task<Result> GetOrganizationByEmailAsync(string email);
        Task<Result> CreateOrganizationAsync(OrganizationCreateDto organizationCreateDto);
        Task<Result> UpdateOrganizationAsync(OrganizationUpdateDto organizationUpdateDto);
        Task<Result> DeleteOrganizationAsync(int id);
    }
}
