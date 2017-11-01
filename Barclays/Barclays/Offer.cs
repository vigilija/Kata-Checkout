using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barclays
{
    public abstract class Offer
    {
        public abstract void CalculateDiscount(IEnumerable<IProduct> product);
    }
}
