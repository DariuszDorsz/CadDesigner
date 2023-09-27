using CadDesigner.Domain.Entitys;


namespace CadDesigner.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task Create(Service service);
        Task<Service> GetById(int id);
        Task RemoveAll(IEnumerable<Service> services);
        Task Delete(Service service);
    }
}
