using AccountsMS.Business.DTOs.Employee;
using AccountsMS.Business.Exceptions;
using AccountsMS.Data.Models.Employee;
using AccountsMS.Data.Repositories.Contracts;
using AutoMapper;
using Kafka.Contracts;

namespace AccountsMS.Business.MessageHandlers
{
    public class EmployeeMessageHandler : IKafkaConsumerHandler<string, EmployeeMessageDto>
    {
        private IEmployeeRepository _employeeRepository;
        private IOrganizationRepository _organizationRepository;
        private IMapper _mapper;

        public EmployeeMessageHandler(IEmployeeRepository employeeRepository, IOrganizationRepository organizationRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task HandleAsync(string key, EmployeeMessageDto value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var existingEmployee = _employeeRepository.GetEmployeeByEmailAsync(value.Email)
                ?? throw new AlreadyExistsException("User already exists.");

            if (value.OrganizationId != null)
            {
                var existingOrganization = _organizationRepository.GetOrganizationByIdAsync((int)value.OrganizationId) ?? throw new NotFoundException("Organization was not found.");
            }

            var employeeCreateModel = _mapper.Map<EmployeeCreateModel>(value);

            await _employeeRepository.CreateEmployeeAsync(employeeCreateModel);
        }
    }
}
