using Application.Repository;
using Application.ViewModels;
using Application.ViewModels.Pokemon;
using Application.ViewModels.Region;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegiService
    {
        private readonly RegiRepository _regiRepository;
        public RegiService(ApplicationContext dbContext)
        {
            _regiRepository = new(dbContext);
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
            var regiList = await _regiRepository.GetAllAsync();
            return regiList.Select(regions => new RegiViewModel
            {
                Name = regions.Name,
                Id = regions.Id,
                Color = regions.Color,
                Description = regions.Description,
            }).ToList();
        }
    }
}
