using MyFootballGame.Other.Domain.Model;

namespace MyFootballGame.Other.Domain.Interfaces
{
    public interface ITeamRepository
    {
        // Get all active teams
        IQueryable<Team> GetAllActiveTeams();

        // Get team by id
        Team GetTeamById(int id);

        // Get team by name
        Team GetTeamByName(string name);

        //Add a new team
        int AddTeam(string name, int leagueId);

        //Update a team
        int UpdateTeam(Team team);

        //Delete a team(make inactive)
        int DeleteTeam(int id);
    }
}
