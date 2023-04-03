using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.DTOs.EmployeeSkill;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Business.Services.Implementation;
using AccountsMS.Data.Models.Employee;
using AccountsMS.Data.Models.Skill;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;
using Moq;

namespace AccountsMS.Tests.UnitTests.ServicesTests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly Mock<IEmployeeSkillRepository> _employeeSkillRepositoryMock;
        private readonly Mock<ISkillRepository> _skillRepositoryMock;

        private readonly IEmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeSkillRepositoryMock = new Mock<IEmployeeSkillRepository>();
            _skillRepositoryMock = new Mock<ISkillRepository>();

            _employeeService = new EmployeeService(_employeeRepositoryMock.Object, _employeeSkillRepositoryMock.Object, _skillRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllEmployees_WhenEmployeesExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeesModels = ServicesDataFactory.GetAllEmployeesModels();
            _employeeRepositoryMock.Setup(r => r.GetAllEmployeesAsync()).ReturnsAsync(employeesModels);

            var employeesViewDtos = ServicesDataFactory.GetAllEmployeesViewDtos();
            _mapperMock.Setup(m => m.Map<IEnumerable<EmployeeViewDto>>(employeesModels)).Returns(employeesViewDtos);

            //Act
            var result = await _employeeService.GetAllEmployeesAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetEmployeesBySkillName_WhenEmployeesExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeesModels = ServicesDataFactory.GetAllEmployeesModels();
            var skillName = ".NET";
            _employeeRepositoryMock.Setup(r => r.GetEmployeesBySkillNameAsync(skillName)).ReturnsAsync(employeesModels);

            var employeesViewDtos = ServicesDataFactory.GetAllEmployeesViewDtos();
            _mapperMock.Setup(m => m.Map<IEnumerable<EmployeeViewDto>>(employeesModels)).Returns(employeesViewDtos);

            //Act
            var result = await _employeeService.GetEmployeesBySkillNameAsync(skillName);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetAllEmployeeSkills_WhenEmployeeExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeModel.Id)).ReturnsAsync(employeeModel);

            var employeesSkillModels = ServicesDataFactory.GetAllEmployeesSkillModels();
            _employeeSkillRepositoryMock.Setup(r => r.GetAllEmployeeSkillsAsync(employeeModel.Id)).ReturnsAsync(employeesSkillModels);

            var employeesSkillViewDtos = ServicesDataFactory.GetAllEmployeesSkillViewDtos();
            _mapperMock.Setup(m => m.Map<IEnumerable<EmployeeSkillViewDto>>(employeesSkillModels)).Returns(employeesSkillViewDtos);

            //Act
            var result = await _employeeService.GetAllEmployeeSkillsAsync(employeeModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetEmployeeById_WhenEmployeeExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeModel.Id)).ReturnsAsync(employeeModel);

            var employeeViewDto = ServicesDataFactory.GetEmployeeViewDto();
            _mapperMock.Setup(m => m.Map<EmployeeViewDto>(employeeModel)).Returns(employeeViewDto);

            //Act
            var result = await _employeeService.GetEmployeeByIdAsync(employeeModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetEmployeeById_WhenEmployeeDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentId = 1;
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(nonexistentId)).ReturnsAsync(default(EmployeeModel));

            //Act
            var result = await _employeeService.GetEmployeeByIdAsync(nonexistentId);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task GetEmployeeByEmail_WhenEmployeeExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByEmailAsync(employeeModel.Email)).ReturnsAsync(employeeModel);

            var employeeViewDto = ServicesDataFactory.GetEmployeeViewDto();
            _mapperMock.Setup(m => m.Map<EmployeeViewDto>(employeeModel)).Returns(employeeViewDto);

            //Act
            var result = await _employeeService.GetEmployeeByEmailAsync(employeeModel.Email);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetEmployeeByEmail_WhenEmployeeDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentEmail = "johndoe1@gmail.com";
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByEmailAsync(nonexistentEmail)).ReturnsAsync(default(EmployeeModel));

            //Act
            var result = await _employeeService.GetEmployeeByEmailAsync(nonexistentEmail);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task CreateEmployee_WhenEmployeeDoNotExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeCreateDto = ServicesDataFactory.GetEmployeeCreateDto();
            var employeeCreateModel = ServicesDataFactory.GetEmployeeCreateModel();
            _mapperMock.Setup(m => m.Map<EmployeeCreateModel>(employeeCreateDto)).Returns(employeeCreateModel);

            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.CreateEmployeeAsync(employeeCreateModel)).ReturnsAsync(employeeModel);

            var employeeViewDto = ServicesDataFactory.GetEmployeeViewDto();
            _mapperMock.Setup(m => m.Map<EmployeeViewDto>(employeeCreateDto)).Returns(employeeViewDto);

            //Act
            var result = await _employeeService.CreateEmployeeAsync(employeeCreateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task AddEmployeeSkill_WhenEmployeeExistsAndSkillExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(employeeModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(skillModel);

            //Act
            var result = await _employeeService.AddEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task AddEmployeeSkill_WhenEmployeeDoNotExistsAndSkillExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(default(EmployeeModel));

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(skillModel);

            //Act
            var result = await _employeeService.AddEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task AddEmployeeSkill_WhenEmployeeExistsAndDoNotSkillExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(employeeModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(default(SkillModel));

            //Act
            var result = await _employeeService.AddEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateEmployee_WhenEmployeeExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeModel.Id)).ReturnsAsync(employeeModel);

            var employeeUpdateModel = ServicesDataFactory.GetEmployeeUpdateModel();
            var employeeUpdateDto = ServicesDataFactory.GetEmployeeUpdateDto();
            _mapperMock.Setup(m => m.Map<EmployeeUpdateModel>(employeeUpdateDto)).Returns(employeeUpdateModel);

            //Act
            var result = await _employeeService.UpdateEmployeeAsync(employeeUpdateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateEmployee_WhenEmployeeDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeUpdateModel = ServicesDataFactory.GetEmployeeUpdateModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeUpdateModel.Id)).ReturnsAsync(default(EmployeeModel));

            var employeeUpdateDto = ServicesDataFactory.GetEmployeeUpdateDto();
            _mapperMock.Setup(m => m.Map<EmployeeUpdateModel>(employeeUpdateDto)).Returns(employeeUpdateModel);

            //Act
            var result = await _employeeService.UpdateEmployeeAsync(employeeUpdateDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task ConfirmEmployeeSkill_WhenEmployeeExistsAndSkillExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(employeeModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(skillModel);

            //Act
            var result = await _employeeService.ConfirmEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ConfirmEmployeeSkill_WhenEmployeeDoNotExistsAndSkillExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(default(EmployeeModel));

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(skillModel);

            //Act
            var result = await _employeeService.ConfirmEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task ConfirmEmployeeSkill_WhenEmployeeExistsAndDoNotSkillExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(employeeModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(default(SkillModel));

            //Act
            var result = await _employeeService.ConfirmEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteEmployee_WhenEmployeeExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeModel.Id)).ReturnsAsync(employeeModel);

            //Act
            var result = await _employeeService.DeleteEmployeeAsync(employeeModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteEmployee_WhenEmployeeDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentId = 1;
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(nonexistentId)).ReturnsAsync(default(EmployeeModel));

            //Act
            var result = await _employeeService.DeleteEmployeeAsync(nonexistentId);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteEmployeeSkill_WhenEmployeeExistsAndSkillExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(employeeModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(skillModel);

            //Act
            var result = await _employeeService.DeleteEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteEmployeeSkill_WhenEmployeeDoNotExistsAndSkillExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(default(EmployeeModel));

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(skillModel);

            //Act
            var result = await _employeeService.DeleteEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteEmployeeSkill_WhenEmployeeExistsAndDoNotSkillExists_ShouldReturnFailureResult()
        {
            //Arrange
            var employeeSkillDto = ServicesDataFactory.GetEmployeeSkillDto();
            var employeeModel = ServicesDataFactory.GetEmployeeModel();
            _employeeRepositoryMock.Setup(r => r.GetEmployeeByIdAsync(employeeSkillDto.EmployeeId)).ReturnsAsync(employeeModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(employeeSkillDto.SkillId)).ReturnsAsync(default(SkillModel));

            //Act
            var result = await _employeeService.DeleteEmployeeSkillAsync(employeeSkillDto);

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}
