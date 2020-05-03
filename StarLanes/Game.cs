using System;
using System.Collections.Generic;
using System.Linq;

namespace StarLanes

{
    public class Game
    {

        public Dictionary<int, Player> Players = new Dictionary<int, Player>();

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
                rankvalues.Add(p.Key, Players[p.Key].NetWorth * (long)100000000 + Players[p.Key].StockWorth * 10 + p.Key);
            }

            var results = rankvalues.OrderByDescending(p => p.Value);

            Dictionary<int, int> ranking = new Dictionary<int, int>();

            foreach (KeyValuePair<int, long> pair in results)
            {
                ranking.Add(pair.Key, ranking.Count + 1);
            }

            return ranking;
        }
    }
}
