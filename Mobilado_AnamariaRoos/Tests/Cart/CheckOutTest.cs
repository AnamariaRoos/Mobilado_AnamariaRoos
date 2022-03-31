using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.Cart
{

    class CheckOutTest:BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utilities.GetGenericData("TestData\\credentialsCheckOut.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void CheckOut(string email, string name, string firstName, string telephone, string adress, string message)
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
            CheckOutPage ck = new CheckOutPage(_driver);
            ck.CheckOut(email, name, firstName, telephone, adress, message);
        }
    }
}
