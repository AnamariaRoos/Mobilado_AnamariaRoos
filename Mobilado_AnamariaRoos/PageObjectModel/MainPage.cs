using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    class MainPage : BasePage

    {
        const string acceptCookiesSelector = "#__gomagCookiePolicy"; //css
        const string accountBtnSelector = "#wrapper > header > div.top-head-bg.container-h.full > div > div > div.col-md-5.col-sm-5.acount-section > ul > li.-g-user-icon > a > i"; //css
        const string searchSelector = "_autocompleteSearchMainHeader";//id
        const string searchBtnSelector = "_doSearch";//id
        const string searchBtnVerify = "#wrapper > div.container-h.container-bg.-g-breadcrumbs-container > div > ol > li:nth-child(2) > a";//css
        const string pageLabelSelector = "#logo > img";//css
        public MainPage(IWebDriver driver) : base(driver)
        {
           
        }

        public void AcceptCookie()
        {
           driver.FindElement(By.CssSelector(acceptCookiesSelector)).Click();
           
        }

        public void MoveToAccount()
        {
            driver.FindElement(By.CssSelector(accountBtnSelector)).Click();
        }

        public void VerifySearch(string search)
        {
            var searchInput = driver.FindElement(By.Id(searchSelector));
            searchInput.Clear();
            searchInput.SendKeys(search);
            var searchBtnInput = driver.FindElement(By.Id(searchBtnSelector));
            searchBtnInput.Click();
        }

        public string VerifySearchCheck()
        {
            return driver.FindElement(By.CssSelector(searchBtnVerify)).Text;
        }

        public void MoveToMainPage()
        {
            var pageLabelInput = driver.FindElement(By.CssSelector(pageLabelSelector));
            pageLabelInput.Click();
        }
    }
}
