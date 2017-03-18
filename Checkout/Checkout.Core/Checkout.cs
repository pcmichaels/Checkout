using System;
using Checkout.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        Dictionary<string, int> _scannedItems = new Dictionary<string, int>();
        PriceTable _priceTable;

        public Checkout(PriceTable priceTable)
        {
            _priceTable = priceTable;
        }

        /// <summary>
        /// Makes sense as a function because the calculation should be donen here
        /// and potentially reduce load        
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalPrice()
        {
            decimal runningTotal = 0;

            // Iterate through the scanned items and add up the running total
            foreach (var item in _scannedItems)
            {
                ItemPrice itemPrice = _priceTable.ItemPrices.Single(a => a.SKU == item.Key);
                if (itemPrice.Threshold.HasValue && item.Value >= itemPrice.Threshold)
                {
                    runningTotal += (item.Value / itemPrice.Threshold.Value) * itemPrice.GroupPrice;
                    runningTotal += (item.Value % itemPrice.Threshold.Value) * itemPrice.UnitPrice;
                }
                else
                {
                    runningTotal += item.Value * itemPrice.UnitPrice;
                }
            }

            return runningTotal;
        }

        public void Scan(string sku)
        {
            if (!_priceTable.ItemPrices.Any(a => a.SKU == sku))
            {
                throw new ArgumentException();
            }

            if (_scannedItems.ContainsKey(sku))
            {
                _scannedItems[sku]++;
            }
            else
            {
                _scannedItems.Add(sku, 1);
            }
        }
    }
}
