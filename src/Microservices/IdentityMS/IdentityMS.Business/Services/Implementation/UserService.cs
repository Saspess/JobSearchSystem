using AutoMapper;
using IdentityMS.Business.DTOs.Employee;
using IdentityMS.Business.DTOs.Organization;
using IdentityMS.Business.DTOs.User;
using IdentityMS.Business.Response.Enums;
using IdentityMS.Business.Response.Generic;
using IdentityMS.Business.Response.NonGeneric;
using IdentityMS.Business.Services.Contracts;
using IdentityMS.Data.Entities;
using IdentityMS.Data.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IdentityMS.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration, IMapper mapper, IUserRepository userRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<UserViewDto>>> GetAllUsersAsync()
        {
            var usersEntities = await _userRepository.GetAllUsersAsync();

            var usersViewDtos = _mapper.Map<IEnumerable<UserViewDto>>(usersEntities);

            return Result<IEnumerable<UserViewDto>>.Successed(usersViewDtos);
        }

        public async Task<Result<UserViewDto>> RegisterEmployeeAsync(EmployeeRegisterDto employeeRegisterDto)
        {
            if (employeeRegisterDto == null)
            {
                return Result<UserViewDto>.Failed(IdentityMSErrorCodes.NullArgument, nameof(employeeRegisterDto));
            }

            var existedUser = await _userRepository.GetUserByEmailAsync(employeeRegisterDto.Email);

            if (existedUser != null)
            {
                return Result<UserViewDto>.Failed(IdentityMSErrorCodes.UserExists, existedUser.Email);
            }

            var employeeMessageDto = _mapper.Map<EmployeeMessageDto>(employeeRegisterDto);

            var userEntity = _mapper.Map<UserEntity>(employeeRegisterDto);

            var createdUser = await _userRepository.CreateUserAsync(userEntity);

            var userViewDto = _mapper.Map<UserViewDto>(createdUser);

            return Result<UserViewDto>.Successed(userViewDto);
        }

        public async Task<Result<UserViewDto>> RegisterOrganizationAsync(OrganizationRegisterDto organizationRegisterDto)
        {
            if (organizationRegisterDto == null)
            {
                return Result<UserViewDto>.Failed(IdentityMSErrorCodes.NullArgument, nameof(organizationRegisterDto));
            }

            var existedUser = await _userRepository.GetUserByEmailAsync(organizationRegisterDto.Email);

            if (existedUser != null)
            {
                return Result<UserViewDto>.Failed(IdentityMSErrorCodes.UserExists, existedUser.Email);
            }

            var organizationMessageDto = _mapper.Map<OrganizationMessageDto>(organizationRegisterDto);

            var userEntity = _mapper.Map<UserEntity>(organizationRegisterDto);

            var createdUser = await _userRepository.CreateUserAsync(userEntity);

            var userViewDto = _mapper.Map<UserViewDto>(createdUser);

            return Result<UserViewDto>.Successed(userViewDto);
        }

        public async Task<Result<string>> LoginAsync(UserLoginDto userLoginDto)
        {
            if (userLoginDto == null)
            {
                return Result<string>.Failed(IdentityMSErrorCodes.NullArgument, nameof(userLoginDto));
            }

            var user = await AuthenticateAsync(userLoginDto);

            if (user == null)
            {
                return Result<string>.Failed(IdentityMSErrorCodes.LoginFailed, "Wrong email or password.");
            }

            var token = Generate(user);

            return Result<string>.Successed(token);
        }

        public async Task<Result> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto == null)
            {
                return Result.Failed(IdentityMSErrorCodes.NullArgument, nameof(userUpdateDto));
            }

            var existingUserEntity = await _userRepository.GetUserByIdAsync(userUpdateDto.Id);

            if (existingUserEntity == null)
            {
                return Result.Failed(IdentityMSErrorCodes.EntityNotFound, "User not found.");
            }

            var userEntity = _mapper.Map<UserEntity>(userUpdateDto);

            await _userRepository.UpdateUserAsync(userEntity);

            return Result.Successed();
        }

        public async Task<Result> DeleteUserAsync(int id)
        {
            var existingUserEntity = await _userRepository.GetUserByIdAsync(id);

            if (existingUserEntity == null)
            {
                return Result.Failed(IdentityMSErrorCodes.EntityNotFound, "User not found.");
            }

            await _userRepository.DeleteUserAsync(id);

            return Result.Successed();
        }

        private string Generate(UserAuthenticateDto userAuthenticateModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, userAuthenticateModel.Email),
                new Claim(ClaimTypes.Role, userAuthenticateModel.Role.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserAuthenticateDto?> AuthenticateAsync(UserLoginDto userLoginDto)
        {
            var currentUser = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);

            if (currentUser == null)
            {
                return null;
            }

            if (currentUser.Password != GetPasswordHash(userLoginDto.Password))
            {
                return null;
            }

            var userAuthenticateDto = _mapper.Map<UserAuthenticateDto>(currentUser);

            return userAuthenticateDto;
        }

        private string GetPasswordHash(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var hashValue = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashValue);
            }
        }
    }
}
