using CadDesigner.Domain.Entitys;


namespace CadDesigner.Domain.Interfaces
{
    public interface IDesignerRepository
    {
        Task Create(Designer designer);
        Task<Designer?> GetById(int id);
        Task Update(Designer designer);
        Task Delete(Designer designer);
        Task<IEnumerable<Designer>> GetAll();
    }
}
