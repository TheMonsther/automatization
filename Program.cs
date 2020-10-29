using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Pages;
using System;
using System.Diagnostics;
using test.Pages;
using Xamarin.Essentials;

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
            TenMinuteMail tenMinuteMail;
            string emailConfirmation;

            int count = 0;

            tenMinuteDriver = new ChromeDriver();
            tenMinuteDriver.Navigate().GoToUrl("https://10minutemail.com/");
            tenMinuteMail = new TenMinuteMail(tenMinuteDriver);
            tenMinuteMail.CopyButton.Click();

            driver.Navigate().GoToUrl("http://www.interzoid.com");

            mainPage = new MainPage(driver);
            mainPage.RegisterButton.Click();

            registerPage = new RegisterPage(driver);
            registerPage.EmailAddress.Text = Clipboard.GetTextAsync().ToString();
            registerPage.ConfirmEmailAddress.Text = Clipboard.GetTextAsync().ToString();
            registerPage.Password.Text = "123456";
            registerPage.ConfirmPassword.Text = "123456";

            registerPage.SetDatas();
            registerPage.Agrrement.Click();
            registerPage.Captha.Click();
            
            while(registerPage.VerifyCaptha(driver) == false)
            {
                Console.WriteLine("Waiting until Captha be manual solved.");
                count++;
                if (count > 10) Debug.Assert(true);
            }

            registerPage.RegisterButton.Click();
            

            
        }
    }
}
