using System;
using System.Collections.Generic;

namespace StarLanes
{
    public class GalaxyMap
    {
        // Map Constants
        public const string MapTitle = "Map of the Galaxy";
        public const string ConsumedSector = "-";
        public const string EmptySector = ".";
        public const string DevelopedSector = "+";
        public const string StarSector = "*";
        public const string BlackholeSector = "@";

        public string[,] Sectors = new string[0, 0];


        // Constructors

        public GalaxyMap(int X_Dimension, int Y_Dimension)
        {
            Sectors = new string[X_Dimension, Y_Dimension];
        }

        public GalaxyMap(GalaxyMap mapToCopy)
        {
            Console.WriteLine("MAP SIZE TO COPY IS: " + mapToCopy.Sectors.GetUpperBound(0).ToString() + "," + mapToCopy.Sectors.GetUpperBound(1).ToString());
            Sectors = new string[mapToCopy.Sectors.GetUpperBound(0), mapToCopy.Sectors.GetUpperBound(1)];
            for (int x = 0; x <= mapToCopy.Sectors.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= mapToCopy.Sectors.GetUpperBound(1); y++)
                {
                    Sectors[x, y] = mapToCopy.Sectors[x, y];
                }
            }
        }

        public static GalaxyMap GetClone(GalaxyMap mapToClone)
        {
            GalaxyMap newMap = new GalaxyMap(mapToClone.X_Dimension, mapToClone.Y_Dimension);

            Console.WriteLine("OLD MAP DIM TO COPY IS: " + mapToClone.Sectors.GetUpperBound(0).ToString() + "," + mapToClone.Sectors.GetUpperBound(1).ToString());
            Console.WriteLine("NEW MAP DIM IS: " + newMap.Sectors.GetUpperBound(0).ToString() + "," + newMap.Sectors.GetUpperBound(1).ToString());
            for (int x = 0; x <= mapToClone.Sectors.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= mapToClone.Sectors.GetUpperBound(1); y++)
                {
                    newMap.Sectors[x, y] = mapToClone.Sectors[x, y];
                }
            }

            return newMap;
        }

        public string this[int x, int y]
        {
            get => Sectors[x, y];
            set => Sectors[x, y] = value;
        }

        // Properties

        public int X_UpperBound => Sectors.GetUpperBound(0);

        public int Y_UpperBound => Sectors.GetUpperBound(1);

        public int X_Dimension => X_UpperBound + 1;

        public int Y_Dimension => Y_UpperBound + 1;

        // Functions

        public string[] GetNeighbors(int x, int y)
        {
            string[] neighbors = new string[4] { " ", " ", " ", " " };  // Initialize to null space (null space is off the board)

            // Get adjacent values
            if (y > 0)
                neighbors[0] = Sectors[x, y - 1];

            if (x > 0)
                neighbors[1] = Sectors[x - 1, y];

            if (x < X_UpperBound)
                neighbors[2] = Sectors[x + 1, y];

            if (y < Y_UpperBound)
                neighbors[3] = Sectors[x, y + 1];

            return neighbors;
        }

        public List<string> AdjacentCompanies(int x, int y)
        {
            string[] neighbors = GetNeighbors(x, y);

            List<string> adjacentCompanies = new List<string>();
            foreach (string s in neighbors)
            {
                // If the sector contains a company and we have not already added this company
                if (("ABCDEFGHIJKL".Contains(s)) && (!adjacentCompanies.Contains(s)))
                    adjacentCompanies.Add(s);   // Add the company to the list
            }

            return adjacentCompanies;
        }

        public int NumberOfSymbolsOnMap(string symbol)
        {
            int size = 0;

            for (int x = Sectors.GetLowerBound(0); x <= Sectors.GetUpperBound(0); x++)
            {
                for (int y = Sectors.GetLowerBound(1); y <= Sectors.GetUpperBound(1); y++)
                {
                    if (Sectors[x, y] == symbol)
                        size++;
                }
            }

            return size;
        }

        public List<Move> OpenSectors()
        {
            List<Move> openSectors = new List<Move>();

            //Update Map
            for (int x = Sectors.GetLowerBound(0); x <= Sectors.GetUpperBound(0); x++)
            {
                for (int y = Sectors.GetLowerBound(1); y <= Sectors.GetUpperBound(1); y++)
                    if (Sectors[x, y] == EmptySector)
                    {
                        openSectors.Add(new Move(x, y));
                    }
            }

            return openSectors;
        }

        public void AddMovesToMap(Dictionary<int, Move> Moves)
        {
            foreach (var m in Moves)
            {
                Sectors[m.Value.X, m.Value.Y] = m.Key.ToString();
            }
        }

        public void RemoveMovesFromMap(Dictionary<int, Move> Moves)
        {
            foreach (Move m in Moves.Values)
            {
                Sectors[m.X, m.Y] = GalaxyMap.EmptySector;
            }
        }

        public int ReplaceSymbolOnMap(string oldValue, string newValue)
        {
            int replacements = 0;

            //Update Map
            for (int x = Sectors.GetLowerBound(0); x <= Sectors.GetUpperBound(0); x++)
            {
                for (int y = Sectors.GetLowerBound(1); y <= Sectors.GetUpperBound(1); y++)
                    if (Sectors[x, y] == oldValue)
                    {
                        Sectors[x, y] = newValue;
                        replacements++;
                    }
            }

            return replacements;
        }

        //Convert a string to map values - used for loading maps for things such as testing;
        private void StringToMapSection(string MapString, int StartX = 0, int Y = 0)
        {
            for (int x = 0; x < MapString.Length; x++)
            {
                if ((x + StartX) < X_UpperBound)
                    Sectors[x, Y] = MapString[x + StartX].ToString();
            }
        }

        //Convert an array of strings to map values - used for loading maps for things such as testing;
        private void StringToMapSection(string[] MapStrings, int StartX = 0, int StartY = 0)
        {
            for (int y = 0; y < MapStrings.GetUpperBound(0); y++)
            {
                if ((y + StartY) < X_UpperBound)
                    StringToMapSection(MapStrings[y], StartX, StartY);
            }
        }

        //prints the map using text string - for debugging purposes only
        public string PrintMap(bool showMoves, Dictionary<int, Move> AvailableMoves)
        {

            // Copy the Map so we can overlay the Moves
            string[,] Map2 = new string[X_UpperBound + 1, Y_UpperBound + 1];
            Array.Copy(Sectors, 0, Map2, 0, X_UpperBound * Y_UpperBound);

            // Add Moves on Map
            if (showMoves && (AvailableMoves != null))
            {
                for (int i = 1; i <= AvailableMoves.Count; i++)
                {
                    Map2[AvailableMoves[i].X, AvailableMoves[i].Y] = i.ToString();
                }
            }

            // Generate X-Axis Labels
            string mapString = "&nbsp&nbsp";
            for (int x = 0; x <= Map2.GetUpperBound(0); x++)
                mapString += ((char)(x + 65)).ToString() + "&nbsp&nbsp";
            mapString += "<br />";

            //Generate Rows
            for (int y = 0; y <= Map2.GetUpperBound(1); y++)
            {
                mapString += (y + 1).ToString() + " ";
                for (int x = 0; x <= Map2.GetUpperBound(0); x++)
                {
                    mapString += Map2[x, y] + "&nbsp&nbsp";
                }
                mapString += "<br>";
            }

            //Debug statments to list UBounds on Map Size
            //mapString += "x=" + Map2.GetUpperBound(0).ToString() + ", Y=" + Map2.GetUpperBound(1).ToString();

            return mapString;
        }
    }
}
