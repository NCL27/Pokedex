using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;

namespace Application.Repository
{
    public class RegiRepository : GenericRepository<Regions>, IRegiRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegiRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
       
    }
}
 