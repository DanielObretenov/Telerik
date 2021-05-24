using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Common.Enums;
using Telerik.Pages;
using Telerik.Utils;

namespace Telerik.Tests
{
    [TestFixture]
    class Test : BaseTest
    {
        PurchasePage purchasePage;

       // [Test]

        public void AddProductsToCart()
        {
            purchasePage = new PurchasePage(driverUtils.GetDriver());
        }
    }
}
