using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mobilado_AnamariaRoos.PageObjectModel
{
    public class LivingPage : BasePage
    {

        const string livinghoverSelector = "#main-menu > div > ul > li:nth-child(1) > a > span"; //css
        const string beanbagsSelector = "#main-menu > div > ul > li:nth-child(1) > div > ul > li:nth-child(1) > span > p > a";//css
        const string beanbagsLabel = "#category-page > div > div:nth-child(1) > h1";//css
        const string beanbagGriSelector = "#category-page > div > div:nth-child(3) > div.product-listing.clearfix > div > div.product-box.center.col-md-3.col-xs-6.dataProductId.__GomagListingProductBox.-g-product-box-18280 > div > div.figcaption.list-f > div.top-side-box > h2 > a";//css
        const string beanbagGriAddToCartSelector = "#product-page > div.container-h.product-top.-g-product-18280 > div.row.-g-product-row-box > div.col-sm-6.detail-prod-attr.pull-right > div.add-section.clearfix.-g-product-add-section-18280 > a";//css        
        const string seeCartSelector = "/html/body/div[3]/header/div[2]/div/div/div[3]/ul/li[4]/a/span[2]";//xpath
        const string livingLabel = "#category-page > div > div:nth-child(1) > h1"; //css
        const string acceptCookiesSelector = "#__gomagCookiePolicy"; //css
        const string beanbagDronDownPriceSelector = "/html/body/div[4]/div[3]/div/div[2]/div/div[2]/div/div/p";//css
        const string toolTipSelector = "//*[@id='main-menu']/div/ul/li[1]/a"; //xpath
        const string exitLabelSelector = "#-g-addtocart-popup-default > div.add2cart-pp.catListPP > img";//class
        const string addMoreProductSelector = "#updateCart > div.-g-checkout-summary > div.cart-box.col-sm.clearfix > ul.cart-items.clearfix.order > li > div.qty-h.col-sm-3.col-xs-6 > div.qty-regulator.clearfix.-g-product-qty-regulator-18280 > a.number-up.plus.updateCart"; //css
        const string saveBtnSelector = "ucq_18280_0_0_80f4592d5c93fcd9310da6ad38b70845";//id
        const string deleteProductsSelector = "#__checkoutItemRemove18280_0_0_80f4592d5c93fcd9310da6ad38b70845";
        const string emptyCartLabelSelector = "#cartEmpty > p";//css


        public LivingPage(IWebDriver driver) : base(driver)
        {
        }

        public void AcceptCookie()
        {
            driver.FindElement(By.CssSelector(acceptCookiesSelector)).Click();

        }

        public void Living()
        {
            
            var livinghoverBtn = driver.FindElement(By.CssSelector(livinghoverSelector));
            livinghoverBtn.Click();
        }

        public bool CheckLivingPage(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(livingLabel)).Text.ToLower());
        }

        public void LivingHover()
        {
            var livinghoverBtn = driver.FindElement(By.CssSelector(livinghoverSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(livinghoverBtn).Build().Perform();
            var ToolTip = driver.FindElement(By.XPath(toolTipSelector));
            string tooltipText = ToolTip.GetAttribute("title");
            Console.WriteLine("Tooltip text of Living is {0}", tooltipText);
        }

 
        public void LivingBeanbags()
        {
            var beanbagsInput = Utilities.WaitForFluentElement(driver, 5,By.CssSelector(beanbagsSelector));
            beanbagsInput.Click();
           
        }
        
        public bool CheckBeanbags(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(beanbagsLabel)).Text.ToLower());
        }
        public void AddCart()
        {
            var beanbagGriInput = Utilities.WaitForFluentElement(driver, 10, By.CssSelector(beanbagGriSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(beanbagGriInput).Build().Perform();
            beanbagGriInput.Click();
            var beanbagGriAddToCartInput = Utilities.WaitForElement(driver, 5, By.CssSelector(beanbagGriAddToCartSelector));
            beanbagGriAddToCartInput.Click();
            var exitInput = Utilities.WaitForElement(driver, 2, By.CssSelector(exitLabelSelector));
            Actions actions1 = new Actions(driver);
            actions1.MoveToElement(exitInput).Build().Perform();
            exitInput.Click();

        }

        public void SeeCart() 
        { 
            
            var seeCartInput = Utilities.WaitForFluentElement(driver, 15, By.XPath(seeCartSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(seeCartInput).Build().Perform();
            seeCartInput.Click();
        }

        public void BeanBagsSearchByPrice() 
        {
            var beanbagDropDownPriceInput = Utilities.WaitForFluentElement(driver, 5, By.XPath(beanbagDronDownPriceSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(beanbagDropDownPriceInput).Build().Perform();
            beanbagDropDownPriceInput.Click();
            IWebElement e = driver.FindElement(By.Id("__label0"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }

        
        public void AddMoreProductsToCart()
        {
            var addMoreProductInput = Utilities.WaitForFluentElement(driver, 3, By.CssSelector(addMoreProductSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(addMoreProductInput).Build().Perform();
            addMoreProductInput.Click();

            var saveBtnInput = driver.FindElement(By.Id(saveBtnSelector));
            _ = new Actions(driver);
            actions.MoveToElement(saveBtnInput).Build().Perform();
            saveBtnInput.Click();

        }


        public void DeleteProductFromCart()
        {
            var deleteProductsInput = Utilities.WaitForFluentElement(driver, 15, By.CssSelector(deleteProductsSelector));
            Actions actions = new Actions(driver);
            actions.MoveToElement(deleteProductsInput).Build().Perform();
            deleteProductsInput.Click();
            var emptyCart = Utilities.WaitForFluentElement(driver, 5,By.CssSelector(emptyCartLabelSelector));
            
        }

        
    }
}
