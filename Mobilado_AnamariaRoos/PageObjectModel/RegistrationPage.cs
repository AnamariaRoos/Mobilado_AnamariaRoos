using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        const string pageSelector = "#register-page > div > div.new-client-section.col-sm-7 > div.title-carousel > h1"; //css
        const string emailSelector = "__emailRegister"; //id
        const string nameSelector = "__lastnameRegister"; //id
        const string lastNameSelector = "__firstnameRegister"; //id
        const string passwordSelector = "__passwordRegister"; //id
        const string confirmPasswordSelector = "__confirmPasswordRegister"; //id
        const string newsletterSelector = "#_submitRegistration > div > div > label > div > input";//css
        const string termsAndCondSelector = "#_submitRegistration > div > div > p > label > div > input"; //css
        const string pageErr = "#_submitRegistration > div > p"; //css
        const string subbmitBtnSelector = "doRegister";//id
        const string acceptCookiesSelector = "#__gomagCookiePolicy"; //css

        public void AcceptCookie()
        {
            driver.FindElement(By.CssSelector(acceptCookiesSelector)).Click();

        }

        public Boolean CheckRegistrationPage(string pageText)
        {
            return String.Equals(pageText.ToLower(), driver.FindElement(By.CssSelector(pageSelector)).Text.ToLower());
        }

        public void Registration(string email, string name, string lastname, string password, string confirmpassword, bool acceptTerm)
        {

            var submitBtnInput = driver.FindElement(By.Id(subbmitBtnSelector));
            submitBtnInput.Click();

            var emailInput = Utilities.WaitForFluentElement(driver, 10, By.Id(emailSelector));
            //emailInput.Click();
            emailInput.SendKeys(email);

            var nameInput = driver.FindElement(By.Id(nameSelector));
            nameInput.Clear();
            nameInput.SendKeys(name);

            var lastNameInput = driver.FindElement(By.Id(lastNameSelector));
            lastNameInput.Clear();
            lastNameInput.SendKeys(lastname);

            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            var confirmPasswordInput = driver.FindElement(By.Id(confirmPasswordSelector));
            confirmPasswordInput.Clear();
            confirmPasswordInput.SendKeys(confirmpassword);

            var newsletterInput = driver.FindElement(By.CssSelector(newsletterSelector));
            newsletterInput.Click();
            
            var termsAndCondInput = driver.FindElement(By.CssSelector(termsAndCondSelector));
            if (acceptTerm)
            {
                termsAndCondInput.Click();
            }
            submitBtnInput.Click();

            if (!acceptTerm)
            {
                var pageErrInput = driver.FindElement(By.CssSelector(pageErr)).Text;
                Console.WriteLine(pageErrInput);
            }
        }

    }
}

    

