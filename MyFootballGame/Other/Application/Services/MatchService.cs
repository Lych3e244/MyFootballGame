using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.Match;
using MyFootballGame.Other.Application.ViewModel.Player;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Infrastructure.Repositories;

namespace MyFootballGame.Other.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ISeasonRepository _seasonRepository;
        public MatchService(IMatchRepository matchRepository, ISeasonRepository seasonRepository)
        {
            _matchRepository = matchRepository;
            _seasonRepository = seasonRepository;
        }

        public ListMatchForListVm GetAllMatches(int pageSize, int pageNum, string searchString)
        {
            //Na razie po wyszukujemy po nazwie hosta
            var matches = _matchRepository.GetAllMatches().Where(m => m.HostTeam.Name.Contains(searchString));
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var matchesToShow = matches.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            ListMatchForListVm result = new ListMatchForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNum,
                SearchString = searchString,
                Matches = new List<MatchForListVm>(),
                Count = matches.Count()
            };
            foreach (var match in matchesToShow)
            {
                var matchVm = new MatchForListVm()
                {
                    Id = match.Id,
                    HostTeamName = match.HostTeam.Name,
                    HostTeamScore = match.HostScore,
                    GuestTeamName = match.GuestTeam.Name,
                    GuestTeamScore = match.GuestScore,

                };
                result.Matches.Add(matchVm);
            }
            return result;
        }

        public int PlayWholeSeason(PlayAllMatchesOfSeasonVm allMatchesVm)
        {
            _matchRepository.ClearStatisticsByLeagueId(allMatchesVm.Id);
            var activeSeason = _seasonRepository.GetActiveSeasonByLeagueId(allMatchesVm.Id);
            _matchRepository.PlayWholeSeasonByLeagueAndSeasonId(allMatchesVm.Id, activeSeason.Id);
            _seasonRepository.ChooseSeasonWinner(allMatchesVm.Id);
            _seasonRepository.GenerateNewSeason(allMatchesVm.Id);

            return allMatchesVm.Id;
        }
    }
}
