using AutoMapper;
using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Business.Services.Contracts;
using IdentityMS.Business.Services.Implementation;
using IdentityMS.Data.Entities;
using IdentityMS.Data.Repositories.Contracts;
using Kafka.Contracts;
using Microsoft.Extensions.Configuration;
using Moq;

namespace IdentityMS.Tests.UnitTests.ServicesTests
{
    public class UserServiceTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IKafkaProducer<string, EmployeeMessageDto>> _kafkaEmployeeProducerMock;
        private readonly Mock<IKafkaProducer<string, OrganizationMessageDto>> _kafkaOrganizationProducerMock;


        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _mapperMock = new Mock<IMapper>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _kafkaEmployeeProducerMock = new Mock<IKafkaProducer<string, EmployeeMessageDto>>();
            _kafkaOrganizationProducerMock = new Mock<IKafkaProducer<string, OrganizationMessageDto>>();

            _userService = new UserService(_configurationMock.Object, _mapperMock.Object, _userRepositoryMock.Object, _kafkaEmployeeProducerMock.Object, _kafkaOrganizationProducerMock.Object);
        }

        [Fact]
        public async Task GetAllUsers_WhenUsersExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var usersEntities = ServicesDataFactory.GetAllUsersEntities();
            _userRepositoryMock.Setup(r => r.GetAllUsersAsync()).ReturnsAsync(usersEntities);

            var usersViewDtos = ServicesDataFactory.GetAllUsersViewDtos();
            _mapperMock.Setup(m => m.Map<IEnumerable<UserViewDto>>(usersEntities)).Returns(usersViewDtos);

            //Act
            var result = await _userService.GetAllUsersAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task RegisterEmployee_WhenEmployeeDoNotExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserEmployeeEntity();
            var employeeRegisterDto = ServicesDataFactory.GetEmployeeRegisterDto();
            _userRepositoryMock.Setup(r => r.GetUserByEmailAsync(employeeRegisterDto.Email)).ReturnsAsync(default(UserEntity));

            var employeeMessageDto = ServicesDataFactory.GetEmployeeMessageDto();
            _mapperMock.Setup(m => m.Map<EmployeeMessageDto>(employeeRegisterDto)).Returns(employeeMessageDto);

            _mapperMock.Setup(m => m.Map<UserEntity>(employeeRegisterDto)).Returns(userEntity);

            _userRepositoryMock.Setup(r => r.CreateUserAsync(userEntity)).ReturnsAsync(userEntity);

            var userViewDto = ServicesDataFactory.GetUserViewDto();
            _mapperMock.Setup(m => m.Map<UserViewDto>(userEntity)).Returns(userViewDto);

            //Act
            var result = await _userService.RegisterEmployeeAsync(employeeRegisterDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task RegisterEmployee_WhenEmployeeExists_ShouldReturnFailureResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserEmployeeEntity();
            var employeeRegisterDto = ServicesDataFactory.GetEmployeeRegisterDto();
            _userRepositoryMock.Setup(r => r.GetUserByEmailAsync(employeeRegisterDto.Email)).ReturnsAsync(userEntity);

            var employeeMessageDto = ServicesDataFactory.GetEmployeeMessageDto();
            _mapperMock.Setup(m => m.Map<EmployeeMessageDto>(employeeRegisterDto)).Returns(employeeMessageDto);

            _mapperMock.Setup(m => m.Map<UserEntity>(employeeRegisterDto)).Returns(userEntity);

            _userRepositoryMock.Setup(r => r.CreateUserAsync(userEntity)).ReturnsAsync(userEntity);

            var userViewDto = ServicesDataFactory.GetUserViewDto();
            _mapperMock.Setup(m => m.Map<UserViewDto>(userEntity)).Returns(userViewDto);

            //Act
            var result = await _userService.RegisterEmployeeAsync(employeeRegisterDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task RegisterOrganization_WhenOrganizationDoNotExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserOrganizationEntity();
            var organizationRegisterDto = ServicesDataFactory.GetOrganizationRegisterDto();
            _userRepositoryMock.Setup(r => r.GetUserByEmailAsync(organizationRegisterDto.Email)).ReturnsAsync(default(UserEntity));

            var organizationMessageDto = ServicesDataFactory.GetOrganizationMessageDto();
            _mapperMock.Setup(m => m.Map<OrganizationMessageDto>(organizationRegisterDto)).Returns(organizationMessageDto);

            _mapperMock.Setup(m => m.Map<UserEntity>(organizationRegisterDto)).Returns(userEntity);

            _userRepositoryMock.Setup(r => r.CreateUserAsync(userEntity)).ReturnsAsync(userEntity);

            var userViewDto = ServicesDataFactory.GetUserViewDto();
            _mapperMock.Setup(m => m.Map<UserViewDto>(userEntity)).Returns(userViewDto);

            //Act
            var result = await _userService.RegisterOrganizationAsync(organizationRegisterDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task RegisterOrganization_WhenOrganizationExists_ShouldReturnFailureResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserOrganizationEntity();
            var organizationRegisterDto = ServicesDataFactory.GetOrganizationRegisterDto();
            _userRepositoryMock.Setup(r => r.GetUserByEmailAsync(organizationRegisterDto.Email)).ReturnsAsync(userEntity);

            var organizationMessageDto = ServicesDataFactory.GetOrganizationMessageDto();
            _mapperMock.Setup(m => m.Map<OrganizationMessageDto>(organizationRegisterDto)).Returns(organizationMessageDto);

            _mapperMock.Setup(m => m.Map<UserEntity>(organizationRegisterDto)).Returns(userEntity);

            _userRepositoryMock.Setup(r => r.CreateUserAsync(userEntity)).ReturnsAsync(userEntity);

            var userViewDto = ServicesDataFactory.GetUserViewDto();
            _mapperMock.Setup(m => m.Map<UserViewDto>(userEntity)).Returns(userViewDto);

            //Act
            var result = await _userService.RegisterOrganizationAsync(organizationRegisterDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateUser_WhenUserExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserEntity();
            var userUpdateDto = ServicesDataFactory.GetUserUpdateDto();
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userUpdateDto.Id)).ReturnsAsync(userEntity);

            _mapperMock.Setup(m => m.Map<UserEntity>(userUpdateDto)).Returns(userEntity);

            //Act
            var result = await _userService.UpdateUserAsync(userUpdateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateUser_WhenUserDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserEntity();
            var userUpdateDto = ServicesDataFactory.GetUserUpdateDto();
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userUpdateDto.Id)).ReturnsAsync(default(UserEntity));

            _mapperMock.Setup(m => m.Map<UserEntity>(userUpdateDto)).Returns(userEntity);

            //Act
            var result = await _userService.UpdateUserAsync(userUpdateDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteUser_WhenUserExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserEntity();
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userEntity.Id)).ReturnsAsync(userEntity);

            //Act
            var result = await _userService.DeleteUserAsync(userEntity.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteUser_WhenUserDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var userEntity = ServicesDataFactory.GetUserEntity();
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userEntity.Id)).ReturnsAsync(default(UserEntity));

            //Act
            var result = await _userService.DeleteUserAsync(userEntity.Id);

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}
