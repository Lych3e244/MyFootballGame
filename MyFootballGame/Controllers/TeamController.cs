using Microsoft.AspNetCore.Mvc;
using MyFootballGame.Other.Application.Interfaces;
using System.Drawing.Printing;

namespace MyFootballGame.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _teamService.GetAllTeams(10, 1, "");
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
            var model = _teamService.GetAllTeams(pageSize, pageNum, searchString);
            return View(model);
        }
    }
}
