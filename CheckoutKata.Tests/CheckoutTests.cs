﻿using CheckoutKata.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void GetTotalPrice_AddingSingle_Sku_A_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 50);
        }

        [TestMethod]
        public void GetTotalPrice_AddingSingle_Sku_A_2()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("A");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 100);
        }

        [TestMethod]
        public void GetTotalPrice_AddingSingle_Sku_B_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("B");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 30);
        }

        [TestMethod]
        public void GetTotalPrice_AddingSingle_Sku_C_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("C");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void GetTotalPrice_AddingSingle_Sku_D_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("D");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 15);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Sku_A_3()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 130);
        }

        [TestMethod]
        public void GetTotalPrice_Adding_Sku_B_2()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("B");
            checkout.Scan("B");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 45);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Sku_A_3_B_2_Systematic()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 175);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Sku_A_3_B_2_NonSystematic()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 175);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Sku_A_3_B_2_C_1_NonSystematic()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("C");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 195);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Sku_A_3_B_2_C_1_D_1_NonSystematic()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("D");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 210);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_NonSystematic_Sku_A_4_B_3_C_1_D_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("D");
            checkout.Scan("A");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 290);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_NonSystematic_Sku_A_5_B_5_C_1_D_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            Assert.AreEqual(checkout.GetTotalPrice(), 50);
            checkout.Scan("B");
            Assert.AreEqual(checkout.GetTotalPrice(), 80);
            checkout.Scan("A");
            Assert.AreEqual(checkout.GetTotalPrice(), 130);
            checkout.Scan("B");
            Assert.AreEqual(checkout.GetTotalPrice(), 145);
            checkout.Scan("C");
            Assert.AreEqual(checkout.GetTotalPrice(), 165);
            checkout.Scan("A");
            Assert.AreEqual(checkout.GetTotalPrice(), 195);
            checkout.Scan("B");
            Assert.AreEqual(checkout.GetTotalPrice(), 225);
            checkout.Scan("D");
            Assert.AreEqual(checkout.GetTotalPrice(), 240);
            checkout.Scan("A");
            Assert.AreEqual(checkout.GetTotalPrice(), 290);
            checkout.Scan("A");
            Assert.AreEqual(checkout.GetTotalPrice(), 340);
            checkout.Scan("B");
            Assert.AreEqual(checkout.GetTotalPrice(), 355);
            checkout.Scan("B");
            Assert.AreEqual(checkout.GetTotalPrice(), 385);
        }
    }
}
