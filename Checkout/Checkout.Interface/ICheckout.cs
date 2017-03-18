using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interface
{
    public interface ICheckout
    {
        decimal GetTotalPrice();

        void Scan(string sku);        
    }
}
