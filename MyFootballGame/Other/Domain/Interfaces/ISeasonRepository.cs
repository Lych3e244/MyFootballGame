using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Domain.Interfaces
{
    public interface ISeasonRepository
    {
        // Get all active seasons
        IQueryable<Season> GetAllActiveSeasons();

        //Get last season of a league

        //Generate a new season for a league
        Season GenerateNewSeason(int leagueId);

        // Get season by id
        Season GetSeasonById(int id);

        //Add a new season
        int AddSeason(Season season);

        //Update a season
        int UpdateSeason(Season season);

        //Choose a season winner
        int ChooseSeasonWinner(int leagueId);

        //Get active season for a league
        Season GetActiveSeasonByLeagueId(int leagueId);

    }
}
