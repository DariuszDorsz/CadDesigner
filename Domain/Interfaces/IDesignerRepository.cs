using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Models;

namespace CadDesigner.Domain.Interfaces
{
    public interface IDesignerRepository
    {
        Task Create(Designer designer);
        Task<Designer> GetById(int id);
        Task Update(Designer designer);
        Task Delete(Designer designer);
        IQueryable<Designer> GetAll();
        Task<IEnumerable<Designer>> GetPaginationResult(IQueryable<Designer> basequery, DesignerQuery query);
    }
}
