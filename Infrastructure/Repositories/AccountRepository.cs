using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using CadDesigner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Infrastructure.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly DesignerDbContext _dbContext;

        public AccountRepository(DesignerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Register(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<User?> GetUser(string email)
        {
          var user = await _dbContext.Users
                    .Include(r => r.Role)
                    .FirstOrDefaultAsync(u=>u.Email==email);

            return user;
        }



    }
}
