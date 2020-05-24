using System;
using System.Collections.Generic;

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
        public Dictionary<int, Move> AvailableMoves = new Dictionary<int, Move>();
        public int Winner = 0;
        public Move LastMove { get; set; }

        public enum GameStates
        {
            NotStarted = 0,
            Initiating = 1,
            PlayerMove = 10,
            PlayerStockPurchasing = 15,
            BetweenMoves = 17,
            GameEnding = 20,
            GameEnded = 25
        }
        public GameStates GameState = GameStates.NotStarted;

        public GameStateObject()
        {

        }

        public void ResetStockExchange()
        {
            Array.Clear(StockToBuy, 0, StockToBuy.Length);
        }

    }
}
