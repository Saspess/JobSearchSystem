using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Enums;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Business.Services.Contracts;
using IdentityMS.WebApi.Response.Generic;
using IdentityMS.WebApi.Response.NonGeneric;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseIdentityMSController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<JssResult<IEnumerable<UserViewDto>>> GetAllUsersAsync()
        {
            var result = await _userService.GetAllUsersAsync();

            if (result.IsSuccess == false)
            {
                return Failed<IEnumerable<UserViewDto>>(result.ErrorCode);
            }

            return Succesed<IEnumerable<UserViewDto>>(result.Value);
        }

        [HttpPost]
        [Route("RegisterEmployee")]
        public async Task<JssResult<UserViewDto>> RegisterEmployeeAsync([FromBody] EmployeeRegisterDto employeeRegisterDto)
        {
            var result = await _userService.RegisterEmployeeAsync(employeeRegisterDto);

            if (result.IsSuccess == false)
            {
                return Failed<UserViewDto>(result.ErrorCode);
            }

            return Succesed<UserViewDto>(result.Value);
        }

        [HttpPost]
        [Route("RegisterOrganization")]
        public async Task<JssResult<UserViewDto>> RegisterOrganizationAsync([FromBody] OrganizationRegisterDto organizationRegisterDto)
        {
            var result = await _userService.RegisterOrganizationAsync(organizationRegisterDto);

            if (result.IsSuccess == false)
            {
                return Failed<UserViewDto>(result.ErrorCode);
            }

            return Succesed<UserViewDto>(result.Value);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<JssResult<string>> LoginAsync([FromBody] UserLoginDto userLoginDto)
        {
            var result = await _userService.LoginAsync(userLoginDto);

            if (result.IsSuccess == false)
            {
                return Failed<string>(result.ErrorCode);
            }

            return Succesed<string>(result.Value);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<JssResult> UpdateUserAsync([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateUserAsync(userUpdateDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<JssResult> DeleteUserAsync([FromRoute] int id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if(result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }
    }
}
