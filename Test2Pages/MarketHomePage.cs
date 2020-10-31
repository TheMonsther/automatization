using OpenQA.Selenium;
using SeleniumAutomatization.Components;

namespace SeleniumAutomatization.Test2Pages
{
    class MarketHomePage : Page
    {
        private TextField search = new TextField();
        private IWebElement searchButton;
        public MarketHomePage(IWebDriver driverMain)
        {
            driver = driverMain;
            Search.WebElement = driver.FindElement(By.Id("search_input"));
            SearchButton = driver.FindElement(By.ClassName("ty-search-magnifier"));
        }
        public void SetDatas()
        {
            Search.WebElement.SendKeys(Search.Text);
        }


        public IWebElement SearchButton { get => searchButton; set => searchButton = value; }
        internal TextField Search { get => search; set => search = value; }
    }
}
