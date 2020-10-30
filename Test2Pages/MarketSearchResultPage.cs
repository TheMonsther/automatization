using OpenQA.Selenium;
using SeleniumAutomatization.Components;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAutomatization.Test2Pages
{
    class MarketSearchResultPage : Page
    {
        IList<IWebElement> elements;

        public MarketSearchResultPage(IWebDriver driverMain)
        {
            driver = driverMain;
            elements = driver.FindElements(By.ClassName("grid-list"));
        }

        public void OpenItem(int i)
        {
            IWebElement element = elements.ElementAt<IWebElement>(i);
            IWebElement image = element.FindElement(By.ClassName("ty-pict"));
            image.Click();

        }
    }
}
