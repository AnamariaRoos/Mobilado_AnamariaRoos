using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.AddCart.LivingTests
{
    class LivingTests:BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        [Category("Living")]
        [Test]
        public void LivingCheckPageTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + livingUrlPath);
            LivingPage lv = new LivingPage(_driver);
            Assert.IsTrue(lv.CheckLivingPage("LIVING"));
        }

        [Category("Living")]
        [Test]
        public void LivingBeanbagsTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + livingUrlPath);
            LivingPage lv = new LivingPage(_driver);
            lv.AcceptCookie();
            lv.LivingHover();
            lv.LivingBeanbags();
            Assert.IsTrue(lv.CheckBeanbags("BEANBAGS"));
        }

        [Category("Living")]
        [Test]
        public void LivingHoverTest()
            {
               testName = TestContext.CurrentContext.Test.Name;
               _test = _extent.CreateTest(testName);
               _driver.Navigate().GoToUrl(url + livingUrlPath);
                LivingPage lv = new LivingPage(_driver);
                lv.LivingHover();   
            }

        [Category("Price")]
        [Test]
        public void SearchByPrice()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + livingUrlPath);
            LivingPage lv = new LivingPage(_driver);
            lv.AcceptCookie();
            lv.LivingHover();
            lv.LivingBeanbags();
            lv.BeanBagsSearchByPrice();
        }      
    }
}
