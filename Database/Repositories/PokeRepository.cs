using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Domain.Entities;
using Pokedex.Core.Application.Interfaces.Repositories;

namespace Application.Repository
{
    public class PokeRepository : GenericRepository<Pokemons>, IPokeRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokeRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

