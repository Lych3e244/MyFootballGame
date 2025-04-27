using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Domain.Model
{
    public class Season : Common
    {
        public string Name { get; set; }
        public int LeagueId {  get; set; }
        public int? SeasonWinnerId { get; set; } //New
        public Team? SeasonWinner { get; set; } //New
        public League League { get; set; }
        public List<Match> Matches { get; set; }

    }
}
