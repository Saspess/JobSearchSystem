using AccountsMS.Business.DTOs.Organization;
using AccountsMS.Business.Exceptions;
using AccountsMS.Data.Models.Employee;
using AccountsMS.Data.Models.Organization;
using AccountsMS.Data.Repositories.Contracts;
using AccountsMS.Data.Repositories.Implementation;
using AutoMapper;
using Kafka.Contracts;

namespace AccountsMS.Business.MessageHandlers
{
    public class OrganizationMessageHandler : IKafkaConsumerHandler<string, OrganizationMessageDto>
    {
        private IOrganizationRepository _organizationRepository;
        private IMapper _mapper;

        public OrganizationMessageHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task HandleAsync(string key, OrganizationMessageDto value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var existingOrganization = _organizationRepository.GetOrganizationByEmailAsync(value.Email)
                ?? throw new AlreadyExistsException("Organization already exists.");

            var organizationCreateModel = _mapper.Map<OrganizationCreateModel>(value);

            await _organizationRepository.CreateOrganizationAsync(organizationCreateModel);
        }
    }
}
