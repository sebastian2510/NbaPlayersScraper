using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaScraper.PlayerInfo
{
    public class Player
    {
        public string? Name { get; set; }
        public Stats Stats { get; set; }

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }
    }
}
