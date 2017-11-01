using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Barclays;

namespace UnitTestProject1
{
    [TestClass]
    public class SupermarketTest
    {
        [TestMethod]
        public void PriceWithoutDiscount()
        {
            Checkout productlist = new Checkout();
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("B", "0.25"));
            productlist.AddProduct(new Product("A", "0.5"));
            Assert.AreEqual(productlist.Total(), 1.25);

        }

        [TestMethod]
        public void PriceWithDiscountA()
        {
            Checkout productlist = new Checkout();
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("B", "0.25"));
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.SetOffer(new BuySomthingGetDiscount("A", "A", 2, 100));
            productlist.CalculateDiscount();
            Assert.AreEqual(productlist.Total(), 0.75);

        }

        [TestMethod]
        public void PriceWithDiscountB()
        {
            Checkout productlist = new Checkout();
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("B", "0.25"));
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.SetOffer(new BuySomthingGetDiscount("A", "B", 3, 50));
            productlist.CalculateDiscount();
            Assert.AreEqual(productlist.Total(), 1.625);

        }

        [TestMethod]
        public void PriceWithDiscountC()
        {
            Checkout productlist = new Checkout();
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("B", "0.25"));
            productlist.AddProduct(new Product("C", "0.5"));
            productlist.AddProduct(new Product("C", "0.5"));
            productlist.AddProduct(new Product("C", "0.5"));
            productlist.SetOffer(new BuySomthingGetDiscount("C", "C", 3, 100));
            productlist.CalculateDiscount();
            Assert.AreEqual(productlist.Total(), 1.75);

        }

        [TestMethod]
        public void PriceWithAllDiscounts()
        {
            Checkout productlist = new Checkout();
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("B", "0.25"));
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("C", "0.75"));
            productlist.AddProduct(new Product("C", "0.75"));
            productlist.AddProduct(new Product("C", "0.75"));
            productlist.SetOffer(new BuySomthingGetDiscount("A", "A", 2, 100));
            productlist.CalculateDiscount();
            productlist.SetOffer(new BuySomthingGetDiscount("A", "B", 3, 50));
            productlist.CalculateDiscount();
            productlist.SetOffer(new BuySomthingGetDiscount("C", "C", 3, 100));
            productlist.CalculateDiscount();

            Assert.AreEqual(productlist.Total(), 2.625);

        }

        [TestMethod]
        public void PriceWithAllDiscountsThenNotEnoughProducts()
        {
            Checkout productlist = new Checkout();
            productlist.AddProduct(new Product("A", "0.5"));
            productlist.AddProduct(new Product("B", "0.25"));
            productlist.AddProduct(new Product("C", "0.75"));
            productlist.AddProduct(new Product("C", "0.75"));
            productlist.SetOffer(new BuySomthingGetDiscount("A", "A", 2, 100));
            productlist.CalculateDiscount();
            productlist.SetOffer(new BuySomthingGetDiscount("A", "B", 3, 50));
            productlist.CalculateDiscount();
            productlist.SetOffer(new BuySomthingGetDiscount("C", "C", 3, 100));
            productlist.CalculateDiscount();

            Assert.AreEqual(productlist.Total(), 2.25);

        }
    }

}
