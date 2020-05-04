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
    }
}
