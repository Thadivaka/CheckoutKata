using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    /// <summary>
    /// Class <c>Checkout</c> scans multiple Items and calculates the total price.
    /// </summary>
    public class Checkout : ICheckout
    {
        private readonly IEnumerable<StockUnit> _stockUnits;
        private readonly IList<string> m_ScanItems = new List<string>();

        /// <summary>
        /// Creates object to the Checkout class takes stocksUnits as a prameter.
        /// </summary>
        /// <param name="stockUnits"></param>
        public Checkout(IEnumerable<StockUnit> stockUnits)
        {
            _stockUnits = stockUnits;
        }

        /// <summary>
        /// Method <c>GetTotalPrice</c> Calculates the total price
        /// </summary>
        /// <returns>Total price integer value</returns>
        public int GetTotalPrice()
        {
            int totalPrice = 0;
            // Grouping all the scan Sku item.
            var groupByScanItems = (from scanItem in m_ScanItems
                            group scanItem by scanItem into groupItems
                            select new Scan { Sku = groupItems.Key, Count = groupItems.Count() }).ToList();

            // Looping through each scan item and calculating the total
            foreach (var scanItemGroup in groupByScanItems)
            {
                // Checking weather the scan items contains in the stockUnits
                if (_stockUnits.Any(k => k.SkuName.ToLower() == scanItemGroup.Sku.ToLower()))
                {
                    // Filtering stock units with sku
                    var filteringStockUnit = _stockUnits.Where(km => km.SkuName.ToLower() == scanItemGroup.Sku.ToLower())
                                                    .Select(x => new { x.UnitPrice, x.Volume, x.SpecialPrice }).FirstOrDefault();

                    // Calculate the discount with volume greater than 1
                    if (filteringStockUnit.Volume > 1)
                    {
                        // This produces the quotient of the scan items count and volume
                        var quotientValue = scanItemGroup.Count / filteringStockUnit.Volume;
                        // This produces reminder
                        var reminderValue = scanItemGroup.Count % filteringStockUnit.Volume;

                        // This computes quotientValue with special price
                        var offerPrice = quotientValue * filteringStockUnit.SpecialPrice;
                        // This computes reminderValue with unit price
                        var currentPrice = reminderValue * filteringStockUnit.UnitPrice;

                        totalPrice += offerPrice + currentPrice;
                    }
                    else
                    {
                        totalPrice += scanItemGroup.Count * filteringStockUnit.UnitPrice;
                    }

                }
            }
            return totalPrice;
        }

        /// <summary>
        /// Method <c>Scan</c> adds scan item
        /// </summary>
        /// <param name="item">sku item</param>
        public void Scan(string item)
        {
            if(!string.IsNullOrEmpty(item))
            {
                m_ScanItems.Add(item);
            }
        }
    }
}
