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
    public class LeagueRepository : ILeagueRepository
    {
        private readonly Context _context;

        public LeagueRepository(Context context)
        {
            _context = context;
        }

        public int AddLeague(League newLeague)
        {
            var newLeagueToAdd = new League
            {
                Name = newLeague.Name,
                CreatedTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                Status = CommonStatusEnum.Active
            };
            _context.Leagues.Add(newLeagueToAdd);
            _context.SaveChanges();

            return newLeagueToAdd.Id;
        }

        public int DeleteLeague(int id)
        {
            _context.Leagues.Find(id).Status = CommonStatusEnum.Inactive;
            _context.SaveChanges();
            return id;
        }

        public IQueryable<League> GetAllActiveLeagues()
        {
           var activeLeagues = _context.Leagues.Where(l => l.Status == CommonStatusEnum.Active);
           return activeLeagues;
        }

        public League GetLeagueById(int id)
        {
            League league = _context.Leagues.Find(id);
            return league;
        }

        public int UpdateLeague(League league)
        {
            throw new NotImplementedException();
        }
    }
}
