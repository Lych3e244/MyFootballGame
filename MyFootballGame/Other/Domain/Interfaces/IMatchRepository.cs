using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Domain.Interfaces
{
    public interface IMatchRepository
    {
        //Play one match
        int AddMatch(int seasonId, int hostId, int guestId);

        //Play all matches of a season
        void PlayWholeSeasonByLeagueAndSeasonId(int leaguesId, int seasonId);

        //Update match
        void UpdateMatch(Match match);

        //Delete match(make inactive)
        void DeleteMatch(int matchId);

        //Get match by id
        Match GetMatchById(int id);
        //Get all matches
        IQueryable<Match> GetAllMatches();

        //Get all matches of a season
        IQueryable<Match> GetMatchesBySeason(int seasonId);

        //Display match by id
        void DisplayMatchById(int matchId);

        //Clear statistics by league id
        public void ClearStatisticsByLeagueId(int leagueId);

    }
}
