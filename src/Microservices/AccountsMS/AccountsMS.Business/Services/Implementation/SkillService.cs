using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Exceptions;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.Data.Models.Skill;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;

namespace AccountsMS.Business.Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SkillViewDto>> GetAllSkillsAsync()
        {
            var skillsModels = await _skillRepository.GetAllSkillsAsync();

            var skillsViewDtos = _mapper.Map<IEnumerable<SkillViewDto>>(skillsModels);

            return skillsViewDtos;
        }

        public async Task<SkillViewDto> GetSkillByIdAsync(int id)
        {
            var skillModel = await _skillRepository.GetSkillByIdAsync(id)
                ?? throw new NotFoundException("Skill was not found.");

            var skillViewDto = _mapper.Map<SkillViewDto>(skillModel);

            return skillViewDto;
        }

        public async Task<SkillViewDto> CreateSkillAsync(SkillCreateDto skillCreateDto)
        {
            if (skillCreateDto == null)
            {
                throw new ArgumentNullException(nameof(skillCreateDto));
            }

            var skillCreateModel = _mapper.Map<SkillCreateModel>(skillCreateDto);

            var createdSkillModel = await _skillRepository.CreateSkillAsync(skillCreateModel);

            var createdSkillViewDto = _mapper.Map<SkillViewDto>(createdSkillModel);

            return createdSkillViewDto;
        }

        public async Task UpdateSkillAsync(SkillUpdateDto skillUpdateDto)
        {
            if (skillUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(skillUpdateDto));
            }

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillUpdateDto.Id)
                ?? throw new NotFoundException("Skill was not found.");

            var skillUpdateModel = _mapper.Map<SkillUpdateModel>(skillUpdateDto);

            await _skillRepository.UpdateSkillAsync(skillUpdateModel);
        }

        public async Task DeleteSkillAsync(int id)
        {
            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(id)
                ?? throw new NotFoundException("Skill was not found.");

            await _skillRepository.DeleteSkillAsync(id);
        }
    }
}
