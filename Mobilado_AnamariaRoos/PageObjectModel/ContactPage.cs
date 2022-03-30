using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    public class ContactPage : BasePage
    {
        const string contactBtnSelector = "#-g-footer-general > div > div > div:nth-child(1) > div > ul > li:nth-child(4) > a"; //css
        const string pageTextSelector = "#contact-page > div.row > div.contact-form.col-sm-6 > div > h3"; //css
        const string emailSelector = "email";//id
        const string emailErrSelector = "#-g-contact-form > div:nth-child(2) > span";//css
        const string nameSlector = "#-g-contact-form > div:nth-child(2) > input";//css
        const string nameErrSelector = "#-g-contact-form > div:nth-child(3) > span";//css
        const string telephoneSelector = "#-g-contact-form > div:nth-child(3) > input";//css
        const string telephoneErrSelector = "#-g-contact-form > div:nth-child(4) > span";//css
        const string messageSelector = "#-g-contact-form > div.c-row.textarea > textarea";
        const string messageErrSelector = "#-g-contact-form > div.c-row.textarea > span";//css
        const string agreeSelector = "#-g-contact-form > p > label > div > input";
        const string agreeErrSelector = "#-g-contact-form > p.register-terms.hint-login > label";//css
        const string sendMessageSelector = "sendMessage";//id

        public ContactPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToContactPage()
        {
            driver.FindElement(By.CssSelector(contactBtnSelector)).Click();
        }

        public Boolean CheckContactPage(string pageText)

        {
            return String.Equals(pageText.ToLower(), driver.FindElement(By.CssSelector(pageTextSelector)).Text.ToLower());
        }

        public void Contact(string email, string name, string telephone, string message, bool agree)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);

            var nameInput = driver.FindElement(By.CssSelector(nameSlector));
            nameInput.Clear();
            nameInput.SendKeys(name);

            var telephoneInput = driver.FindElement(By.CssSelector(telephoneSelector));
            telephoneInput.Clear();
            telephoneInput.SendKeys(telephone);

            var messageInput = driver.FindElement(By.Id(sendMessageSelector));
            messageInput.Clear();
            messageInput.SendKeys(message);

            var agreeInput = driver.FindElement(By.CssSelector(agreeSelector));
            if (agree)
            {
                agreeInput.Click();
            }
            if (!agree)
            {
                
                Console.WriteLine(driver.FindElement(By.CssSelector(agreeErrSelector)));
            }

            var sendMessageInput = driver.FindElement(By.Id(sendMessageSelector));
            sendMessageInput.Click();
        }
    }
}
