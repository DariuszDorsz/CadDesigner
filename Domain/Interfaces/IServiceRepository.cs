using CadDesigner.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task CreateAsync(Service service);
        Task<Service?> GetByIdAsync(int id);
        Task RemoveAllAsync(IEnumerable<Service> services);
        Task DeleteAsync(Service service);
    }
}
