using OpenQA.Selenium;

namespace SeleniumAutomatization.Pages
{
    class ServicesPage
    {
        private IWebElement getWeatherCitylink;

        public ServicesPage(IWebDriver driver)
        {
            getWeatherCitylink = driver.FindElement(By.CssSelector("a[href*=\"/services/getweathercity\"]"));
        }

        public IWebElement GetWeatherCitylink { get => getWeatherCitylink;}
    }
}
