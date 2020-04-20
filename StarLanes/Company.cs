using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarLanes
{
    public class Company
    {
        public string Name { get; }
        public string Symbol { get; }
        public int ShareValue { get; set; }
        public bool IsActive { get; private set; }
        public Dictionary<int, int> StockHolderShares { get; set; }

        public static int KeyFromSymbol(string symbol)
        {
            int key = 0;

            if (symbol.Length > 0)
            {
                key = (int)(symbol[0]) - 64;
            }

            return key;
        }

        public Company(string name, string symbol, int potentialStockHolders)
        {
            Name = name;
            Symbol = symbol;
            ShareValue = 0;
            StockHolderShares = new Dictionary<int, int>();
            for (int p = 1; p <= potentialStockHolders; p++)
            {
                StockHolderShares[p] = 0;
            }

        }

        private void OpenCompany()
        {
            ShareValue = 100;
            IsActive = true;
        }

        public void OpenCompany(int founder, int founderShares)
        {
            OpenCompany();
            StockHolderShares[founder] = founderShares;
        }

        public void CloseCompany()
        {
            ShareValue = 0;
            for (int p = 1; p <= StockHolderShares.Count; p++)
            { StockHolderShares[p] = 0; }
            IsActive = false;
        }

        public int OutstandingShares()
        {
            return StockHolderShares.Sum(v => v.Value);
        }
    }
}
