using System;
using System.Collections.Generic;
using System.Linq;

namespace StarLanes

{
    public class Game
    {

        public Dictionary<int, Player> Players = new Dictionary<int, Player>();
        public Dictionary<int, Company> Companies = new Dictionary<int, Company>();
        //Initialize Map object
        public GalaxyMap Map = new GalaxyMap(1, 1);
        public Queue<GameEvent> Events = new Queue<GameEvent>();

        public Game()
        {
        }

        public int PlayerRank(int PlayerId)
        {
            Dictionary<int, int> rankings = PlayerRanks();

            return rankings[PlayerId];
        }

        public Dictionary<int, int> PlayerRanks()
        {

            Dictionary<int, long> rankvalues = new Dictionary<int, long>();

            foreach (var p in Players)
            {
                // rubric for sorting
                rankvalues.Add(p.Key, PlayerNetWorth(p.Key) * (long)100000000 + PlayerStockWorth(p.Key) * 10 + p.Key);
            }

            var results = rankvalues.OrderByDescending(p => p.Value);

            Dictionary<int, int> ranking = new Dictionary<int, int>();

            foreach (KeyValuePair<int, long> pair in results)
            {
                ranking.Add(pair.Key, ranking.Count + 1);
            }

            return ranking;
        }

        public int PlayerRanked(int rank)
        {
            //returns playerId of player at specific rank
            Dictionary<int, int> playerRanks = PlayerRanks();

            foreach (var i in playerRanks)
            {
                if (i.Value == rank)
                    return i.Key;
            }

            return 0;
        }

        public Game GetClone()
        {
            Game newGame = new Game(); // (Game)this.MemberwiseClone();    //Copy any values (note, as of 0.8.3 this doesn't copy anything we need)

//            foreach (var c in Companies)
//            {
//                Console.WriteLine(c.Key + ": " + c.Value.Name + ", " + c.Value.StockHolderShares.Count);
//            }
            newGame.Companies = new Dictionary<int, Company>();
            foreach (var c in Companies) { newGame.Companies.Add(c.Key, c.Value.GetClone()); }
            newGame.Players = new Dictionary<int, Player>();
            foreach (var p in Players) { newGame.Players.Add(p.Key, p.Value.GetClone()); }
            newGame.Map = GalaxyMap.GetClone(Map);

            return newGame;
        }

        public long PlayerStockWorth(int playerid)
        {
            int stockvalue = 0;
            foreach (Company c in Companies.Values)
            {
                stockvalue += c.StockHolderShares[playerid] * c.ShareValue;
            }
            return stockvalue;
        }

        public long PlayerNetWorth(int playerid)
        {
            return Players[playerid].Money + PlayerStockWorth(playerid);
        }

        public int AvailableCompanySlot()
        {
            foreach (var item in Companies)
            {
                if (!item.Value.IsActive) return item.Key;
            }

            return 0;   // no available company slots
        }

        public int ExistingCompanies()
        {
            return Companies.Where(item => item.Value.IsActive).ToDictionary(item => item.Key, i => i.Value).Count;
        }

        public int CompanySize(Company company)
        {
            return Map.NumberOfSymbolsOnMap(company.Symbol);
        }

        public string EventsText(int currentRound, int currentTurn)
        {
 
            //List events in reverse chronological order
            string eventString = String.Empty;
            for (int i = Events.Count - 1; i >= 0; i--)
            {
                GameEvent currentEvent = Events.ElementAt(i);
                bool isCurrentTurn = ((currentEvent.Round == currentRound) && (currentEvent.Turn == currentTurn));
                eventString += (isCurrentTurn ? "<b>" : "") + (String.IsNullOrEmpty(currentEvent.Header) ? "" : currentEvent.Header + " ") + currentEvent.Message + (isCurrentTurn ? "</b>" : "") + "<br />";
            }
            return eventString;
            //return String.Join("<br />", Events.ToArray().Reverse());
        }

        public GameEvent LogGameEvent(int round, int turn, string header, string message)
        {
            GameEvent newEvent = new GameEvent(round, turn, header, message);
            return newEvent;
        }

        public void LogGameEvent(GameEvent newEvent)
        {
            if (Events.Count >= 10)
                Events.Dequeue();
            Events.Enqueue(newEvent);
        }
    }
}
