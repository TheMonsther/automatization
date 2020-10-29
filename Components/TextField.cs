using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace test.Components
{
    class TextField
    {
        private IWebElement webElement;
        private string text = "";
        private string expectedText;

        public string Text { get => text; set { text = value; expectedText = value; } }

        public IWebElement WebElement { get => webElement; set { webElement = value; } }
    }
}
