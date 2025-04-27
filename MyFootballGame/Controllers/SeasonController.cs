using Microsoft.AspNetCore.Mvc;
using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.Season;

namespace MyFootballGame.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _seasonService.GetAllActiveSeasons(10, 1, "");
            return View(model);
        }
        [HttpGet]
        public IActionResult AddNewSeason()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewSeason(NewSeasonVm model)
        {
            var id = _seasonService.AddNewSeason(model);
            return RedirectToAction("Index");
        }
    }
}
