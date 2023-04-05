using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Business.Response.Generic;
using IdentityMS.Business.Response.NonGeneric;

namespace IdentityMS.Business.Services.Contracts
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserViewDto>>> GetAllUsersAsync();
        Task<Result<UserViewDto>> RegisterEmployeeAsync(EmployeeRegisterDto employeeRegisterDto);
        Task<Result<UserViewDto>> RegisterOrganizationAsync(OrganizationRegisterDto organizationRegisterDto);
        Task<Result<string>> LoginAsync(UserLoginDto userLoginDto);
        Task<Result> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<Result> DeleteUserAsync(int id);
    }
}
