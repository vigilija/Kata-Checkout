using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barclays
{
    public class Checkout : ICheckout

    {
        public List<IProduct> _product = new List<IProduct>();
        public Offer _offer;

        private void SetPrice(Offer pOffer)
        {
            this._offer = pOffer;
        }

        public void SetOffer(Offer offer)
        {
            this._offer = offer;
        }

        public void CalculateDiscount()
        {
            _offer.CalculateDiscount(_product);

        }


        public void AddProduct(IProduct product)
        {
            this._product.Add(product);

        }
        public float Total()
        {
            return _product.Sum(r => float.Parse(r.Cost, CultureInfo.InvariantCulture.NumberFormat));
        }

    }
}
