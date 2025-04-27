using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Domain.Model
{
    public class Team : Common
    {
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public int TeamSkill { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Points { get; set; }

        public League League { get; set; }
        public List<Player> Players { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
    }
}
