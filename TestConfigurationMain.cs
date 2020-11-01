using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumAutomatization.Test1Pages;
using SeleniumAutomatization.Test2Pages;
using System;
using System.Windows.Forms;

namespace SeleniumAutomatization
{
    class TestConfigurationMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            //I had to put both tests in main, because when I put in functions the [STAThread] didn't work properly.
            bool test1 = true;
            bool test2 = true;

            if (test1 == true)
            {
                Console.WriteLine("\nTest1 starting");

                string confirmationLink;
                string email;
                string httpStatus;

                MainPage mainPage;
                RegisterPage registerPage;
                TenMinuteMailPage tenMinuteMailPage;
                ConfirmationPage confirmationPage;
                LoginPage loginPage;
                ServicesPage servicesPage;
                WeatherCityPage weatherCityPage;

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("start-maximized");

                IWebDriver driver = new ChromeDriver(options);
                IWebDriver tenMinuteDriver = new ChromeDriver(options);

                tenMinuteDriver.Navigate().GoToUrl("https://10minutemail.com/");
                tenMinuteMailPage = new TenMinuteMailPage(tenMinuteDriver);
                new Actions(tenMinuteDriver).MoveToElement(tenMinuteMailPage.CopyButton).Click().Perform();
                email = Clipboard.GetText(TextDataFormat.Text);

                driver.Navigate().GoToUrl("http://www.interzoid.com");

                mainPage = new MainPage(driver);
                mainPage.LoadUpperNavBarOptionsBar();
                mainPage.NavBarRegisterButton.Click();

                registerPage = new RegisterPage(driver);

                registerPage.EmailAddress.Text = email;
                registerPage.ConfirmEmailAddress.Text = email;
                registerPage.Password.Text = "123456";
                registerPage.ConfirmPassword.Text = "123456";
                registerPage.SetDatas();

                registerPage.Register();

                confirmationLink = tenMinuteMailPage.GetConfirmationLink();
                driver.Navigate().GoToUrl(confirmationLink);
                confirmationPage = new ConfirmationPage(driver);
                confirmationPage.LoginButton.Click();
                tenMinuteDriver.Close();

                loginPage = new LoginPage(driver, email);
                loginPage.Password.Text = registerPage.Password.Text;
                loginPage.SetDatas();
                loginPage.LoginButton.Click();
                loginPage.LoadUpperNavBarOptionsBar();
                loginPage.NavBarServiceButton.Click();

                servicesPage = new ServicesPage(driver);
                servicesPage.GetWeatherCitylink.Click();

                weatherCityPage = new WeatherCityPage(driver);
                weatherCityPage.City.Text = "Round Rock";
                weatherCityPage.State.Text = "TX";
                httpStatus = weatherCityPage.GetHttpStatus(weatherCityPage.LicenceKey.Text, weatherCityPage.City.Text, weatherCityPage.State.Text);
                Console.WriteLine("\n\nReceived: {0}\nExpected: 200:OK", httpStatus);

                weatherCityPage.City.Text = "Tampa";
                weatherCityPage.State.Text = "TX";
                httpStatus = weatherCityPage.GetHttpStatus(weatherCityPage.LicenceKey.Text, weatherCityPage.City.Text, weatherCityPage.State.Text);
                Console.WriteLine("\n\nReceived: {0}\nExpected: 404:Not Found", httpStatus);

                weatherCityPage.City.Text = "--";
                weatherCityPage.State.Text = "--";
                httpStatus = weatherCityPage.GetHttpStatus(weatherCityPage.LicenceKey.Text, weatherCityPage.City.Text, weatherCityPage.State.Text);
                Console.WriteLine("\n\nReceived: {0}\nExpected: 400:Bad Request\n\n", httpStatus);

                driver.Close();
            }

            if (test2 == true)
            {
                Test2();
            }
        }

        public static void Test2()
        {
            Console.WriteLine("\nTest2 starting");

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

            driver.Close();
        }
    }
}
