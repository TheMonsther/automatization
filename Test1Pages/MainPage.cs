using OpenQA.Selenium;
using SeleniumAutomatization.Components;

namespace SeleniumAutomatization.Test1Pages
{
    class MainPage : Page
    {
        public MainPage(IWebDriver driverMain)
        {
            driver = driverMain;
        }

    }
}
