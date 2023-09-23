using CadDesigner.Aplication.DtoModels;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUserDto dto);
    }

   public class AccountService : IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAccountRepository _accountRepository;


        public AccountService(IPasswordHasher<User> passwordHasher, IAccountRepository accountRepository)
        {
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
    }
}
