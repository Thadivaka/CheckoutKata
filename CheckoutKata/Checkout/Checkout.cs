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
            int totalPrice = 0;
            foreach(var item in m_ScanItems)
            {
                var itemPrice = _stockUnits.Where(s => s.SkuName == item).Select(x => x.Price).FirstOrDefault();

                totalPrice += itemPrice;
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            m_ScanItems.Add(item);
        }
    }
}
