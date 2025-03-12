using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Type;
using Pokedex.Core.Domain.Entities;


namespace Application.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
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
