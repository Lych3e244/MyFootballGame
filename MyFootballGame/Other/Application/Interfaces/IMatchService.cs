using MyFootballGame.Other.Application.ViewModel.League;
using MyFootballGame.Other.Application.ViewModel.Match;

namespace MyFootballGame.Other.Application.Interfaces
{
    public interface IMatchService
    {
        ListMatchForListVm GetAllMatches(int pageSize, int pageNum, string searchString);
        int PlayWholeSeason(PlayAllMatchesOfSeasonVm allMatchesVm);

    }
}
