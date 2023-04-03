using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Business.Services.Implementation;
using AccountsMS.Data.Models.Skill;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;
using Moq;

namespace AccountsMS.Tests.UnitTests.ServicesTests
{
    public class SkillServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ISkillRepository> _skillRepositoryMock;

        private readonly ISkillService _skillService;

        public SkillServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _skillRepositoryMock = new Mock<ISkillRepository>();

            _skillService = new SkillService(_skillRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllSkills_WhenSkillsExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var skillsModels = ServicesDataFactory.GetAllSkillsModels();
            _skillRepositoryMock.Setup(r => r.GetAllSkillsAsync()).ReturnsAsync(skillsModels);

            var skillsViewDtos = ServicesDataFactory.GetAllSkillsViewDtos();
            _mapperMock.Setup(m => m.Map<IEnumerable<SkillViewDto>>(skillsModels)).Returns(skillsViewDtos);

            //Act
            var result = await _skillService.GetAllSkillsAsync();

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetSkillById_WhenSkillExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(skillModel.Id)).ReturnsAsync(skillModel);

            var skillViewDto = ServicesDataFactory.GetSkillViewDto();
            _mapperMock.Setup(m => m.Map<SkillViewDto>(skillModel)).Returns(skillViewDto);

            //Act
            var result = await _skillService.GetSkillByIdAsync(skillModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetSkillById_WhenSkillDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentId = 1;
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(nonexistentId)).ReturnsAsync(default(SkillModel));

            //Act
            var result = await _skillService.GetSkillByIdAsync(nonexistentId);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task CreateSkill_WhenSkillDoNotExists_ShouldReturnSuccessResult()
        {
            var skillCreateDto = ServicesDataFactory.GetSkillCreateDto();
            var skillCreateModel = ServicesDataFactory.GetSkillCreateModel();
            _mapperMock.Setup(m => m.Map<SkillCreateModel>(skillCreateDto)).Returns(skillCreateModel);

            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.CreateSkillAsync(skillCreateModel)).ReturnsAsync(skillModel);

            var skillViewDto = ServicesDataFactory.GetSkillViewDto();
            _mapperMock.Setup(m => m.Map<SkillViewDto>(skillCreateDto)).Returns(skillViewDto);

            //Act
            var result = await _skillService.CreateSkillAsync(skillCreateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateSkill_WhenSkillExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(skillModel.Id)).ReturnsAsync(skillModel);

            var skillUpdateModel = ServicesDataFactory.GetSkillUpdateModel();
            var skillUpdateDto = ServicesDataFactory.GetSkillUpdateDto();
            _mapperMock.Setup(m => m.Map<SkillUpdateModel>(skillUpdateDto)).Returns(skillUpdateModel);

            //Act
            var result = await _skillService.UpdateSkillAsync(skillUpdateDto);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task UpdateSkill_WhenSkillDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var skillUpdateModel = ServicesDataFactory.GetSkillUpdateModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(skillUpdateModel.Id)).ReturnsAsync(default(SkillModel));

            var skillUpdateDto = ServicesDataFactory.GetSkillUpdateDto();
            _mapperMock.Setup(m => m.Map<SkillUpdateModel>(skillUpdateDto)).Returns(skillUpdateModel);

            //Act
            var result = await _skillService.UpdateSkillAsync(skillUpdateDto);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteSkill_WhenSkillExists_ShouldReturnSuccessResult()
        {
            //Arrange
            var skillModel = ServicesDataFactory.GetSkillModel();
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(skillModel.Id)).ReturnsAsync(skillModel);

            //Act
            var result = await _skillService.DeleteSkillAsync(skillModel.Id);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteSkill_WhenSkillDoNotExists_ShouldReturnFailureResult()
        {
            //Arrange
            var nonexistentId = 1;
            _skillRepositoryMock.Setup(r => r.GetSkillByIdAsync(nonexistentId)).ReturnsAsync(default(SkillModel));

            //Act
            var result = await _skillService.DeleteSkillAsync(nonexistentId);

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}
