using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;
using System.Linq;

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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                cartButton = driver.FindElement(By.ClassName("ty-minicart-title"));
                cartButton.Click();
            }
            catch (OpenQA.Selenium.StaleElementReferenceException)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("ty-minicart-title")));
                cartButton = driver.FindElement(By.ClassName("ty-minicart-title"));
                cartButton.Click();
            }

            cartItemList = driver.FindElement(By.Id("dropdown_8"));
            checkOutButton = cartItemList.FindElement(By.ClassName("ty-float-right"));
            cartItemDescription = cartItemList.FindElement(By.CssSelector(".ty-cart-items__list-item-desc p"));
            itemPrice = cartItemDescription.Text.Substring(cartItemDescription.Text.Length - 6);

            Console.WriteLine(Price.Text + " = " + itemPrice);
            checkOutButton.Click();
        }
        public IWebElement AddToCartButton { get => addToCartButton; }
        public IWebElement Price { get => price; }
    }
}
