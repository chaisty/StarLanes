using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    // Events objects for relaying game eent updates to players
    public class GameEvent
    {
        public readonly int Turn;
        public readonly string Message;

        public GameEvent(int turn, string message)
        {
            Turn = turn;
            Message = message;
        }
    }
}
