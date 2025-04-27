using Microsoft.AspNetCore.Mvc;
using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.Services;

namespace MyFootballGame.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _playerService.GetAllActivePlayers(10, 1, "");
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
            var model = _playerService.GetAllActivePlayers(pageSize, pageNum, searchString);
            return View(model);
        }

    }
}
