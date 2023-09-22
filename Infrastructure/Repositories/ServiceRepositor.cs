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
    internal class ServiceRepositor : IServiceRepository
    {
        private readonly DesignerDbContext _dbContext;


        public ServiceRepositor(DesignerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateAsync(Service service)
        {
            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Service?> GetByIdAsync(int id)
        {
            var designer = await _dbContext
            .Services
            .FirstOrDefaultAsync(r => r.Id == id);

            return designer;
        }


        public async Task RemoveAllAsync (IEnumerable<Service> services)
        {
            _dbContext.Services.RemoveRange(services);

            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(Service service)
        {
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(Service service)
        {
            _dbContext.Services.Update(service);
            await _dbContext.SaveChangesAsync();
        }
    }
}