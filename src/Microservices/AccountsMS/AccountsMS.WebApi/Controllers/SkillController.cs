using AccountsMS.Business.DTOs.Skill;
using AccountsMS.Business.Services.Contracts;
using AccountsMS.WebApi.Response.Generic;
using AccountsMS.WebApi.Response.NonGeneric;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountsMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : BaseAccountsMSController
    {
        private ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<JssResult<IEnumerable<SkillViewDto>>> GetAllSkillsAsync()
        {
            var result = await _skillService.GetAllSkillsAsync();

            if (result.IsSuccess == false)
            {
                return Failed<IEnumerable<SkillViewDto>>(result.ErrorCode);
            }

            return Succesed<IEnumerable<SkillViewDto>>(result.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<JssResult<SkillViewDto>> GetSkillByIdAsync([FromRoute] int id)
        {
            var result = await _skillService.GetSkillByIdAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed<SkillViewDto>(result.ErrorCode);
            }

            return Succesed<SkillViewDto>(result.Value);
        }

        [HttpPost]
        public async Task<JssResult<SkillViewDto>> CreateSkillAsync([FromBody] SkillCreateDto skillCreateDto)
        {
            var result = await _skillService.CreateSkillAsync(skillCreateDto);

            if (result.IsSuccess == false)
            {
                return Failed<SkillViewDto>(result.ErrorCode);
            }

            return Succesed<SkillViewDto>(result.Value);
        }

        [HttpPut]
        public async Task<JssResult> UpdateSkillAsync([FromBody] SkillUpdateDto skillUpdateDto)
        {
            var result = await _skillService.UpdateSkillAsync(skillUpdateDto);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }

        [HttpDelete("{id:int}")]
        public async Task<JssResult> DeleteSkillAsync([FromRoute] int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);

            if (result.IsSuccess == false)
            {
                return Failed(result.ErrorCode);
            }

            return Succesed();
        }
    }
}
