using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    // Events objects for relaying game eent updates to players
    public class GameEvent
    {
        public readonly int Round;
        public readonly int Turn = 0;
        public readonly string Header = string.Empty;
        public readonly string Message;


        public GameEvent(int round, string message)
        {
            Round = round;
            Message = message;
        }

        public GameEvent(int round, int turn, string message) : this (round, message)
        {
            Turn = turn;
        }

        public GameEvent(int round, int turn, string header, string message) : this (round, turn, message)
        {
            Header = header;
        }
    }
}
