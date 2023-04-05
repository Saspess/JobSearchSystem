using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.WebApi.Response.Generic;
using AccountsMS.WebApi.Response.NonGeneric;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountsMS.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : BaseAccountsMSController
    {
        private IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<JssResult<IEnumerable<OrganizationViewDto>>> GetAllOrganizationsAsync()
        {
            var result = await _organizationService.GetAllOrganizationsAsync();

            if (result.IsSuccess == false)
            {
                return Failed<IEnumerable<OrganizationViewDto>>(result.ErrorCode);
            }

            return Succesed<IEnumerable<OrganizationViewDto>>(result.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<JssResult<OrganizationViewDto>> GetAllOrganizationByIdAsync([FromRoute] int id)
        {
            var result = await _organizationService.GetOrganizationByIdAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed<OrganizationViewDto>(result.ErrorCode);
            }

            return Succesed<OrganizationViewDto>(result.Value);
        }

        [HttpGet("{email}")]
        public async Task<JssResult<OrganizationViewDto>> GetOrganizationByEmailAsync([FromRoute] string email)
        {
            var result = await _organizationService.GetOrganizationByEmailAsync(email);

            if (result.IsSuccess == false)
            {
                return Failed<OrganizationViewDto>(result.ErrorCode);
            }

            return Succesed<OrganizationViewDto>(result.Value);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Organization")]
        public async Task<JssResult<OrganizationViewDto>> CreateOrganizationAsync([FromBody] OrganizationCreateDto organizationCreateDto)
        {
            var result = await _organizationService.CreateOrganizationAsync(organizationCreateDto);

            if (result.IsSuccess == false)
            {
                return Failed<OrganizationViewDto>(result.ErrorCode);
            }

            return Succesed<OrganizationViewDto>(result.Value);
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Organization")]
        public async Task<JssResult> UpdateOrganizationAsync([FromBody] OrganizationUpdateDto organizationUpdateDto)
        {
            var result = await _organizationService.UpdateOrganizationAsync(organizationUpdateDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin, Organization")]
        public async Task<JssResult> DeleteOrganizationAsync([FromRoute] int id)
        {
            var result = await _organizationService.DeleteOrganizationAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }
    }
}
