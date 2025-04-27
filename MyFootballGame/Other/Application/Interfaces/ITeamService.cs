using MyFootballGame.Other.Application.ViewModel.Team;

namespace MyFootballGame.Other.Application.Interfaces
{
    public interface ITeamService
    {
        ListTeamForListVm GetAllTeams(int pageSize, int pageNum, string searchString);
    }
}
