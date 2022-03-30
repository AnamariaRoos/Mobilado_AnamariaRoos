using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.Contact
{
    
    class ContactTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();
        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utilities.GetGenericData("TestData\\credentialsContact.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsv")]

        public void ContactTests(string email, string name, string telephone, string message, string agree)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookie();
            ContactPage ct = new ContactPage(_driver);
            
        }
    }
}
