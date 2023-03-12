using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Exceptions;
using AccountsMS.Business.Responce.Enums;
using AccountsMS.Business.Responce.NonGeneric;
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

        public async Task<Result> GetAllSkillsAsync()
        {
            var skillsModels = await _skillRepository.GetAllSkillsAsync();

            var skillsViewDtos = _mapper.Map<IEnumerable<SkillViewDto>>(skillsModels);

            return Result<IEnumerable<SkillViewDto>>.Successed(skillsViewDtos);
        }

        public async Task<Result> GetSkillByIdAsync(int id)
        {
            var skillModel = await _skillRepository.GetSkillByIdAsync(id);

            if(skillModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Skill not found.");
            }

            var skillViewDto = _mapper.Map<SkillViewDto>(skillModel);

            return Result<SkillViewDto>.Successed(skillViewDto);
        }

        public async Task<Result> CreateSkillAsync(SkillCreateDto skillCreateDto)
        {
            if (skillCreateDto == null)
            {
                return Result.Failed(AccountsMSErrorCodes.NullArgument, nameof(skillCreateDto));
            }

            var skillCreateModel = _mapper.Map<SkillCreateModel>(skillCreateDto);

            var createdSkillModel = await _skillRepository.CreateSkillAsync(skillCreateModel);

            var createdSkillViewDto = _mapper.Map<SkillViewDto>(createdSkillModel);

            return Result<SkillViewDto>.Successed(createdSkillViewDto);
        }

        public async Task<Result> UpdateSkillAsync(SkillUpdateDto skillUpdateDto)
        {
            if (skillUpdateDto == null)
            {
                return Result.Failed(AccountsMSErrorCodes.NullArgument, nameof(skillUpdateDto));
            }

            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(skillUpdateDto.Id);

            if (existingSkillModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Skill not found.");
            }

            var skillUpdateModel = _mapper.Map<SkillUpdateModel>(skillUpdateDto);

            await _skillRepository.UpdateSkillAsync(skillUpdateModel);

            return Result.Successed();
        }

        public async Task<Result> DeleteSkillAsync(int id)
        {
            var existingSkillModel = await _skillRepository.GetSkillByIdAsync(id);

            if (existingSkillModel == null)
            {
                return Result.Failed(AccountsMSErrorCodes.EntityNotFound, "Skill not found.");
            }

            await _skillRepository.DeleteSkillAsync(id);

            return Result.Successed();
        }
    }
}
