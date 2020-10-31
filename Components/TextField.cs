using OpenQA.Selenium;

namespace SeleniumAutomatization.Components
{
    class TextField
    {
        private IWebElement webElement;
        private string text = "";

        public string Text { get => text; set { text = value; } }

        public IWebElement WebElement { get => webElement; set { webElement = value; } }
    }
}
