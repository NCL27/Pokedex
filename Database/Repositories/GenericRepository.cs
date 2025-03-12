using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Application.Interfaces.Repositories;

namespace Application.Repository
{
    //Generics
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        private readonly ApplicationContext _dbContext;
        
        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Entity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync(); //Deferred execution
        }
        public async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<Entity>().AsQueryable();
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
        public async Task<Entity> GetByIdAsyns(int Id)
        {
            return await _dbContext.Set<Entity>().FindAsync(Id);
        }
    }
}

