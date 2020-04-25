using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public class Player
    {
        public enum PlayerType
        {
            Human = 0,
            Computer1 = 1, // Maximillian - avoids black holes
            Computer2 = 2, // WOPR - preferse to destroy his opponents
            Computer3 = 3, // HAL 9001 - goes for the max value move
        }


        public string Name { get; }
        public int Money { get; set; }
        public Dictionary<int, int> StockShares { get; set; }
        public PlayerType Type { get; set; }
        public int FinalRank { get; set; }

        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public bool IsHuman()
        {
            return (Type == PlayerType.Human);
        }


    }
}
