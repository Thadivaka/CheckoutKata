using CheckoutKata.Interface;
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
        public void GetTotalPrice_Adding_Sku_A_RuleChange_A_4_B_3()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 1, DiscountPrice = 130 },
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
            checkout.Scan("B");
            checkout.Scan("A");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 275);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Sku_A_RuleChange_A_4_B_4()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 1, DiscountPrice = 130 },
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
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 290);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_RuleChange_Sku_A_1_B_2_C_4()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("C");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 155);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_RuleChange_Sku_A_1_B_2_C_2_D_5()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15, NumberOfItems = 5, DiscountPrice = 55 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("D");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("C");
            checkout.Scan("B");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 190);
        }
        [TestMethod]
        public void GetTotalPrice_RuleChange_Sku_A_3_B_2_C_4_D_5_E_1()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15, NumberOfItems = 5, DiscountPrice = 55 },
                new StockUnit { SkuName = "E", Price = 100 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("c");
            checkout.Scan("B");
            checkout.Scan("c");
            checkout.Scan("d");
            checkout.Scan("c");
            checkout.Scan("c");
            checkout.Scan("d");
            checkout.Scan("d");
            checkout.Scan("A");
            checkout.Scan("d");
            checkout.Scan("d");
            checkout.Scan("e");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 390);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Empty_Sku()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15, NumberOfItems = 5, DiscountPrice = 55 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan(string.Empty);

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 50);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_Null_Sku()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15, NumberOfItems = 5, DiscountPrice = 55 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("A");
            checkout.Scan(null);

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 50);
        }
        [TestMethod]
        public void GetTotalPrice_Adding_NonConfigure_Sku()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15, NumberOfItems = 5, DiscountPrice = 55 }
            };
            ICheckout checkout = new Checkout(rules);
            checkout.Scan("F");

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void GetTotalPrice_GetTotalPrice_Without_Scan()
        {
            IEnumerable<StockUnit> rules = new List<StockUnit>
            {
                new StockUnit { SkuName = "A", Price = 50, NumberOfItems = 3, DiscountPrice = 130 },
                new StockUnit { SkuName = "B", Price = 30, NumberOfItems = 2, DiscountPrice = 45 },
                new StockUnit { SkuName = "C", Price = 20, NumberOfItems = 4, DiscountPrice = 60 },
                new StockUnit { SkuName = "D", Price = 15, NumberOfItems = 5, DiscountPrice = 55 }
            };
            ICheckout checkout = new Checkout(rules);

            var result = checkout.GetTotalPrice();

            Assert.AreEqual(result, 0);
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
