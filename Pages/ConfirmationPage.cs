using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutomatization.Pages
{
    class ConfirmationPage
    {
        private IWebElement loginButton;

        public ConfirmationPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*=\"login\"]")));
            loginButton = driver.FindElement(By.CssSelector("a[href*=\"login\"]"));
        }
        public IWebElement LoginButton { get => loginButton; set => loginButton = value; }
    }
}
