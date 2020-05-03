using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public class GameStateObject
    {
        public int NumberOfPlayers = 2;
        public int[] StockToBuy = new int[GameConfiguration.Max_NumberOfCompanies + 1];
        public int MoneyToBuy = 0;
        public bool TestGame = false;
        public int GameRound = 0;
        public int PlayerTurn = 1;
        public int Winner = 0;
        public Move LastMove { get; set; }

        public GameStateObject()
        {

        }

        public void ResetStockExchange()
        {
            Array.Clear(StockToBuy, 0, StockToBuy.Length);
        }

    }
}
