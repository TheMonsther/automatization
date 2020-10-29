using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using test.Pages;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            MainPage mainPage;
            RegisterPage registerPage;

            driver.Navigate().GoToUrl("http://www.interzoid.com");

            mainPage = new MainPage(driver);
            mainPage.RegisterButton.Click();

            registerPage = new RegisterPage(driver);
            registerPage.EmailAddress.Text = "test@test.com";
            registerPage.ConfirmEmailAddress.Text = "test@test.com";
            registerPage.Password.Text = "123456";
            registerPage.ConfirmPassword.Text = "123456";

            registerPage.SetDatas();
            registerPage.Agrrement.Click();
        }
    }
}
