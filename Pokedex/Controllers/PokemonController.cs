using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;


namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokeService _pokeService;
        private readonly IRegiService _regiService;
        private readonly ITypeService _typeService;

        public PokemonController(IPokeService pokeService, IRegiService regiService, ITypeService typeService)
        {
            _pokeService = pokeService;
            _regiService = regiService;
            _typeService = typeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokeService.GetAllViewModels());
        }

        public async Task<IActionResult> Create()
        {
            SavePokeViewModel vm = new();
            vm.Regions = await _regiService.GetAllViewModels();
            vm.Types = await _typeService.GetAllViewModels();
            return View("SavePokemon", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Regions = await _regiService.GetAllViewModels();
                vm.Types = await _typeService.GetAllViewModels();
                return View("SavePokemon", vm);
            }
            await _pokeService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Edit(int Id)
        {
            SavePokeViewModel vm = await _pokeService.GetByIdSaveViewModel(Id);
            vm.Regions = await _regiService.GetAllViewModels();
            vm.Types = await _typeService.GetAllViewModels();
            return View("SavePokemon", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Regions = await _regiService.GetAllViewModels();
                vm.Types = await _typeService.GetAllViewModels();
                return View("SavePokemon", vm);
            }
            await _pokeService.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Delete(int Id)
        {
            return View("DeletePokemon", await _pokeService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _pokeService.Delete(Id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
    }
}