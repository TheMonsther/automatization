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

            elements = driver.FindElements(By.Id("navbarSupport1"));
            registerButton = Elements.Last<IWebElement>().FindElement(By.CssSelector("a[href*=\"register\"]"));
            serviceButton = Elements.First<IWebElement>().FindElement(By.CssSelector("a[href*=\"services\"]"));
        }

        public IWebElement RegisterButton { get => registerButton; }
        public IReadOnlyCollection<IWebElement> Elements { get => elements; }
        public IWebElement ServiceButton { get => serviceButton; }
    }
}
