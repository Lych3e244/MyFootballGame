using Microsoft.AspNetCore.Mvc;
using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.Services;
using MyFootballGame.Other.Application.ViewModel.Match;
using System.CodeDom;

namespace MyFootballGame.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _matchService.GetAllMatches(10, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int pageNum, string searchString)
        {
            if (pageNum == null)
            {
                pageNum = 1;
            }
            if (searchString == null)
            {
                searchString = String.Empty;
            }
            var model = _matchService.GetAllMatches(pageSize, pageNum, searchString);
            return View(model);
        }
        [HttpGet]
        public IActionResult PlayWholeSeason()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PlayWholeSeason(PlayAllMatchesOfSeasonVm model)
        {
            var id = _matchService.PlayWholeSeason(model);
            return RedirectToAction("Index");
        }
    }
}
