using Pokedex.Core.Application.ViewModels.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IPokeService : IGenericService<SavePokeViewModel, PokeViewModel>
    {
        Task<List<PokeViewModel>> GetAllViewModelWithFilters(FilterPokeViewModel filters);
    }
}
