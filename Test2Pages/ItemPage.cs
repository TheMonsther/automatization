using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeleniumAutomatization.Test2Pages
{
    class ItemPage
    {
        private IWebElement addToCartButton;
        private IWebElement price;
        private IWebElement cartButton;
        public ItemPage(IWebDriver driver)
        {
            addToCartButton = driver.FindElement(By.CssSelector(".ty-btn__primary[id^=button]"));
            price = driver.FindElements(By.CssSelector(".ty-price-num")).ElementAt<IWebElement>(1); 
        }

        public void CheckOut(IWebDriver driver)
        {
            IWebElement cartItemList;
            IWebElement cartItemDescription;
            IWebElement checkOutButton;
            string itemPrice;

            int i = 0;
            while (i < 4)
            {
                try
                {
                    cartButton = driver.FindElement(By.ClassName("ty-minicart-title"));
                    cartButton.Click();
                    break;
                }
                catch (OpenQA.Selenium.StaleElementReferenceException)
                {
                    System.Threading.Thread.Sleep(8000);
                    i++;
                }
            }
            cartItemList = driver.FindElement(By.Id("dropdown_8"));
            checkOutButton = cartItemList.FindElement(By.ClassName("ty-float-right"));
            cartItemDescription = cartItemList.FindElement(By.CssSelector(".ty-cart-items__list-item-desc p"));
            itemPrice = cartItemDescription.Text.Substring(cartItemDescription.Text.Length - 6);

            Debug.Assert(Price.Text.Equals(itemPrice));
            Console.WriteLine(Price.Text + " = " + itemPrice);
            checkOutButton.Click();
        }
        public IWebElement AddToCartButton { get => addToCartButton; }
        public IWebElement Price { get => price;}
    }
}
