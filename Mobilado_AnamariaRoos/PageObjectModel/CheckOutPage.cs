using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    class CheckOutPage : BasePage
    {
        const string placeOrderSelector = "#shoppingcart > a.btn.btn-cmd.full.fr"; //css
        const string withoutAccountBoxSelector = "#checkoutform > div:nth-child(2) > div.col-xs-8 > label > div > input";//css
        const string emailSeclector = "#checkoutform > div:nth-child(4) > input";//css
        const string nameSelector = "#checkoutform > div:nth-child(5) > input";//css
        const string firstNameSelector = "#checkoutform > div:nth-child(6) > input";//css
        const string telephoneSelector = "#checkoutform > div:nth-child(7) > input";//css
        const string adressSelector = "#_shippingAddressHolder > input.input-s.col-sm-5.col-xs-8.-g-storage"; //css
        const string deliveryMethodSelector = "#checkoutform > div.form-h.-g-checkout-delivery-method-section > div > label:nth-child(1) > input";//css
        const string PaymentMethodSelector = "#_paymentOptions > label:nth-child(1) > input";//css
        const string messageSelector = "#checkoutform > div:nth-child(28) > textarea";//css
         
        public CheckOutPage(IWebDriver driver) : base(driver)
        {
        }

        public void CheckOut(string email, string name, string firstName, string telephone, string adress, string message)
        {

            var placeOrder = driver.FindElement(By.CssSelector(placeOrderSelector));
            placeOrder.Click();

            var withoutAccount = Utilities.WaitForFluentElement(driver, 5, By.CssSelector(withoutAccountBoxSelector));
            withoutAccount.Click();

            var emailInput = driver.FindElement(By.CssSelector(emailSeclector));
            emailInput.Clear();
            emailInput.SendKeys(email);

            var nameInput = driver.FindElement(By.CssSelector(nameSelector));
            nameInput.Clear();
            nameInput.SendKeys(name);

            var firstNameInput = driver.FindElement(By.CssSelector(firstNameSelector));
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);

           var telephoneInput = driver.FindElement(By.CssSelector(telephoneSelector));
            telephoneInput.Clear();
            telephoneInput.SendKeys(telephone);


            IWebElement e = driver.FindElement(By.Id("_shippingCountry"));
            SelectElement s = new SelectElement(e);
            s.SelectByText("Romania");

            IWebElement e1 = driver.FindElement(By.Id("_shippingRegion"));
            SelectElement s1 = new SelectElement(e1);
            s1.SelectByText("Cluj");

            IWebElement e2 = driver.FindElement(By.Id("_shippingCity"));
            SelectElement s2 = new SelectElement(e2);
            s2.SelectByText("Cluj-Napoca");

            var adressInput = driver.FindElement(By.CssSelector(adressSelector));
            adressInput.Clear();
            adressInput.SendKeys(adress);

            var deliveryMethod = driver.FindElement(By.CssSelector(deliveryMethodSelector));
            deliveryMethod.Click();

            var paymentMethod = driver.FindElement(By.CssSelector(PaymentMethodSelector));
            paymentMethod.Click();

            var messageInput = driver.FindElement(By.CssSelector(messageSelector));
            messageInput.SendKeys(message);

       }
    }
}