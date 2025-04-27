using MyFootballGame.Other.Application.ViewModel.Player;

namespace MyFootballGame.Other.Application.Interfaces
{
    public interface IPlayerService
    {
        ListPlayerForListVm GetAllActivePlayers(int pageSize, int pageNum, string searchString);
    }
}
