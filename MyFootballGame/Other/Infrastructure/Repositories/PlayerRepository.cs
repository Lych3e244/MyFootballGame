using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Context _context;
        public PlayerRepository(Context context)
        {
            _context = context;
        }
        // Get all active players
        public IQueryable<Player> GetAllActivePlayers()
        {
            var activePlayers = _context.Players.Where(p => p.Status == CommonStatusEnum.Active);
            return activePlayers;
        }
        // Get player by id
        public Player GetPlayerById(int id)
        {
            throw new NotImplementedException();
        }
        //Add a new player
        public int AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }
        //Update a player
        public int UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
        //Delete a player(make inactive)
        public int RetirePlayer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
