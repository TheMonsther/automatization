using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;

namespace SeleniumAutomatization.Pages
{
    class ConfirmationPage : Page
    {
        private IWebElement loginButton;

        public ConfirmationPage(IWebDriver driverMain)
        {
            driver = driverMain;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*=\"login\"]")));
            loginButton = driver.FindElement(By.CssSelector("a[href*=\"login\"]"));
        }
        public IWebElement LoginButton { get => loginButton; }
    }
}
