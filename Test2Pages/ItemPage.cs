using OpenQA.Selenium;
using SeleniumAutomatization.Components;
using System;
using System.Linq;
using System.Threading;

namespace SeleniumAutomatization.Test2Pages
{
    class ItemPage : Page
    {
        private IWebElement addToCartButton;
        private IWebElement price;
        private IWebElement cartButton;
        public ItemPage(IWebDriver driverMain)
        {
            driver = driverMain;
            addToCartButton = driver.FindElement(By.CssSelector(".ty-btn__primary[id^=button]"));
            price = driver.FindElements(By.CssSelector(".ty-price-num")).ElementAt<IWebElement>(1);
        }

        public void CheckOut()
        {
            IWebElement cartItemList;
            IWebElement cartItemDescription;
            IWebElement checkOutButton;
            string itemPrice;

            try
            {
                cartButton = driver.FindElement(By.ClassName("ty-minicart-title"));
                cartButton.Click();
            }
            catch (OpenQA.Selenium.StaleElementReferenceException)
            {
                Thread.Sleep(8000);
                cartButton = driver.FindElement(By.ClassName("ty-minicart-title"));
                cartButton.Click();
            }

            cartItemList = driver.FindElement(By.Id("dropdown_8"));
            checkOutButton = cartItemList.FindElement(By.ClassName("ty-float-right"));
            cartItemDescription = cartItemList.FindElement(By.CssSelector(".ty-cart-items__list-item-desc p"));
            itemPrice = cartItemDescription.Text.Substring(cartItemDescription.Text.Length - 6);

            Console.WriteLine("\nReceived: " + itemPrice + "\nExpected: " + Price.Text);
            checkOutButton.Click();
        }
        public IWebElement AddToCartButton { get => addToCartButton; }
        public IWebElement Price { get => price; }
    }
}
