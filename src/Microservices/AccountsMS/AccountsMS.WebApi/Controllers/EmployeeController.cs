using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;
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
    public class EmployeeController : BaseAccountsMSController
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<JssResult<IEnumerable<EmployeeViewDto>>> GetAllEmployeesAsync()
        {
            var result = await _employeeService.GetAllEmployeesAsync();

            if (result.IsSuccess == false)
            {
                return Failed<IEnumerable<EmployeeViewDto>>(result.ErrorCode);
            }

            return Succesed<IEnumerable<EmployeeViewDto>>(result.Value);
        }

        [HttpGet]
        [Route("GetBySkillName/{skillName}")]
        public async Task<JssResult<IEnumerable<EmployeeViewDto>>> GetEmployeesBySkillNameAsync([FromRoute] string skillName)
        {
            var result = await _employeeService.GetEmployeesBySkillNameAsync(skillName);

            if (result.IsSuccess == false)
            {
                return Failed<IEnumerable<EmployeeViewDto>>(result.ErrorCode);
            }

            return Succesed<IEnumerable<EmployeeViewDto>>(result.Value);
        }

        [HttpGet]
        [Route("GetSkills/{id:int}")]
        public async Task<JssResult<IEnumerable<EmployeeSkillViewDto>>> GetAllEmployeeSkillsAsync([FromRoute] int id)
        {
            var result = await _employeeService.GetAllEmployeeSkillsAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed<IEnumerable<EmployeeSkillViewDto>>(result.ErrorCode);
            }

            return Succesed<IEnumerable<EmployeeSkillViewDto>>(result.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<JssResult<EmployeeViewDto>> GetEmployeeByIdAsync([FromRoute] int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed<EmployeeViewDto>(result.ErrorCode);
            }

            return Succesed<EmployeeViewDto>(result.Value);
        }

        [HttpGet("{email}")]
        public async Task<JssResult<EmployeeViewDto>> GetEmployeeByEmailAsync([FromRoute] string email)
        {
            var result = await _employeeService.GetEmployeeByEmailAsync(email);

            if (result.IsSuccess == false)
            {
                return Failed<EmployeeViewDto>(result.ErrorCode);
            }

            return Succesed<EmployeeViewDto>(result.Value);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<JssResult<EmployeeViewDto>> CreateEmployeeAsync([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            var result = await _employeeService.CreateEmployeeAsync(employeeCreateDto);

            if (result.IsSuccess == false)
            {
                return Failed<EmployeeViewDto>(result.ErrorCode);
            }

            return Succesed<EmployeeViewDto>(result.Value);
        }

        [HttpPut]
        [Route("AddSkill")]
        [Authorize(Roles = "Employee")]
        public async Task<JssResult> AddEmployeeSkillAsync([FromBody] EmployeeSkillDto employeeSkillDto)
        {
            var result = await _employeeService.AddEmployeeSkillAsync(employeeSkillDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<JssResult> UpdateEmployeeAsync([FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(employeeUpdateDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpPut]
        [Route("ConfirmSkill")]
        public async Task<JssResult> ConfirmEmployeeSkillAsync([FromBody] EmployeeSkillDto employeeSkillDto)
        {
            var result = await _employeeService.ConfirmEmployeeSkillAsync(employeeSkillDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<JssResult> DeleteEmployeeAsync([FromRoute] int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpDelete]
        [Route("DeleteSkill")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<JssResult> DeleteEmployeeSkillAsync([FromBody] EmployeeSkillDto employeeSkillDto)
        {
            var result = await _employeeService.DeleteEmployeeSkillAsync(employeeSkillDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }
    }
}
