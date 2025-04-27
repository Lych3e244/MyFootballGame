using MyFootballGame.Other.Application.ViewModel.Season;

namespace MyFootballGame.Other.Application.Interfaces
{
    public interface ISeasonService
    {
        ListSeasonForListVm GetAllActiveSeasons(int pageSize, int pageNum, string searchString);
        int AddNewSeason(NewSeasonVm newSeasonVm);
        //SeasonForListVm GetSeasonById(int id);
        //void UpdateSeason(SeasonForListVm seasonForListVm);
        //void DeleteSeason(int id);
        //List<LeagueForListVm> GetAllLeagues();
    }
}
