using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumAutomatization.Test2Pages
{
    class MarketSearchResultPage
    {
        IList<IWebElement> elements;

        public MarketSearchResultPage(IWebDriver driver)
        {
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
