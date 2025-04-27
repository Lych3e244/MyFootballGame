using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Domain.Model
{
    public class League : Common
    {
        public string Name { get; set; }
        public List<Season> Seasons { get; set; }
        public List<Team> Teams { get; set; }
    }
}
