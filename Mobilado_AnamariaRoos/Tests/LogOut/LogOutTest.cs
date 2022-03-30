using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.LogOut
{
    class LogOutTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [TestCase("adriana@yahoo.com", "123456")]
        [Test]
        public void LogOut(string email,string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + accountUrlPath);
            LoginPage lp = new LoginPage(_driver);
            lp.Login(email,password);
            Assert.IsTrue(lp.CheckAfterLoginPage("404 PAGE NOT FOUND"));
            LogOutPage lg = new LogOutPage(_driver);
            lg.LogOut();

        }
    }
}
