using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Exceptions;
using CadDesigner.Aplication.Setings;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUserDto dto);
        Task<string> GenerateJwt(LoginDto dto);
    }


    public class AccountService : IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly AuthenticationSettings _authenticationSettings;


        public AccountService(IPasswordHasher<User> passwordHasher, IAccountRepository accountRepository, AuthenticationSettings authenticationSetings)
        {
            _authenticationSettings = authenticationSetings;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
        }


        public async Task RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            await _accountRepository.Register(newUser);
        }


        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var user = await _accountRepository.GetUser(dto.Email) ?? throw new NotFoundException("Designer not found");


            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
