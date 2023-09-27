using CadDesigner.Aplication.DtoModels;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Interfaces;
using CadDesigner.Domain.Models;
using CadDesigner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace CadDesigner.Infrastructure.Repositories
{
    internal class DesignerRepository : IDesignerRepository
    {
        private readonly DesignerDbContext _dbContext;

        public DesignerRepository(DesignerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(Designer designer)
        {
            _dbContext.Designers.Add(designer);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Update(Designer designer)
        {
            _dbContext.Designers.Update(designer);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(Designer designer)
        {
            _dbContext.Designers.Remove(designer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Designer> GetById(int id)
        {
            var designer = await _dbContext
            .Designers
            .Include(r => r.Address)
            .Include(r => r.Services)
            .FirstOrDefaultAsync(r => r.Id == id);

            return designer;
        }


        public IQueryable<Designer> GetAll()
        {
            var designer = _dbContext
                           .Designers
                           .Include(r => r.Address)
                           .Include(r => r.Services);

            return designer;
        }


        public async Task<IEnumerable<Designer>> GetPaginationResult(IQueryable<Designer> basequery, DesignerQuery query)
        {
            var designer = await basequery.Skip(query.PageSize * (query.PageNumber - 1))
                                          .Take(query.PageSize).ToListAsync();

            return designer;
        }
    }
}
