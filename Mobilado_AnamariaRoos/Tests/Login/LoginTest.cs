using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.Tests.Login
{
    class LoginTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utilities.GetGenericData("TestData\\credentialsLogin.csv"))
            {
                yield return new TestCaseData(values);
            }
        }
        
        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void LoginTests(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url + accountUrlPath);          
            LoginPage lp = new LoginPage(_driver);
            Assert.IsTrue(lp.CheckLoginPage("CONTUL TAU"));
            lp.Login(email, password);
            //Assert.IsTrue(lp.CheckAfterLoginPage("404 PAGE NOT FOUND"));
            
        }
    }
}
