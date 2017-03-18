using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interface
{
    public interface ICheckout
    {
        double TotalPrice { get; set; }

        void Scan(string sku);        
    }
}
