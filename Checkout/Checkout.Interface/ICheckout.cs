using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interface
{
    public class ICheckout
    {
        public double TotalPrice { get; set; }

        public void Scan(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
