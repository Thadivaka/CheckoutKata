using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly IEnumerable<StockUnit> _stockUnits;
        private readonly IList<string> m_ScanItems = new List<string>();
        public Checkout(IEnumerable<StockUnit> stockUnits)
        {
            _stockUnits = stockUnits;
        }
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
