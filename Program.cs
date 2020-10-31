using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomatization.Pages;
using SeleniumAutomatization.Test2Pages;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using test.Pages;

namespace test
{
    class Program
    {

        static void Main(string[] args)
        {
            //Test1();
            Test2();
        }

        [STAThread]
        public static void Test1()
        {
            string confirmationLink;
            string httpReturn;

            var service = ChromeDriverService.CreateDefaultService();
            service.LogPath = "C:\\chromedriver.log";
            service.EnableVerboseLogging = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            IWebDriver driver = new ChromeDriver(service, options);
            IWebDriver tenMinuteDriver = new ChromeDriver(options);

            MainPage mainPage;
            RegisterPage registerPage;
            TenMinuteMailPage tenMinuteMailPage;
            ConfirmationPage confirmationPage;
            LoginPage loginPage;
            ServicesPage servicesPage;
            WeatherCityPage weatherCityPage;

            

            tenMinuteDriver = new ChromeDriver(options);
            tenMinuteDriver.Navigate().GoToUrl("https://10minutemail.com/");
            tenMinuteMailPage = new TenMinuteMailPage(tenMinuteDriver);
            tenMinuteMailPage.CopyButton.Click();

            driver.Navigate().GoToUrl("http://www.interzoid.com");

            mainPage = new MainPage(driver);
            mainPage.RegisterButton.Click();

            registerPage = new RegisterPage(driver);

            registerPage.EmailAddress.Text = Clipboard.GetText(TextDataFormat.Text);
            registerPage.ConfirmEmailAddress.Text = Clipboard.GetText(TextDataFormat.Text);
            registerPage.Password.Text = "123456";
            registerPage.ConfirmPassword.Text = "123456";

            registerPage.SetDatas();
            registerPage.Agrrement.Click();
            registerPage.Register();
            

            confirmationLink = tenMinuteMailPage.GetConfirmationLink();

            driver.Navigate().GoToUrl(confirmationLink);
            confirmationPage = new ConfirmationPage(driver);
            confirmationPage.LoginButton.Click();

            loginPage = new LoginPage(driver, Clipboard.GetText(TextDataFormat.Text));
            loginPage.SetDatas();
            loginPage.LoginButton.Click();

            mainPage.ServiceButton.Click();

            servicesPage = new ServicesPage(driver);
            servicesPage.GetWeatherCitylink.Click();

            weatherCityPage = new WeatherCityPage(driver);
            weatherCityPage.City.Text = "Round Rock";
            weatherCityPage.State.Text = "TX";
            httpReturn = weatherCityPage.SendRequest(driver);

            //Debug.Assert(httpReturn.Contains("404") == false);
            //Debug.Assert(httpReturn.Substring(4).Equals("page not found") == false);
        }

        public static void Test2()
        {
            MarketHomePage marketHome;
            MarketSearchResultPage marketSearchResultPage;
            ItemPage itemPage;
            CheckOutPage checkOutPage;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://demo.cs-cart.com");

            marketHome = new MarketHomePage(driver);
            marketHome.Search.Text = "Mobile";
            marketHome.SetDatas();
            marketHome.SearchButton.Click();

            marketSearchResultPage = new MarketSearchResultPage(driver);
            marketSearchResultPage.OpenItem(0);

            itemPage = new ItemPage(driver);
            itemPage.AddToCartButton.Click();
            itemPage.CheckOut();

            checkOutPage = new CheckOutPage(driver);
            checkOutPage.Signin();
            checkOutPage.CheckOut();

        }
    }
}
