using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Domain.Interfaces
{
    public interface ILeagueRepository
    {
        // Get all active leagues
        IQueryable<League> GetAllActiveLeagues();

        // Get league by id
        League GetLeagueById(int id);

        //Add a new league
        int AddLeague(League newLeague);

        //Update a league
        int UpdateLeague(League league);

        //Delete a league(make inactive)
        int DeleteLeague(int id);

    }
}
