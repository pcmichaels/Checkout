using System;
using Checkout.Interface;
using System.Collections;

namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        Queue _scannedItems = new Queue();

        public Checkout(PriceTable priceTable)
        {

        }

        public double TotalPrice { get; set; }

        public void Scan(string sku)
        {
         
        }
    }
}
