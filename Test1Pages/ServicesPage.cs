using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;

namespace SeleniumAutomatization.Test1Pages
{
    class ServicesPage : Page
    {
        private IWebElement getWeatherCitylink;

        public ServicesPage(IWebDriver driverMain)
        {
            driver = driverMain;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*=\"/services/getweathercity\"]")));
            getWeatherCitylink = driver.FindElement(By.CssSelector("a[href*=\"/services/getweathercity\"]"));
        }

        public IWebElement GetWeatherCitylink { get => getWeatherCitylink; }
    }
}
