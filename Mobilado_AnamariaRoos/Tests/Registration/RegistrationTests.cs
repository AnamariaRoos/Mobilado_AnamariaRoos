using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.Registration
{
    class RegistrationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utilities.GetGenericData("TestData\\credentialsRegistration.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category("RegistrationTests")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void RegistrationTest(string email, string name, string lastname, string password, string confirmpassword, string acceptTerm)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + accountUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            rp.AcceptCookie();
            Assert.IsTrue(rp.CheckRegistrationPage("CLIENT NOU: INREGISTRARE"));
            rp.Registration(email, name, lastname, password, confirmpassword, bool.Parse(acceptTerm));

        }
    }
}
