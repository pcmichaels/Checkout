using System;
using Checkout.Interface;

namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        public double TotalPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Scan(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
