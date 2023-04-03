using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Business.Services.Implementation;
using AccountsMS.Data.Models.Organization;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;
using Moq;

namespace AccountsMS.Tests.UnitTests.ServicesTests
{
    public class OrganizationServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IOrganizationRepository> _organizationRepositoryMock;

        private readonly IOrganizationService _organizationService;

        public OrganizationServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _organizationRepositoryMock = new Mock<IOrganizationRepository>();

            _organizationService = new OrganizationService(_organizationRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllOrganizations_WhenOrganizationsExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var organizationsModels = ServicesDataFactory.GetAllOrganizationsModels();
            _organizationRepositoryMock.Setup(r => r.GetAllOrganizationsAsync()).ReturnsAsync(organizationsModels);

            var organizationsViewDtos = ServicesDataFactory.GetAllOrganizationsViewDtos();
            _mapperMock.Setup(m => m.Map<IEnumerable<OrganizationViewDto>>(organizationsModels)).Returns(organizationsViewDtos);

            //Act
            var result = await _organizationService.GetAllOrganizationsAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetOrganizationById_WhenOrganizationExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var organizationModel = ServicesDataFactory.GetOrganizationModel();
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByIdAsync(organizationModel.Id)).ReturnsAsync(organizationModel);

            var organizationViewDto = ServicesDataFactory.GetOrganizationViewDto();
            _mapperMock.Setup(m => m.Map<OrganizationViewDto>(organizationModel)).Returns(organizationViewDto);

            //Act
            var result = await _organizationService.GetOrganizationByIdAsync(organizationModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetOrganizationById_WhenOrganizationDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentId = 1;
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByIdAsync(nonexistentId)).ReturnsAsync(default(OrganizationModel));

            //Act
            var result = await _organizationService.GetOrganizationByIdAsync(nonexistentId);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task GetOrganizationByEmail_WhenOrganizationExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var organizationModel = ServicesDataFactory.GetOrganizationModel();
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByEmailAsync(organizationModel.Email)).ReturnsAsync(organizationModel);

            var employeeViewDto = ServicesDataFactory.GetOrganizationViewDto();
            _mapperMock.Setup(m => m.Map<OrganizationViewDto>(organizationModel)).Returns(employeeViewDto);

            //Act
            var result = await _organizationService.GetOrganizationByEmailAsync(organizationModel.Email);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetOrganizationByEmail_WhenOrganizationDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentEmail = "bestsoft1@gmail.com";
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByEmailAsync(nonexistentEmail)).ReturnsAsync(default(OrganizationModel));

            //Act
            var result = await _organizationService.GetOrganizationByEmailAsync(nonexistentEmail);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task CreateOrganization_WhenOrganizationDoNotExists_ShouldReturnSuccessResult()
        {
            var organizationCreateDto = ServicesDataFactory.GetOrganizationCreateDto();
            var organizationCreateModel = ServicesDataFactory.GetOrganizationCreateModel();
            _mapperMock.Setup(m => m.Map<OrganizationCreateModel>(organizationCreateDto)).Returns(organizationCreateModel);

            var organizationModel = ServicesDataFactory.GetOrganizationModel();
            _organizationRepositoryMock.Setup(r => r.CreateOrganizationAsync(organizationCreateModel)).ReturnsAsync(organizationModel);

            var skillViewDto = ServicesDataFactory.GetOrganizationViewDto();
            _mapperMock.Setup(m => m.Map<OrganizationViewDto>(organizationCreateDto)).Returns(skillViewDto);

            //Act
            var result = await _organizationService.CreateOrganizationAsync(organizationCreateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateOrganization_WhenOrganizationExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var organizationModel = ServicesDataFactory.GetOrganizationModel();
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByIdAsync(organizationModel.Id)).ReturnsAsync(organizationModel);

            var organizationUpdateModel = ServicesDataFactory.GetOrganizationUpdateModel();
            var organizationUpdateDto = ServicesDataFactory.GetOrganizationUpdateDto();
            _mapperMock.Setup(m => m.Map<OrganizationUpdateModel>(organizationUpdateDto)).Returns(organizationUpdateModel);

            //Act
            var result = await _organizationService.UpdateOrganizationAsync(organizationUpdateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateOrganization_WhenOrganizationDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var organizationUpdateModel = ServicesDataFactory.GetOrganizationUpdateModel();
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByIdAsync(organizationUpdateModel.Id)).ReturnsAsync(default(OrganizationModel));

            var organizationUpdateDto = ServicesDataFactory.GetOrganizationUpdateDto();
            _mapperMock.Setup(m => m.Map<OrganizationUpdateModel>(organizationUpdateDto)).Returns(organizationUpdateModel);

            //Act
            var result = await _organizationService.UpdateOrganizationAsync(organizationUpdateDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteOrganization_WhenOrganizationExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var organizationModel = ServicesDataFactory.GetOrganizationModel();
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByIdAsync(organizationModel.Id)).ReturnsAsync(organizationModel);

            //Act
            var result = await _organizationService.DeleteOrganizationAsync(organizationModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteOrganization_WhenOrganizationDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentId = 1;
            _organizationRepositoryMock.Setup(r => r.GetOrganizationByIdAsync(nonexistentId)).ReturnsAsync(default(OrganizationModel));

            //Act
            var result = await _organizationService.DeleteOrganizationAsync(nonexistentId);

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}
