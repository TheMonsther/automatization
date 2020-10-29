using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomatization.Pages;
using System;
using System.Diagnostics;
using test.Pages;
using System.Windows.Forms;
using System.Threading;

namespace test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
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
            weatherCityPage.SetDatas();
            weatherCityPage.TryButton.Click();
        }
    }
}
