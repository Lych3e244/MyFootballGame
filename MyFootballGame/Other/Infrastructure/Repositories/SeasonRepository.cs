using Microsoft.EntityFrameworkCore;
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
    public class SeasonRepository : ISeasonRepository
    {
        private readonly Context _context;
        public SeasonRepository(Context context)
        {
            _context = context;
        }
        public int AddSeason(Season season)
        {
            var seasonToAdd = new Season
            {
                Name = season.Name,
                LeagueId = season.LeagueId,
                CreatedTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                Status = CommonStatusEnum.Active
            };
            _context.Seasons.Add(seasonToAdd);
            _context.SaveChanges();
            return seasonToAdd.Id;
        }

        public int ChooseSeasonWinner(int leagueId)
        {
            var teamsFromLeague = _context.Teams.Where(t => t.LeagueId == leagueId).ToList();
            var seasonWinner = teamsFromLeague.OrderByDescending(t => t.Points).FirstOrDefault();
            var activeSeason = _context.Seasons
                .Where(s => s.LeagueId == leagueId && s.Status == CommonStatusEnum.Active)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
            activeSeason.SeasonWinnerId = seasonWinner.Id;
            activeSeason.ModifyTime = DateTime.Now;
            activeSeason.Status = CommonStatusEnum.Inactive;
            _context.SaveChanges();
            return seasonWinner.Id;
        }

        public Season GenerateNewSeason(int leagueId)
        {
            // Get the last season for the league
            var lastSeason = _context.Seasons
                .Where(s => s.LeagueId == leagueId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();

            // Generate the new season name based on the last season's name
            string newSeasonName = "2024/25"; // Default if no previous season exists
            if (lastSeason != null)
            {
                var lastSeasonNameParts = lastSeason.Name.Split('/');
                if (lastSeasonNameParts.Length == 2 &&
                    int.TryParse(lastSeasonNameParts[0], out int startYear) &&
                    int.TryParse(lastSeasonNameParts[1], out int endYear))
                {
                    newSeasonName = $"{startYear + 1}/{endYear + 1}";
                }
            }

            // Make the last season inactive
            if (lastSeason != null && lastSeason.Status == CommonStatusEnum.Active)
            {
                lastSeason.Status = CommonStatusEnum.Inactive;
                lastSeason.ModifyTime = DateTime.Now;
                _context.SaveChanges();
            }

            // Create the new season
            var newSeason = new Season
            {
                Name = newSeasonName,
                LeagueId = leagueId,
                CreatedTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                Status = CommonStatusEnum.Active
            };

            // Add the new season to the database
            _context.Seasons.Add(newSeason);
            _context.SaveChanges();

            return newSeason;
        }

        public IQueryable<Season> GetAllActiveSeasons()
        {
            var activeSeasons = _context.Seasons.Where(s => s.Status == CommonStatusEnum.Active);
            return activeSeasons;
        }
        public Season GetActiveSeasonByLeagueId(int leagueId)
        {
            var activeSeason = _context.Seasons
                .Where(s => s.LeagueId == leagueId && s.Status == CommonStatusEnum.Active)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
            return activeSeason;
        }

        public Season GetSeasonById(int id)
        {
            var season = _context.Seasons.Find(id);
            return season;
        }

        // Now don't need to implement this method
        public int UpdateSeason(Season season)
        {
            throw new NotImplementedException();
        }
    }
}
