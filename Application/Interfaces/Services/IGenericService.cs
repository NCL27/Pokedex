using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task Add(SaveViewModel vm);
        Task Update(SaveViewModel vm);
        Task Delete(int Id);
        Task<SaveViewModel> GetByIdSaveViewModel(int Id);
        Task<List<ViewModel>> GetAllViewModels();
    }
}
