using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using CadDesigner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace CadDesigner.Infrastructure.Repositories
{
    internal class ServiceRepositor : IServiceRepository
    {
        private readonly DesignerDbContext _dbContext;


        public ServiceRepositor(DesignerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(Service service)
        {
            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Service> GetById(int id)
        {
            var designer = await _dbContext
            .Services
            .FirstOrDefaultAsync(r => r.Id == id);

            return designer;
        }


        public async Task RemoveAll (IEnumerable<Service> services)
        {
            _dbContext.Services.RemoveRange(services);

            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(Service service)
        {
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Update(Service service)
        {
            _dbContext.Services.Update(service);
            await _dbContext.SaveChangesAsync();
        }
    }
}