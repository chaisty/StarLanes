using System.Collections.Generic;

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
        public PlayerType Type { get; set; } = PlayerType.Human;
        public int FinalRank { get; set; }

        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public Player(string name, int money, PlayerType playerType) : this(name, money)
        {
            Type = playerType;
        }

        public bool IsHuman => (Type == PlayerType.Human);


    }
}
