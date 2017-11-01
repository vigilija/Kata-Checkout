using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barclays
{
    public class Product : IProduct

    {
        public string Cost { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public Product(string Name, string Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }
    }

}
