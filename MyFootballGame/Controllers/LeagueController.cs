using Microsoft.AspNetCore.Mvc;
using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.League;

namespace MyFootballGame.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueService _leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _leagueService.GetAllActiveLeagues(10,1,"");
            return View(model);
        }
        [HttpGet]
        public IActionResult AddNewLeague()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewLeague(NewLeagueVm model)
        {
            var id = _leagueService.AddNewLeague(model);
            return RedirectToAction("Index");
        }
    }
}