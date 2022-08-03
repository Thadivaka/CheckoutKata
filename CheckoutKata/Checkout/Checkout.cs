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
            var groupByScanItems = (from scanItem in m_ScanItems
                            group scanItem by scanItem into groupItems
                            select new Scan { Sku = groupItems.Key, Count = groupItems.Count() }).ToList();
            foreach (var scanItemGroup in groupByScanItems)
            {
                if (_stockUnits.Any(k => k.SkuName.ToLower() == scanItemGroup.Sku.ToLower()))
                {
                    var filteringStockUnit = _stockUnits.Where(km => km.SkuName.ToLower() == scanItemGroup.Sku.ToLower())
                                                    .Select(x => new { x.Price, x.NumberOfItems, x.DiscountPrice }).FirstOrDefault();
                    if (filteringStockUnit.NumberOfItems > 1)
                    {
                        var discountCount = scanItemGroup.Count / filteringStockUnit.NumberOfItems;
                        var nonDisountCount = scanItemGroup.Count % filteringStockUnit.NumberOfItems;

                        var itemDiscountPrice = discountCount * filteringStockUnit.DiscountPrice;
                        var itemNormalPrice = nonDisountCount * filteringStockUnit.Price;

                        totalPrice += itemDiscountPrice + itemNormalPrice;
                    }
                    else
                    {
                        totalPrice += scanItemGroup.Count * filteringStockUnit.Price;
                    }

                }
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            if(!string.IsNullOrEmpty(item))
            {
                m_ScanItems.Add(item);
            }
        }
    }
}
