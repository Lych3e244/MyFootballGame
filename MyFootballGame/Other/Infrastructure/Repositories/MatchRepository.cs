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
    public class MatchRepository : IMatchRepository
    {
        private readonly Context _context;
        public MatchRepository(Context context)
        {
            _context = context;
        }

        public int AddMatch(int seasonId, int hostTeamId, int guestTeamId)
        {
            var hostTeam = _context.Teams.Find(hostTeamId);
            var guestTeam = _context.Teams.Find(guestTeamId);

            Random rand = new Random();
            int hostScore = 0;
            int guestScore = 0;

            const int homeAdvantage = 3; // Przewaga gospodarzy

            int adjustedHostSkill = hostTeam.TeamSkill + homeAdvantage;
            int adjustedGuestSkill = guestTeam.TeamSkill;

            int advantage = adjustedHostSkill - adjustedGuestSkill;

            for (int minute = 0; minute < 90; minute++)
            {
                if (rand.NextDouble() < 0.03 + advantage / 100) // Szansa na gol gospodarzy
                {
                    hostScore++;
                }
                if (rand.NextDouble() < 0.03 - advantage / 100) // Szansa na gol gości
                {
                    guestScore++;
                }
            }

            // Aktualizacja statystyk zespołów
            if (hostScore > guestScore)
            {
                hostTeam.Wins++;
                guestTeam.Losses++;
            }
            else if (hostScore < guestScore)
            {
                hostTeam.Losses++;
                guestTeam.Wins++;
            }
            else
            {
                hostTeam.Draws++;
                guestTeam.Draws++;
            }

            hostTeam.Points = hostTeam.Wins * 3 + hostTeam.Draws;
            guestTeam.Points = guestTeam.Wins * 3 + guestTeam.Draws;

            var newMatch = new Match
            {
                SeasonId = seasonId,
                HostTeamId = hostTeamId,
                GuestTeamId = guestTeamId,
                HostScore = hostScore,
                GuestScore = guestScore,
                HostTeam = hostTeam,
                GuestTeam = guestTeam,
                CreatedTime = DateTime.Now,
                Status = CommonStatusEnum.Active
            };

            _context.Matches.Add(newMatch);
            _context.SaveChanges();

            return newMatch.Id;

        }

        public void DeleteMatch(int matchId)
        {
            _context.Matches.Where(m => m.Id == matchId).FirstOrDefault().Status = CommonStatusEnum.Inactive;
        }

        public IQueryable<Match> GetAllMatches()
        {
            var matches = _context.Matches
                .Include(m => m.HostTeam)
                .Include(m => m.GuestTeam)
                .Where(m => m.Status == CommonStatusEnum.Active);
            return matches;
        }

        public Match GetMatchById(int id)
        {
            var match = _context.Matches.Find(id);
            return match;
        }

        public IQueryable<Match> GetMatchesBySeason(int seasonId)
        {

            var matches = _context.Matches.Where(m => m.SeasonId == seasonId);
            return matches;
        }

        public void PlayWholeSeasonByLeagueAndSeasonId(int leagueId, int seasonId)
        {
            var teams = _context.Teams.Where(t => t.LeagueId == leagueId).ToList();
            foreach (var teamOne in teams)
            {
                foreach (var teamTwo in teams)
                {
                    if (teamOne != teamTwo)
                    {
                        var newmatch = AddMatch(seasonId, teamOne.Id, teamTwo.Id);
                        DisplayMatchById(newmatch);
                    }
                }
            }
        }

        public void UpdateMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void DisplayMatchById(int matchId)
        {
            var match = GetMatchById(matchId);
            Console.WriteLine($"{match.HostTeam.Name} {match.HostScore} - {match.GuestScore} {match.GuestTeam.Name}");
        }
        public void ClearStatisticsByLeagueId(int leagueId)
        {
            var teams = _context.Teams.Where(t => t.LeagueId == leagueId).ToList();
            foreach (var team in teams)
            {
                team.Wins = 0;
                team.Draws = 0;
                team.Losses = 0;
                team.Points = 0;
                team.ModifyTime = DateTime.Now;
            }
            _context.SaveChanges();
        }
    }
}
