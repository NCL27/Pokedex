using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Domain.Entities;
using Pokedex.Core.Application.Interfaces.Repositories;

namespace Application.Repository
{
    public class TypeRepository : GenericRepository<Types>, ITypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public TypeRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
