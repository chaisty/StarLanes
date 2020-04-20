using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public class Player
    {
        public string Name { get; }
        public int Money { get; set; }

        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }
    }
}
