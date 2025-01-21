using Application.Services;
using Application.ViewModels.Pokemon;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokeService _pokeService;

        public PokemonController(ApplicationContext dbContext)
        {
            _pokeService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokeService.GetAllViewModels());
        }

        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokeViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokeService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Edit(int Id)
        {
            return View("SavePokemon", await _pokeService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
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