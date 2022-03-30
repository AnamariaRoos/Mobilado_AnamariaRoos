using Mobilado_AnamariaRoos.PageObjectModel;
using Mobilado_AnamariaRoos.Utils;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FrameworkConstants = Mobilado_AnamariaRoos.Utils.FrameworkConstants;

namespace Mobilado_AnamariaRoos.Tests.Authentication
{
    public class MainPageTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Category("MainPage")]
        [Test]
        public void MainPagePositive()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookie();
            mp.MoveToAccount();
            mp.MoveToMainPage();
        }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utilities.GetGenericData("TestData\\credentialssearch.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Category("MainPage")]
        [Test, TestCaseSource("GetCredentialsDataCsv")]
        public void SearchTest(string search)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.VerifySearch(search);
            mp.VerifySearchCheck();
        }

        
    }
}
