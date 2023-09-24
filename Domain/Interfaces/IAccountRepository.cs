using CadDesigner.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task Register(User user);
        Task<User> GetUser(string email);
    }
}
