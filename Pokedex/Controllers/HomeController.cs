using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;


namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokeService _pokeService;
        private readonly IRegiService _regiService;
        private readonly ITypeService _typeService;
        public HomeController(IPokeService pokeService, IRegiService regiService, ITypeService typeService)
        {
            _pokeService = pokeService;
            _regiService = regiService;
            _typeService = typeService;
        }
        public async Task<IActionResult> Index(FilterPokeViewModel vm)
        {
            ViewBag.Regions = await _regiService.GetAllViewModels();
            ViewBag.Types = await _typeService.GetAllViewModels();
            return View(await _pokeService.GetAllViewModelWithFilters(vm));
        }
    }
}
