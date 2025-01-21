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
    public class TypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public TypeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Types types)
        {
            await _dbContext.Types.AddAsync(types);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Types types)
        {
            _dbContext.Entry(types).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Types types)
        {
            _dbContext.Set<Types>().Remove(types);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Types>> GetAllAsync()
        {
            return await _dbContext.Set<Types>().ToListAsync();
        }
        public async Task<Types> GetByIdAsyns(int Id)
        {
            return await _dbContext.Set<Types>().FindAsync(Id);
        }

    }
}
