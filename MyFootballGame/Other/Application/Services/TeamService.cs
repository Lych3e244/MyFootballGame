using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.Team;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Infrastructure.Repositories;

namespace MyFootballGame.Other.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public ListTeamForListVm GetAllTeams(int pageSize, int pageNum, string searchString)
        {
            var teams = _teamRepository.GetAllActiveTeams().Where(p => p.Name.StartsWith(searchString));
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var teamsToShow = teams.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            ListTeamForListVm result = new ListTeamForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNum,
                SearchString = searchString,
                Teams = new List<TeamForListVm>(),
                Count = teams.Count()
            };
            foreach (var team in teamsToShow)
            {
                var teamVm = new TeamForListVm()
                {
                    Id = team.Id,
                    Name = team.Name,
                    LeagueId = team.LeagueId,
                    TeamSkill = team.TeamSkill,
                    Wins = team.Wins,
                    Draws = team.Draws,
                    Losses = team.Losses,
                    Points = team.Points
                };
                result.Teams.Add(teamVm);
            }
            return result;
        }
    }
}
