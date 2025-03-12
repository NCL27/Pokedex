using Pokedex.Core.Application.ViewModels.Pokemon;
using Pokedex.Core.Application.ViewModels.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IRegiService : IGenericService<SaveRegiViewModel, RegiViewModel>
    {
     
    }
}
