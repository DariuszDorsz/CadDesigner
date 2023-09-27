using CadDesigner.Aplication.DtoModels;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using CadDesigner.Infrastructure.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Infrastructure.Validators
{
    internal class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly DesignerDbContext _dbContext;
        public RegisterUserDtoValidator(DesignerDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().Custom((value, context) =>
                {
                    var emailInUse = _dbContext.Users.Any(u=>u.Email==value);

                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
        }
    }
}
