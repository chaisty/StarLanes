using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public class GameConfiguration
    {
        // Initialize Companies
        public const int Max_NumberOfCompanies = 10;
        public int Max_Companies = 5;   //configurable
        public int founderShares = 5;

        public static int Max_NumberOfPlayers = 5;
        public int NumberOfPlayers = 4;

        //Initialize Map
        const int Max_X_dimension = 20;
        const int Max_Y_dimension = 20;
        public int x_dimension = 12;
        public int y_dimension = 9;
        public int starChance = 10;
        public int blackholeChance = 3;
        public int blackholeConsumptionChance = 25; // chance a developed sector will be consumed by a black hole
        public bool BlackholeDestroys = true;

        //Initialize Sector Values
        public int normalValue = 100;
        public int starValue = 500;
        public int blackholeValue = -500; // if they don't destroy the company, they impair its value

        //Finance Constants
        public int mergerRatio = 2; // Old shares needed to equal one new share
        public long playerStartingMoney = 6000;
        public int dividendPercentage = 5;
        public bool StockSplits = true;
        public int stockSplitPrice = 3000;

        string GameStatus = "Not Started.";

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

        public bool RandomizePlayerOrder = true;
        public bool RandomizeFirstMover = true;
        public int FirstPlayer = 0;
        public int MaxNumberOfMovesPerGame = 48;
        public int numberOfRounds = 12;
        public bool DefaultRounds = true;
        public int numberOfMoves = 4;  // # of sectors the player is allowed to choose among to develop on his turn

        public GameConfiguration()
        {
        }

        // Game Properties

        public void SetMapSize(int x, int y)
        {
            X_dimension = x;
            Y_dimension = y;
        }

        public void UpdateRoundsBasedOnPlayerCount()
        {
            //    if(e.Value.GetType() == typeof(int)) {
            //        NumberOfPlayers = Int32.Parse(e.Value.ToString());
            //    }

            switch (NumberOfPlayers)
            {
                case 2:
                    NumberOfRounds = 24; break;
                case 3:
                    NumberOfRounds = 18; break;
                case 4:
                    NumberOfRounds = 12; break;
                case 5:
                    NumberOfRounds = 10; break;
                default:
                    NumberOfRounds = 12; break;
            }
        }

        public int NumberOfCompanies
        {
            get { return Max_Companies; }
            set
            {
                if (value > 10)
                    Max_Companies = 10;
                else if (value < 5)
                    Max_Companies = 5;
                else
                    Max_Companies = value;
            }
        }

        public int FounderShares
        {
            get { return founderShares; }
            set
            {
                if (value < 0)
                    founderShares = 0;
                else if (value > 20)
                    founderShares = 20;
                else
                    founderShares = value;
            }
        }

        public long PlayerStartingMoney
        {
            get { return playerStartingMoney; }
            set
            {
                if (value < 0) { playerStartingMoney = 0; }
                else if (value > 20000) { playerStartingMoney = 20000; }
                else { playerStartingMoney = value - (value % 100); } // force to 00's
            }
        }

        public int MergerRatio
        {
            get { return mergerRatio; }
            set
            {
                if (value < 1) { mergerRatio = 1; }
                else if (value > 5) { mergerRatio = 5; }
                else { mergerRatio = value; }
            }
        }

        /*const int NormalValue = 100;
        const int StarValue = 500;

        //Finance Constants
        public int MergerRatio = 2; // Old shares needed to equal one new share
        */

        public int NormalValue
        {
            get { return normalValue; }
            set
            {
                if (value < 0)
                    normalValue = 0;
                else if (value > 1000)
                    normalValue = 1000;
                else
                    normalValue = value - (value % 100);    // force to 00's
            }
        }

        public int StarValue
        {
            get { return starValue; }
            set
            {
                if (value < 0)
                    starValue = 0;
                else if (value > 2000)
                    starValue = 2000;
                else
                    starValue = value - (value % 100); // force to 00's
            }
        }

        public int BlackholeValue
        {
            get { return blackholeValue; }
            set
            {
                if (value < -2000)
                    blackholeValue = -2000;
                else if (value > 0)
                    blackholeValue = 0;
                else
                    blackholeValue = value - (value % 100); // force to 00's
            }
        }

        public int X_dimension
        {
            get { return x_dimension; }
            set
            {
                if (value < 5)
                    x_dimension = 5;
                else if (value > Max_X_dimension)
                    x_dimension = Max_X_dimension;
                else
                    x_dimension = value;
            }
        }

        public int Y_dimension
        {
            get { return y_dimension; }
            set
            {
                if (value < 5)
                    y_dimension = 5;
                else if (value > Max_Y_dimension)
                    y_dimension = Max_Y_dimension;
                else
                    y_dimension = value;
            }
        }

        public int StarChance
        {
            get { return starChance; }
            set
            {
                if (value < 0)
                    starChance = 0;
                else if (value > 20)
                    starChance = 20;
                else
                    starChance = value;
            }
        }

        public int BlackholeChance
        {
            get { return blackholeChance; }
            set
            {
                if (value < 0)
                    blackholeChance = 0;
                else if (value > 5)
                    blackholeChance = 5;
                else
                    blackholeChance = value;
            }
        }

        public int BlackholeConsumptionChance
        {
            get { return blackholeConsumptionChance; }
            set
            {
                if (value < 0)
                    blackholeConsumptionChance = 0;
                else if (value > 100)
                    blackholeConsumptionChance = 100;
                else
                    blackholeConsumptionChance = value;
            }
        }

        public int NumberOfRounds
        {
            get { return numberOfRounds; }
            set
            {
                if (value < 1)
                    numberOfRounds = 1;
                else if (value > 24)
                    numberOfRounds = 24;
                else
                    numberOfRounds = value;
            }
        }

        public int NumberOfMoves
        {
            get { return numberOfMoves; }
            set
            {
                if (value < 3)
                    numberOfMoves = 3;
                else if (value > 5)
                    numberOfMoves = 5;
                else numberOfMoves = value;
            }
        }

        public int DividendPercentage
        {
            get { return dividendPercentage; }
            set
            {
                if ((value > 0) && (value <= 10))
                    dividendPercentage = value;
            }
        }

        public int StockSplitPrice
        {
            get { return stockSplitPrice; }
            set
            {
                if (value < 2000)
                    stockSplitPrice = 2000;
                else if (value > 20000)
                    stockSplitPrice = 20000;
                else
                {
                    stockSplitPrice = value - (value % 100);    //force to 00's
                }
            }
        }
    }
}
