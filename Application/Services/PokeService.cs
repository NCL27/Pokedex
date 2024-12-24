using Application.Repository;
using Application.ViewModels;
using Application.ViewModels.Pokemon;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokeService
    {
        private readonly PokeRepository _pokeRepository;
        public PokeService(ApplicationContext dbContext)
        {
            _pokeRepository = new(dbContext);
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
            var pokeList = await _pokeRepository.GetAllAsync();
            return pokeList.Select(pokemons => new PokeViewModel
            {
                Name = pokemons.Name,
                Id = pokemons.Id,
                ImgUrl = pokemons.ImgUrl,
                Caracteristica = pokemons.Caracteristica,
            }).ToList();
        }

    }
}