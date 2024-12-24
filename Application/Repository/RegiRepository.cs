using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegiRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegiRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Regions regions)
        {
            await _dbContext.Regions.AddAsync(regions);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Regions regions)
        {
            _dbContext.Entry(regions).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Regions regions)
        {
            _dbContext.Set<Regions>().Remove(regions);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Regions>> GetAllAsync()
        {
            return await _dbContext.Set<Regions>().ToListAsync();
        }
        public async Task<Regions> GetByIdAsyns(int id)
        {
            return await _dbContext.Set<Regions>().FindAsync(id);
        }

        internal async Task<IEnumerable<object>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
         
        internal async Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
