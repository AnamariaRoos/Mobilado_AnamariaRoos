using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    public class LoginPage : BasePage
    {
        const string pageLoginSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.title-carousel > h1";//css
        const string emailSelector = "#_loginEmail"; //css
        const string passwordSelector = "_loginPassword"; //id
        const string loginBtnSelector = "#doLogin"; //css
        const string loginPageTextSelector = "#result-page > div.container-bg.titleComponent.container-h.gomagComponent.-g-component-id- > h1";//css


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public Boolean CheckLoginPage( string pageText)
        {
            return String.Equals(pageText.ToLower(), driver.FindElement(By.CssSelector(pageLoginSelector)).Text.ToLower());
        }

        public void Login( string email, string password)
        {
            var emailInput = driver.FindElement(By.CssSelector(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);

            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            var loginBtnInput = driver.FindElement(By.CssSelector(loginBtnSelector));
            loginBtnInput.Click();

        }

        public Boolean CheckAfterLoginPage(string loginPageText)
        {
            return String.Equals(loginPageText.ToLower(), driver.FindElement(By.CssSelector(loginPageTextSelector)).Text.ToLower());
        }

    }
}
