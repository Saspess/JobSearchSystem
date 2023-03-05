using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;
using AccountsMS.Business.Exceptions;
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

        public async Task<IEnumerable<EmployeeViewDto>> GetAllEmployeesAsync()
        {
            var employeesModels = await _employeeRepository.GetAllEmployeesAsync();

            var employeesViewDtos = _mapper.Map<IEnumerable<EmployeeViewDto>>(employeesModels);

            return employeesViewDtos;
        }

        public async Task<IEnumerable<EmployeeViewDto>> GetEmployeesBySkillNameAsync(string skillName)
        {
            var employeesModels = await _employeeRepository.GetEmployeesBySkillNameAsync(skillName);

            var employeesViewDtos = _mapper.Map<IEnumerable<EmployeeViewDto>>(employeesModels);

            return employeesViewDtos;
        }

        public async Task<IEnumerable<EmployeeSkillViewDto>> GetAllEmployeeSkillsAsync(int id)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id)
                ?? throw new NotFoundException("Employee was not found.");

            var employeeSkillsModels = await _employeeSkillRepository.GetAllEmployeeSkillsAsync(id);

            var employeeSkillsViewDtos = _mapper.Map<IEnumerable<EmployeeSkillViewDto>>(employeeSkillsModels);

            return employeeSkillsViewDtos;
        }

        public async Task<EmployeeViewDto> GetEmployeeByIdAsync(int id)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByIdAsync(id)
                ?? throw new NotFoundException("Employee was not found.");

            var employeeViewDto = _mapper.Map<EmployeeViewDto>(employeeModel);

            return employeeViewDto;
        }

        public async Task<EmployeeViewDto> GetEmployeeByEmailAsync(string email)
        {
            var employeeModel = await _employeeRepository.GetEmployeeByEmailAsync(email)
                ?? throw new NotFoundException("Employee was not found.");

            var employeeViewDto = _mapper.Map<EmployeeViewDto>(employeeModel);

            return employeeViewDto;
        }

        public async Task<EmployeeViewDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null)
            {
                throw new ArgumentNullException(nameof(employeeCreateDto));
            }

            var employeeCreateModel = _mapper.Map<EmployeeCreateModel>(employeeCreateDto);

            var createdEmployeeModel = await _employeeRepository.CreateEmployeeAsync(employeeCreateModel);

            var createdEmployeeViewDto = _mapper.Map<EmployeeViewDto>(createdEmployeeModel);

            return createdEmployeeViewDto;
        }

        public async Task AddEmployeeSkillAsync(int employeeId, int skillId)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeId)
                ?? throw new NotFoundException("Employee was not found.");

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillId)
                ?? throw new NotFoundException("Skill was not found.");

            await _employeeSkillRepository.AddEmployeeSkillAsync(employeeId, skillId);
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto)
        {
            if (employeeUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(employeeUpdateDto));
            }

            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeUpdateDto.Id)
                ?? throw new NotFoundException("Employee was not found.");

            var employeeUpdateModel = _mapper.Map<EmployeeUpdateModel>(employeeUpdateDto);

            await _employeeRepository.UpdateEmployeeAsync(employeeUpdateModel);
        }

        public async Task ConfirmEmployeeSkillAsync(int employeeId, int skillId)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeId)
                ?? throw new NotFoundException("Employee was not found.");

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillId)
                ?? throw new NotFoundException("Skill was not found.");

            await _employeeSkillRepository.ConfirmEmployeeSkillAsync(employeeId, skillId);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(id)
                ?? throw new NotFoundException("Employee was not found.");

            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task DeleteEmployeeSkillAsync(int employeeId, int skillId)
        {
            var existingEmployeeModel = await _employeeRepository.GetEmployeeByIdAsync(employeeId)
                ?? throw new NotFoundException("Employee was not found.");

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillId)
                ?? throw new NotFoundException("Skill was not found.");

            await _employeeSkillRepository.DeleteEmployeeSkillAsync(employeeId, skillId);
        }
    }
}
