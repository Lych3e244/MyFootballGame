using MyFootballGame.Other.Domain.Model;
using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.League;
using MyFootballGame.Other.Domain.Interfaces;
using System.Drawing.Printing;

namespace MyFootballGame.Other.Application.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        public LeagueService(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        public ListLeagueForListVm GetAllActiveLeagues(int pageSize, int pageNum, string searchString)
        {
            var leagues = _leagueRepository.GetAllActiveLeagues().Where(p => p.Name.StartsWith(searchString));
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var participantsToShow = leagues.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            ListLeagueForListVm result = new ListLeagueForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNum,
                SearchString = searchString,
                Leagues = new List<LeagueForListVm>(),
                Count = leagues.Count()
            };
            foreach (var participant in participantsToShow)
            {
                var participantVm = new LeagueForListVm()
                {
                    Id = participant.Id,
                    Name = participant.Name
                };
                result.Leagues.Add(participantVm);
            }
            return result;
        }

        public int AddNewLeague(NewLeagueVm newLeagueVm)
        {
            var newLeague = new League()
            {
                Id = newLeagueVm.Id,
                Name = newLeagueVm.Name
            };
            _leagueRepository.AddLeague(newLeague);
            return newLeague.Id;
        }
    }
}