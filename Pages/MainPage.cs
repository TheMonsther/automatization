using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace test.Pages
{
    class MainPage
    {
        private IWebElement registerButton;
        private IWebElement serviceButton;
        IReadOnlyCollection<IWebElement> elements;

        public MainPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("navbarSupport1")));

            Elements = driver.FindElements(By.Id("navbarSupport1"));
            RegisterButton = Elements.Last<IWebElement>().FindElement(By.CssSelector("a[href*=\"register\"]"));
            ServiceButton = Elements.First<IWebElement>().FindElement(By.CssSelector("a[href*=\"services\"]"));
        }

        public IWebElement RegisterButton { get => registerButton; set => registerButton = value; }
        public IReadOnlyCollection<IWebElement> Elements { get => elements; set => elements = value; }
        public IWebElement ServiceButton { get => serviceButton; set => serviceButton = value; }
    }
}
