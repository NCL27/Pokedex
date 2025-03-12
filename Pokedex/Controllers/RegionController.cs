using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Region;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {

        private readonly IRegiService _regiService;

        public RegionController(IRegiService regiService)
        {
            _regiService = regiService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _regiService.GetAllViewModels());
        }
        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegiViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRegiViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regiService.Add(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveRegion", await _regiService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regiService.Update(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Delete(int Id)
        {
            return View("Delete", await _regiService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _regiService.Delete(Id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
