using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Barclays
{
    public class BuySomthingGetDiscount : Offer
    {
        public string typeRequired;
        public string typeDiscounted;
        public int quantitiRequired;
        public int discount;
        private float pp = 0;

        public BuySomthingGetDiscount(string typeRequired, string typeDiscounted, int quantitiRequired, int discount)
        {
            this.typeRequired = typeRequired;
            this.typeDiscounted = typeDiscounted;
            this.quantitiRequired = quantitiRequired;
            this.discount = discount;
        }
        public override void CalculateDiscount(IEnumerable<IProduct> product)
        {
            int count = 0;
     
            IEnumerable<IProduct> ProductsToDiscount = product.Where(p => p.Name.Equals(typeDiscounted));
            IEnumerable<IProduct> RequiredProducts = product.Where(p => p.Name.Equals(typeRequired));
            int RequiredProductsCount= RequiredProducts.Count();
            int HowManyProductsDiscount;
                HowManyProductsDiscount = RequiredProductsCount - (RequiredProductsCount % quantitiRequired);
                foreach (Product fproduct in ProductsToDiscount)
                {
                     if (count.Equals(HowManyProductsDiscount))
                    {
                        break;
                    }
                    pp = float.Parse(fproduct.Cost, CultureInfo.InvariantCulture.NumberFormat);
                    pp = pp - (pp * discount / 100);
                    fproduct.Cost = pp.ToString(CultureInfo.InvariantCulture.NumberFormat);
                    count=count + quantitiRequired;
                }
        }
    }
}
