using MyFootballGame.Other.Domain.Model;
using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.Player;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Application.ViewModel.League;
using MyFootballGame.Other.Infrastructure.Repositories;

namespace MyFootballGame.Other.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public ListPlayerForListVm GetAllActivePlayers(int pageSize, int pageNum, string searchString)
        {
            var players = _playerRepository.GetAllActivePlayers().Where(p => p.Name.Contains(searchString));
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var playersToShow = players.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            ListPlayerForListVm result = new ListPlayerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNum,
                SearchString = searchString,
                Players = new List<PlayerForListVm>(),
                Count = players.Count()
            };
            foreach (var player in playersToShow)
            {
                var playerVm = new PlayerForListVm()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Age = player.Age,
                    Position = player.Position,
                    Skill = player.Skill,
                    CountryId = player.CountryId,
                    TeamId = player.TeamId

                };
                result.Players.Add(playerVm);
            }
            return result;
        }
    }
}