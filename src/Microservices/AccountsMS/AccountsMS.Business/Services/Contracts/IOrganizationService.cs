using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Response.Generic;
using AccountsMS.Business.Response.NonGeneric;

namespace AccountsMS.Business.Services.Contracts
{
    public interface IOrganizationService
    {
        Task<Result<IEnumerable<OrganizationViewDto>>> GetAllOrganizationsAsync();
        Task<Result<OrganizationViewDto>> GetOrganizationByIdAsync(int id);
        Task<Result<OrganizationViewDto>> GetOrganizationByEmailAsync(string email);
        Task<Result<OrganizationViewDto>> CreateOrganizationAsync(OrganizationCreateDto organizationCreateDto);
        Task<Result> UpdateOrganizationAsync(OrganizationUpdateDto organizationUpdateDto);
        Task<Result> DeleteOrganizationAsync(int id);
    }
}
