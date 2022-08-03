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
                new StockUnit { SkuName = "A", Price = 50, SpecialDiscountCount = 3, SpecialDiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, SpecialDiscountCount = 2, SpecialDiscountPrice = 45 },
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
                new StockUnit { SkuName = "A", Price = 50, SpecialDiscountCount = 3, SpecialDiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, SpecialDiscountCount = 2, SpecialDiscountPrice = 45 },
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
                new StockUnit { SkuName = "A", Price = 50, SpecialDiscountCount = 3, SpecialDiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, SpecialDiscountCount = 2, SpecialDiscountPrice = 45 },
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
                new StockUnit { SkuName = "A", Price = 50, SpecialDiscountCount = 3, SpecialDiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, SpecialDiscountCount = 2, SpecialDiscountPrice = 45 },
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
                new StockUnit { SkuName = "A", Price = 50, SpecialDiscountCount = 3, SpecialDiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, SpecialDiscountCount = 2, SpecialDiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("D");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 15);
        }
    }
}
