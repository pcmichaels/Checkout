using Checkout.Core;
using Checkout.Interface;
using Checkout.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            PriceTable priceTable = PriceTableFactory.GetDefaultPriceTable();
            PriceEngine priceEngine = new PriceEngine(priceTable);
            ICheckout checkout = new Checkout.Core.Checkout(priceEngine);

            while (true)
            {
                Console.Write("SKU: ");
                string sku = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sku))
                {
                    break;
                }
                checkout.Scan(sku);
            }

            Console.WriteLine($"Total price: {checkout.GetTotalPrice()}");
            Console.ReadLine();
        }
    }
}
