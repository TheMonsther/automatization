using OpenQA.Selenium;
using SeleniumAutomatization.Components;

namespace SeleniumAutomatization.Test1Pages
{
    class WeatherCityPage : Page
    {
        private TextField city = new TextField();
        private TextField state = new TextField();
        private TextField licenceKey = new TextField();
        public WeatherCityPage(IWebDriver driverMain)
        {
            driver = driverMain;
            City.WebElement = driver.FindElement(By.Id("city"));
            State.WebElement = driver.FindElement(By.Id("state"));
            LicenceKey.WebElement = driver.FindElement(By.Id("license"));
            if (LicenceKey.WebElement.Text != "") LicenceKey.Text = LicenceKey.WebElement.Text;
        }



        internal TextField City { get => city; set => city = value; }
        internal TextField State { get => state; set => state = value; }
        internal TextField LicenceKey { get => licenceKey; set => licenceKey = value; }
    }
}
