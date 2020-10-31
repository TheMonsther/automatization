using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumAutomatization.Test1Pages;
using SeleniumAutomatization.Test2Pages;
using System;
using System.Windows.Forms;

namespace SeleniumAutomatization
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //I had to put both tests in main, because when I put in functions the [STAThread] didn't work properly.
            bool test1 = true;
            bool test2 = true;

            if (test1 == true)
            {
                string confirmationLink;
                string email;
                string httpStatus;

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.LogPath = ".\\chromedriver.log";
                service.EnableVerboseLogging = true;

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("start-maximized");

                IWebDriver driver = new ChromeDriver(options);
                IWebDriver tenMinuteDriver = new ChromeDriver(options);

                MainPage mainPage;
                RegisterPage registerPage;
                TenMinuteMailPage tenMinuteMailPage;
                ConfirmationPage confirmationPage;
                LoginPage loginPage;
                ServicesPage servicesPage;
                WeatherCityPage weatherCityPage;

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
                registerPage.Agrrement.Click();
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
                System.Threading.Thread.Sleep(4000);
                loginPage.LoadUpperNavBarOptionsBar();
                loginPage.NavBarServiceButton.Click();

                servicesPage = new ServicesPage(driver);
                servicesPage.GetWeatherCitylink.Click();

                weatherCityPage = new WeatherCityPage(driver);
                weatherCityPage.City.Text = "Round Rock";
                weatherCityPage.State.Text = "TX";
                httpStatus = weatherCityPage.GetHttpStatus(weatherCityPage.LicenceKey.Text, weatherCityPage.City.Text, weatherCityPage.State.Text);
                Console.WriteLine("\nRecived: {0}\nExpected: 200:OK", httpStatus);

                //Debug.Assert(httpStatus.Substring(0,2).Equals("200"), "The recived code is different than expected code");
                //Debug.Assert(httpStatus.Substring(2).Equals("OK"), "The recived status description is different than expected code");

                weatherCityPage.City.Text = "Tampa";
                weatherCityPage.State.Text = "TX";
                httpStatus = weatherCityPage.GetHttpStatus(weatherCityPage.LicenceKey.Text, weatherCityPage.City.Text, weatherCityPage.State.Text);
                Console.WriteLine("\nRecived: {0}\nExpected: 404:Not Found", httpStatus);

                //Debug.Assert(httpStatus.Substring(0, 2).Equals("404"), "The recived code is different than expected code");
                //Debug.Assert(httpStatus.Substring(2).Equals("Not Found"), "The recived status description is different than expected code");

                weatherCityPage.City.Text = "--";
                weatherCityPage.State.Text = "--";
                httpStatus = weatherCityPage.GetHttpStatus(weatherCityPage.LicenceKey.Text, weatherCityPage.City.Text, weatherCityPage.State.Text);
                Console.WriteLine("\nRecived: {0}\nExpected: 400:Bad Request", httpStatus);

                //Debug.Assert(httpStatus.Substring(0, 2).Equals("400"), "The recived code is different than expected code");
                //Debug.Assert(httpStatus.Substring(2).Equals("Bad Request"), "The recived status description is different than expected code");
                driver.Close();
            }

            if (test2 == true)
            {
                Test2();
            }
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

            driver.Close();
        }
    }
}
