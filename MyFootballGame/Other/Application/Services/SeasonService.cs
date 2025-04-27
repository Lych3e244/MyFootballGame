using MyFootballGame.Other.Application.Interfaces;
using MyFootballGame.Other.Application.ViewModel.Season;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Domain.Model;
using MyFootballGame.Other.Infrastructure.Repositories;

namespace MyFootballGame.Other.Application.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public int AddNewSeason(NewSeasonVm newSeasonVm)
        {
            var newSeason = new Season()
            {
                Id = newSeasonVm.Id,
                Name = newSeasonVm.Name,
                LeagueId = newSeasonVm.LeagueId
            };
            _seasonRepository.AddSeason(newSeason);
            return newSeason.Id;
        }

        public ListSeasonForListVm GetAllActiveSeasons(int pageSize, int pageNum, string searchString)
        {
            var seasons = _seasonRepository.GetAllActiveSeasons().Where(p => p.Name.StartsWith(searchString));
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var seasonsToShow = seasons.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            ListSeasonForListVm result = new ListSeasonForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNum,
                SearchString = searchString,
                Seasons = new List<SeasonForListVm>(),
                Count = seasons.Count()
            };
            foreach (var season in seasonsToShow)
            {
                var seasonVm = new SeasonForListVm()
                {
                    Id = season.Id,
                    Name = season.Name,
                    LeagueId = season.LeagueId,
                    SeasonWinnerId = season.SeasonWinnerId
                };
                result.Seasons.Add(seasonVm);
            }
            return result;
        }
    }
}
