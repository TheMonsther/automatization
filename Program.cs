using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomatization.Pages;
using System;
using System.Diagnostics;
using test.Pages;
using System.Windows.Forms; 

namespace test
{
    class Program
    {
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
            
            while(registerPage.VerifyCaptha(driver) == false)
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
            loginPage.LoginButton.Click();
            mainPage.HomeButton.Click();

            servicesPage = new ServicesPage(driver);
            servicesPage.GetWeatherCitylink.Click();

        }
    }
}
