using OpenQA.Selenium;
using SeleniumAutomatization.Components;

namespace SeleniumAutomatization.Pages
{
    class ServicesPage : Page
    {
        private IWebElement getWeatherCitylink;

        public ServicesPage(IWebDriver driverMain)
        {
            driver = driverMain;
            getWeatherCitylink = driver.FindElement(By.CssSelector("a[href*=\"/services/getweathercity\"]"));
        }

        public IWebElement GetWeatherCitylink { get => getWeatherCitylink; }
    }
}
