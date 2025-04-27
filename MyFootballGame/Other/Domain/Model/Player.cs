using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballGame.Other.Domain.Model
{
    public class Player : Common
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Skill { get; set; }
        public int CountryId { get; set; }
        public int TeamId { get; set; }

        public Country Country { get; set; } 
        public Team Team { get; set; }
    }
}
