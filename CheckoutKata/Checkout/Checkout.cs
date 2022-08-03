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
            var scanData = (from c in m_ScanItems
                            group c by c into g
                            select new Scan { Sku = g.Key, Count = g.Count() }).ToList();
            foreach (var scanItem in scanData)
            {
                if (_stockUnits.Any(k => k.SkuName == scanItem.Sku))
                {
                    var items = _stockUnits.Where(km => km.SkuName == scanItem.Sku)
                                                    .Select(x => new { x.Price, x.NumberOfItems, x.DiscountPrice }).FirstOrDefault();
                    if (items.NumberOfItems > 0)
                    {
                        var discountCount = scanItem.Count / items.NumberOfItems;
                        var nonDisountCount = scanItem.Count % items.NumberOfItems;

                        var itemSpecialPrice = discountCount * items.DiscountPrice;
                        var itemNormalPrice = nonDisountCount * items.Price;

                        totalPrice += itemSpecialPrice + itemNormalPrice;
                    }
                    else
                    {
                        totalPrice += scanItem.Count * items.Price;
                    }

                }
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            m_ScanItems.Add(item);
        }
    }
}
