using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;
using Pokedex.Core.Domain.Entities;

namespace Application.Services
{
    public class PokeService : IPokeService
    {
        private readonly IPokeRepository _pokeRepository;
        public PokeService(IPokeRepository pokeRepository)
        {
            _pokeRepository = pokeRepository;
        }
        public async Task Add(SavePokeViewModel vm)
        {
            Pokemons pokemons = new();
            pokemons.Name = vm.Name;
            pokemons.Caracteristica = vm.Caracteristica;
            pokemons.ImgUrl = vm.ImgUrl;
            pokemons.RegionId = vm.RegionId;
            pokemons.TypeId = vm.TypeId;
            await _pokeRepository.AddAsync(pokemons);
        }
        public async Task Update(SavePokeViewModel vm)
        { 
            Pokemons pokemons = new();
            pokemons.Id = vm.Id;
            pokemons.Name = vm.Name;
            pokemons.Caracteristica = vm.Caracteristica;
            pokemons.ImgUrl = vm.ImgUrl;
            pokemons.RegionId = vm.RegionId;
            pokemons.TypeId = vm.TypeId;
            await _pokeRepository.UpdateAsync(pokemons);
        }
        public async Task Delete(int Id)
        {
            var pokemons = await _pokeRepository.GetByIdAsyns(Id);
            await _pokeRepository.DeleteAsync(pokemons);
        }
        public async Task<SavePokeViewModel> GetByIdSaveViewModel(int Id)
        {
            var pokemons = await _pokeRepository.GetByIdAsyns(Id);

            SavePokeViewModel vm = new();
            vm.Id = pokemons.Id;
            vm.Name = pokemons.Name;
            vm.ImgUrl = pokemons.ImgUrl;
            vm.Caracteristica = pokemons.Caracteristica;
            vm.TypeId = pokemons.TypeId;
            vm.RegionId = pokemons.RegionId;
            return vm;

        }
        public async Task<List<PokeViewModel>> GetAllViewModels()
        {
            var pokeList = await _pokeRepository.GetAllWithIncludeAsync(new List<string> { "Types", "Regions"});
            return pokeList.Select(pokemons => new PokeViewModel
            {
                Name = pokemons.Name,
                Id = pokemons.Id,
                ImgUrl = pokemons.ImgUrl,
                Caracteristica = pokemons.Caracteristica,
                TypeName = pokemons.Types.Name,
                RegionName = pokemons.Regions.Name,
                RegionId = pokemons.Regions.Id,
            }).ToList();
        }
        public async Task<List<PokeViewModel>> GetAllViewModelWithFilters(FilterPokeViewModel filters)
        {
            var pokeList = await _pokeRepository.GetAllWithIncludeAsync(new List<string> { "Types", "Regions" });

            var listViewModels = pokeList.Select(pokemons => new PokeViewModel
            {
                Name = pokemons.Name,
                Id = pokemons.Id,
                ImgUrl = pokemons.ImgUrl,
                Caracteristica = pokemons.Caracteristica,
                TypeName = pokemons.Types.Name,
                RegionName = pokemons.Regions.Name,
                RegionId = pokemons.Regions.Id,
            }).ToList();

            if (filters.RegionId != null)
            {
                listViewModels = listViewModels.Where(pokemons => pokemons.RegionId == filters.RegionId.Value).ToList();
            }

            return listViewModels;


        }

    }
}