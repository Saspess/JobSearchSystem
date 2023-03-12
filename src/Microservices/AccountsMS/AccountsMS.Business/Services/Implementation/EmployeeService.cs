using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;
using AccountsMS.Business.Response.Enums;
using AccountsMS.Business.Response.Generic;
using AccountsMS.Business.Response.NonGeneric;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Data.Models.Employee;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;

namespace AccountsMS.Business.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeSkillRepository employeeSkillRepository, ISkillRepository skillRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<Result> GetAllEmployeesAsync()
        {
            var employeesModels = await _employeeRepository.GetAllEmployeesAsync();

            var employeesViewDtos = _mapper.Map<IEnumerable<EmployeeViewDto>>(employeesModels);

            return Result<IEnumerable<EmployeeViewDto>>.Successed(employeesViewDtos);
        }

        public async Task<Result> GetEmployeesBySkillNameAsync(string skillName)
        {
            var employeesModels = await _employeeRepository.GetEmployeesBySkillNameAsync(skillName);

            var employeesViewDtos = _mapper.Map<IEnumerable<EmployeeViewDto>>(employeesModels);

            return Result<IEnumerable<EmployeeViewDto>>.Successed(employeesViewDtos);
        }

        public async Task<Result> GetAllEmployeeSkillsAsync(int id)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var employeeSkillsModels = await _employeeSkillRepository.GetAllEmployeeSkillsAsync(id);

            var employeeSkillsViewDtos = _mapper.Map<IEnumerable<EmployeeSkillViewDto>>(employeeSkillsModels);

            return Result<IEnumerable<EmployeeSkillViewDto>>.Successed(employeeSkillsViewDtos);
        }

        public async Task<Result> GetEmployeeByIdAsync(int id)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var employeeViewDto = _mapper.Map<EmployeeViewDto>(employeeModel);

            return Result<EmployeeViewDto>.Successed(employeeViewDto);
        }

        public async Task<Result> GetEmployeeByEmailAsync(string email)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByEmailAsync(email);

            if (employeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var employeeViewDto = _mapper.Map<EmployeeViewDto>(employeeModel);

            return Result<EmployeeViewDto>.Successed(employeeViewDto);
        }

        public async Task<Result> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null)
            {
                return Result.Failed(AccountsMSErrorCodes.NullArgument, nameof(employeeCreateDto));
            }

            var employeeCreateModel = _mapper.Map<EmployeeCreateModel>(employeeCreateDto);

            var createdEmployeeModel = await _employeeRepository.CreateEmployeeAsync(employeeCreateModel);

            var createdEmployeeViewDto = _mapper.Map<EmployeeViewDto>(createdEmployeeModel);

            return Result<EmployeeViewDto>.Successed(createdEmployeeViewDto);
        }

        public async Task<Result> AddEmployeeSkillAsync(int employeeId, int skillId)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            if (existingEmployeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillId);

            if (existingSkillModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Skill not found.");
            }

            await _employeeSkillRepository.AddEmployeeSkillAsync(employeeId, skillId);

            return Result.Successed();
        }

        public async Task<Result> UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto)
        {
            if (employeeUpdateDto == null)
            {
                return Result.Failed(AccountsMSErrorCodes.NullArgument, nameof(employeeUpdateDto));
            }

            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeUpdateDto.Id);

            if (existingEmployeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var employeeUpdateModel = _mapper.Map<EmployeeUpdateModel>(employeeUpdateDto);

            await _employeeRepository.UpdateEmployeeAsync(employeeUpdateModel);

            return Result.Successed();
        }

        public async Task<Result> ConfirmEmployeeSkillAsync(int employeeId, int skillId)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            if (existingEmployeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillId);

            if (existingSkillModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Skill not found.");
            }

            await _employeeSkillRepository.ConfirmEmployeeSkillAsync(employeeId, skillId);

            return Result.Successed();
        }

        public async Task<Result> DeleteEmployeeAsync(int id)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (existingEmployeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            await _employeeRepository.DeleteEmployeeAsync(id);

            return Result.Successed();
        }

        public async Task<Result> DeleteEmployeeSkillAsync(int employeeId, int skillId)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            if (existingEmployeeModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Employee not found.");
            }

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillId);

            if (existingSkillModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Skill not found.");
            }

            await _employeeSkillRepository.DeleteEmployeeSkillAsync(employeeId, skillId);

            return Result.Successed();
        }
    }
}
