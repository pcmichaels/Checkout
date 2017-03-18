using System;
using Checkout.Interface;
using System.Collections;

namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        Queue _scannedItems = new Queue();
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
        public double GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string sku)
        {
            _scannedItems.Enqueue(sku);
        }
    }
}
