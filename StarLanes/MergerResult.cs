using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public class MergerResult
    {
        public int PlayerId { get; private set; }
        public int NewShares { get; private set; }
        public int OldShares { get; private set; }
        public int TotalShares { get; set; }
        public int Dividend { get; set; }

        public MergerResult(int playerId, int newShares, int oldShares, int totalShares)
        {
            PlayerId = playerId;
            NewShares = newShares;
            OldShares = oldShares;
            TotalShares = totalShares;
        }
    }
}
