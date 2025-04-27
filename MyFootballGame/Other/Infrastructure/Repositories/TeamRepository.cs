using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Domain.Model;
using MyFootballGame.Other.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly Context _context;
        public TeamRepository(Context context)
        {
            _context = context; 
        }

        public int AddTeam(string name, int leagueId)
        {
            var newTeam = new Team
            {
                Name = name,
                LeagueId = leagueId,
                TeamSkill =0,
                Wins = 0,
                Draws = 0,
                Losses = 0,
                Points = 0,
                CreatedTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                Status = CommonStatusEnum.Active
            };
            _context.Teams.Add(newTeam);
            _context.SaveChanges();
            return newTeam.Id;
        }

        public int DeleteTeam(int id)
        {
            _context.Teams.Find(id).Status = CommonStatusEnum.Inactive;
            return id;
        }

        public IQueryable<Team> GetAllActiveTeams()
        {
            var activeTeams = _context.Teams.Where(t => t.Status == CommonStatusEnum.Active);
            return activeTeams;
        }

        public Team GetTeamById(int id)
        {
            var team = _context.Teams.Find(id);
            return team;
        }

        public Team GetTeamByName(string name)
        {
            var team = _context.Teams.Where(t => t.Name == name).FirstOrDefault();
            return team;
        }

        //Now we don't need to implement this method
        public int UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
