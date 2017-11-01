using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barclays
{

    public interface IProduct
    {
        string Name { get; set; }
        string Cost { get; set; }
    }
   
    public interface ICheckout
    {
        void AddProduct(IProduct product);
        float Total();
    }
 
}
