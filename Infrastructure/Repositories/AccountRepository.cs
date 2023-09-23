using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using CadDesigner.Infrastructure.Persistence;
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


        public void Register(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChangesAsync();
        }
    }
}
