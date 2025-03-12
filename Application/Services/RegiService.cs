using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Region;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegiService : IRegiService
    {
        private readonly IRegiRepository _regiRepository;
        public RegiService(IRegiRepository regiRepository)
        {
            _regiRepository = regiRepository;
        }
        public async Task Add(SaveRegiViewModel vm)
        {
            Regions regions = new();
            regions.Name = vm.Name;
            regions.Color = vm.Color;
            regions.Description = vm.Description;
            await _regiRepository.AddAsync(regions);
        }
        public async Task Update(SaveRegiViewModel vm)
        {
            Regions regions = new();
            regions.Id = vm.Id;
            regions.Name = vm.Name;
            regions.Color = vm.Color;
            regions.Description = vm.Description;
            await _regiRepository.UpdateAsync(regions);
        }
        public async Task Delete(int Id)
        {
            var regions = await _regiRepository.GetByIdAsyns(Id);
            await _regiRepository.DeleteAsync(regions);
        }
        public async Task<SaveRegiViewModel> GetByIdSaveViewModel(int Id)
        {
            var regions = await _regiRepository.GetByIdAsyns(Id);

            SaveRegiViewModel vm = new();
            vm.Id = regions.Id;
            vm.Name = regions.Name;
            vm.Color = regions.Color;
            vm.Description = regions.Description;
            return vm;
        }
        public async Task<List<RegiViewModel>> GetAllViewModels()
        {
            var regiList = await _regiRepository.GetAllWithIncludeAsync(new List<String> { "Pokemons"});
            return regiList.Select(regions => new RegiViewModel
            {
                Name = regions.Name,
                Id = regions.Id,
                Color = regions.Color,
                Description = regions.Description,
                PokemonsQuantity = regions.Pokemons.Count()
            }).ToList();
        }
    }
}
