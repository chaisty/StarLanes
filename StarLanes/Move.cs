using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public enum MoveOutcome
    {
        DevelopSector = 0,
        ExpandCompany = 1,
        StartNewCompany = 2,
        Merger = 3,
        Blackhole = 4
    }

    public class Move
    {
        public int X { get; }
        public int Y { get; }
        public MoveOutcome Outcome { get; }

        public static string ToString(int x, int y)
        {
            return (char)(x + 65) + (y + 1).ToString();
        }

        public Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Move(int x, int y, MoveOutcome outcome) : this(x, y)
        {
            Outcome = outcome;
        }

        public override string ToString()
        {
            return Move.ToString(X, Y);
            //return (char)(X + 65) + (Y + 1).ToString();
        }
    }
}
