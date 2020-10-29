using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using test.Components;

namespace SeleniumAutomatization.Pages
{
    class WeatherCityPage
    {
        private TextField city = new TextField();
        private TextField state = new TextField();
        private IWebElement tryButton;

        public WeatherCityPage(IWebDriver driver)
        {
            city.WebElement = driver.FindElement(By.Id("city"));
            state.WebElement = driver.FindElement(By.Id("state"));
            tryButton = driver.FindElement(By.CssSelector("btn"));
        }
    }
}
