using System.Collections.Generic;
using System.Net.NetworkInformation;
using System;

namespace StarLanes
{
    public class Player
    {
        public enum Personas
        {
            Human = 0,
            Maximillian = 1, // Maximillian - avoids black holes, biased toward mergers
            WOPR = 2, // WOPR - prefers to destroy his opponents
            HAL9000 = 3, // HAL 9001 - biased toward expansion
            ERNIE = 4 // ERNIE (will choose an entirely random move)
        }

        public string Name { get; private set; }
        public long Money { get; set; }
        public Dictionary<int, int> StockShares { get; set; }
        public Personas Persona { get; set; } = Personas.Human;
        //private string[] PersonaName = new string[Enum.Getnames( Persona]
        //public long StockWorth { get; set; } = 0;
        public int Rank { get; set; } = 0;
        //public long NetWorth { get { return StockWorth + Money; } }
        public string IconPath { get; set; }

        public Player(string name, long money)
        {
            Name = name;
            Money = money;
        }

        public Player(string name, long money, Personas persona) : this(name, money)
        {
            Persona = persona;
        }

        public Player GetClone()
        {
            Player newPlayer = (Player)this.MemberwiseClone();

            return newPlayer;
        }

        public bool IsHuman => (Persona == Personas.Human);

        public bool IsComputer => (!IsHuman);

        public static Personas RandomComputerPersona()
        {
            Random rand = new Random();
            return (Personas)rand.Next(1, Enum.GetValues(typeof(Personas)).Length);

        }

        public void SetDefaultName(int instance)
        {
            Name = DefaultName(Persona, instance);
        }

        public static string DefaultName(Personas persona, int instance)
        { 
            switch (persona)
            {
                case Personas.Human:
                    return "Player " + instance.ToString();
                case Personas.Maximillian:
                    return instance == 1 ? "Maximillian" : instance == 2 ? "Maxine" : instance == 3 ? "Maximus" : instance == 4 ? "Maxwell" : instance == 5 ? "Maxim" : "Max";
                case Personas.ERNIE:
                    return instance == 1 ? "ERNIE" : instance == 2 ? "Ernestine" : instance == 3 ? "Ernesto" : instance == 4 ? "Errorbot" : instance == 5 ? "Erna" : "Ermine";
                case Personas.HAL9000:
                    return instance == 1 ? "HAL 9000" : instance == 2 ? "ALLIE 8080" : instance == 3 ? "ALTAIR 8000" : instance == 4 ? "Dave Bowman" : "VIC 20";
                case Personas.WOPR:
                    return instance == 1 ? "WOPR" : instance == 2 ? "WHOMPER" : instance == 3 ? "WUMPUS" : instance == 4 ? "V-GER" : "AIVAS";
                default:
                    return persona.ToString() + " " + instance.ToString();

            }
        }



    }
}
