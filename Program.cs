using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomatization.Pages;
using SeleniumAutomatization.Test2Pages;
using System;
using System.Diagnostics;
using System.Threading;
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
            IWebDriver driver = new ChromeDriver();
            IWebDriver tenMinuteDriver;
            MainPage mainPage;
            RegisterPage registerPage;
            TenMinuteMail tenMinuteMailPage;
            ConfirmationPage confirmationPage;
            LoginPage loginPage;
            ServicesPage servicesPage;
            WeatherCityPage weatherCityPage;
            string confirmationLink;
            string httpReturn;

            int count = 0;

            tenMinuteDriver = new ChromeDriver();
            tenMinuteDriver.Navigate().GoToUrl("https://10minutemail.com/");
            tenMinuteDriver.Manage().Window.Maximize();
            tenMinuteMailPage = new TenMinuteMail(tenMinuteDriver);
            tenMinuteMailPage.CopyButton.Click();
            driver.Manage().Window.Maximize();
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
            //registerPage.Captha.Click();

            MessageBox.Show("Waiting until Captha be manual solved.");
            while (registerPage.VerifyCaptha(driver) == false)
            {
                Console.WriteLine("Waiting until Captha be manual solved.");
                count++;
                if (count > 10) Debug.Assert(true);
            }

            registerPage.RegisterButton.Click();

            confirmationLink = tenMinuteMailPage.GetConfirmationLink(tenMinuteDriver);

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

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demo.cs-cart.com");

            marketHome = new MarketHomePage(driver);
            marketHome.Search.Text = "PC";
            marketHome.SetDatas();
            marketHome.SearchButton.Click();

            marketSearchResultPage = new MarketSearchResultPage(driver);
            marketSearchResultPage.OpenItem(0);

            itemPage = new ItemPage(driver);
            itemPage.AddToCartButton.Click();
            itemPage.CheckOut(driver);

            checkOutPage = new CheckOutPage(driver);
            checkOutPage.CheckOutAddress.Text = "test";
            checkOutPage.CheckOutEmail.Text = "test@test.com";
            checkOutPage.SetDatas();
            checkOutPage.PhoneOrderButton.Click();
            checkOutPage.CheckOut(driver);

        }
    }
}
