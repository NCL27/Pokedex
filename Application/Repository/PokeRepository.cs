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
    public class PokeRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Pokemons pokemons)
        {
            await _dbContext.Pokemons.AddAsync(pokemons);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pokemons pokemons)
        {
            _dbContext.Entry(pokemons).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Pokemons pokemons)
        {
            _dbContext.Set<Pokemons>().Remove(pokemons);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemons>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemons>().ToListAsync();
        }
        public async Task<Pokemons> GetByIdAsyns(int id)
        {
            return await _dbContext.Set<Pokemons>().FindAsync(id);
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

