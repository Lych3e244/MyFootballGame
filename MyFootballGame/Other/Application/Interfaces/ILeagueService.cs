using MyFootballGame.Other.Domain.Model;
using MyFootballGame.Other.Application.ViewModel.League;

namespace MyFootballGame.Other.Application.Interfaces
{
    public interface ILeagueService
    {
        ListLeagueForListVm GetAllActiveLeagues(int pageSize, int pageNum, string searchString);
        int AddNewLeague(NewLeagueVm newLeagueVm);
    }
}
