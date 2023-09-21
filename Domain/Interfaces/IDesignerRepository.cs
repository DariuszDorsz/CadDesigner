using CadDesigner.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Domain.Interfaces
{
    public interface IDesignerRepository
    {
        public Task Create(Designer designer);
        public Task<Designer> GetById(int id);
        public Task Update(Designer designer);
        public Task Delete(Designer designer);
        public Task<IEnumerable<Designer>> GetAll();
    }
}
