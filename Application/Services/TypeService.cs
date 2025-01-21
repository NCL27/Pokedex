using Application.Repository;
using Application.ViewModels.Type;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TypeService
    {
        private readonly TypeRepository _typeRepository;
        public TypeService(ApplicationContext dbContext)
        {
            _typeRepository = new(dbContext);
        }
        public async Task Add(SaveTypeViewModel vm)
        {
            Types type = new();
            type.Name = vm.Name;
            type.Description = vm.Description;
            await _typeRepository.AddAsync(type);
        }
        public async Task Update(SaveTypeViewModel vm)
        {
            Types type = new();
            type.Id = vm.Id;
            type.Name = vm.Name;
            type.Description = vm.Description;
            await _typeRepository.UpdateAsync(type);
        }
        public async Task Delete(int Id)
        {
            var type = await _typeRepository.GetByIdAsyns(Id);
            await _typeRepository.DeleteAsync(type);
        }
        public async Task<SaveTypeViewModel> GetByIdSaveViewModel(int Id)
        {
            var type = await _typeRepository.GetByIdAsyns(Id);

            SaveTypeViewModel vm = new();
            vm.Id = type.Id;
            vm.Name = type.Name;
            vm.Description = type.Description;
            return vm;
        }
        public async Task<List<TypeViewModel>> GetAllViewModels()
        {
            var typeList = await _typeRepository.GetAllAsync();
            return typeList.Select(type => new TypeViewModel
            {
                Name = type.Name,
                Id = type.Id,
                Description = type.Description,
            }).ToList();
        }
    }
}
