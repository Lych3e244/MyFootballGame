using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Domain.Model
{
    public class Match : Common
    {
        public int SeasonId { get; set; }
        public int HostTeamId { get; set; }
        public int GuestTeamId { get; set; }

        public int HostScore { get; set; }
        public int GuestScore { get; set; }

        public Season Season { get; set; }
        public Team HostTeam { get; set; }
        public Team GuestTeam { get; set; }
    }
}
