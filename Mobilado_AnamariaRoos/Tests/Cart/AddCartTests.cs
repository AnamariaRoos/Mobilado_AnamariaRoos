using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.AddCart
{
    class AddCartTests:BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        [Category("CartTest")]
        [Test]
        public void AddCartTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + livingUrlPath);
            LivingPage lv = new LivingPage(_driver);
            lv.AcceptCookie();
            lv.LivingHover();
            lv.LivingBeanbags();
            lv.AddCart();
            lv.SeeCart();
        }

        [Category("CartTest")]
        [Test]
        public void AddMoreProductsToCart()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + livingUrlPath);
            LivingPage lv = new LivingPage(_driver);
            lv.AcceptCookie();
            lv.LivingHover();
            lv.LivingBeanbags();
            lv.AddCart();
            lv.SeeCart();
            lv.AddMoreProductsToCart();
        }
    }
}
