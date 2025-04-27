using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        // Get all active players
        IQueryable<Player> GetAllActivePlayers();
        // Get player by id
        Player GetPlayerById(int id);
        //Add a new player
        int AddPlayer(Player player);
        //Update a player
        int UpdatePlayer(Player player);
        //Delete a player(make inactive)
        int RetirePlayer(int id);
    }
}
