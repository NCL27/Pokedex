using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Type;

namespace Pokedex.Controllers
{
    public class TypeController : Controller
    {

        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _typeService.GetAllViewModels());
        }
        public IActionResult Create()
        {
            return View("SaveType", new SaveTypeViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }
            await _typeService.Add(vm);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }
        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveType", await _typeService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }
            await _typeService.Update(vm);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }
        public async Task<IActionResult> Delete(int Id)
        {
            return View("Delete", await _typeService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _typeService.Delete(Id);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }
    }
}
