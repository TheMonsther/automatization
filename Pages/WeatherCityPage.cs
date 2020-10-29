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
            City.WebElement = driver.FindElement(By.Id("city"));
            State.WebElement = driver.FindElement(By.Id("state"));
            TryButton = driver.FindElement(By.CssSelector("btn"));
        }

        public void SetDatas()
        {
            City.WebElement.SendKeys(City.Text);
            State.WebElement.SendKeys(State.Text);
        }

        public IWebElement TryButton { get => tryButton; set => tryButton = value; }
        internal TextField City { get => city; set => city = value; }
        internal TextField State { get => state; set => state = value; }
    }
}
