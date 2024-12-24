using Application.Services;
using Application.ViewModels.Region;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {

        private readonly RegiService _regiService;

        public RegionController(ApplicationContext dbContext)
        {
            _regiService = new(dbContext);
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
            if (ModelState.IsValid)
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
            return View(await _regiService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _regiService.Delete(Id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
