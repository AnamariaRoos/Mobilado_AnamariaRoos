using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    class LogOutPage : BasePage
    {

        const string accountSelector = "#wrapper > header > div.top-head-bg.container-h.full > div > div > div.col-md-5.col-sm-5.acount-section > ul > li.-g-user-icon.-g-user-loggedin-icon > a > i";//css
        const string logOutSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.side-menu.col-lg-3.col-md-3.col-sm-12.col-xs-12 > div.row > ul:nth-child(5) > li > a";

        public LogOutPage(IWebDriver driver) : base(driver)
        {
        }

        public void LogOut()
        {
            var accountInput = driver.FindElement(By.CssSelector(accountSelector));
            accountInput.Click();

            var logOutInput = driver.FindElement(By.CssSelector(logOutSelector));
            logOutInput.Click();
        }
    }
}
