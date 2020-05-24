using System.Collections.Generic;
using System.Linq;

namespace StarLanes
{
    public class Company
    {
        public string Name { get; }
        public string Symbol { get; }
        public int ShareValue { get; set; }
        public int SplitOffset { get; set; } = 0;
        public bool IsActive { get; private set; }
        public Dictionary<int, int> StockHolderShares { get; set; }
        public static Dictionary<int, string> CompanyNames = new Dictionary<int, string>()
        {
            { 1, "Altair Starways" },
            { 2, "Betelgeuse, Ltd" },
            { 3, "Capella Frieght" },
            { 4, "Denebola Shippers" },
            { 5, "Eridani Expediters" },
            { 6, "Fornax Freightways" },
            { 7, "Gemini Delivery" },
            { 8, "Hydra Transportion"},
            { 9, "Izar Couriers" },
            { 10, "Jabbah Express" },
            { 11, "Kochab Lines" },
            { 12, "Lupi Transgalactic" }
        };

        public static int KeyFromSymbol(string symbol)
        {
            int key = 0;

            if (symbol.Length > 0)
            {
                key = symbol[0] - 64;
            }

            return key;
        }

        public Company(int index, int potentialStockHolders) : this(CompanyNames[index], CompanyNames[index][0].ToString(), potentialStockHolders)
        {
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

        public Company GetClone()
        {
            Company newCompany = new Company(Name, Symbol, StockHolderShares.Count); // (Company)this.MemberwiseClone();
            newCompany.ShareValue = ShareValue;
            newCompany.SplitOffset = SplitOffset;
            newCompany.IsActive = IsActive;
            for (int p = 1; p <= StockHolderShares.Count; p++)
            {
                newCompany.StockHolderShares[p] = StockHolderShares[p];
                ;
            }

            return newCompany;
        }

        private void OpenCompany()
        {
            ShareValue = 100;
            SplitOffset = 0;
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
            SplitOffset = 0;
            for (int p = 1; p <= StockHolderShares.Count; p++)
            { StockHolderShares[p] = 0; }
            IsActive = false;
        }

        public int OutstandingShares()
        {
            return StockHolderShares.Sum(v => v.Value);
        }

        public void SplitStock(int SplitPrice)
        {
            // Split Share Price in half
            ShareValue = ShareValue / 2;
            SplitOffset += ShareValue;
            // Double share counts for stockholders
            for (int p = 1; p <= StockHolderShares.Count; p++)
            {
                StockHolderShares[p] += StockHolderShares[p]; //double the shares
            }
        }
    }
}
