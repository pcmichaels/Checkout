using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interface
{
    public interface IPriceEngine
    {
        decimal Calculate(string sku, int quantity);

        bool Validate(string sku);
    }
}
