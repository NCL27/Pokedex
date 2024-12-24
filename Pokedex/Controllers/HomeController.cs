using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokeService _pokeService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokeService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokeService.GetAllViewModels());
        }
    }
}
