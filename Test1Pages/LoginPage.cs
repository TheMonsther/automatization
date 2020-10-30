using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using test.Components;
using Xamarin.Essentials;

namespace SeleniumAutomatization.Pages
{
    class LoginPage
    {
        private TextField email = new TextField();
        private TextField password = new TextField();
        private IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));

            Email.WebElement = driver.FindElement(By.Id("email"));
            Password.WebElement = driver.FindElement(By.Id("password"));
            loginButton = driver.FindElement(By.ClassName("btn"));
        }

        public LoginPage(IWebDriver driver, string email)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));

            Email.WebElement = driver.FindElement(By.Id("email"));
            Password.WebElement = driver.FindElement(By.Id("password"));
            loginButton = driver.FindElement(By.ClassName("btn"));

            Email.Text = email;
        }

        public void SetDatas()
        {
            if (Email.Text.Equals("")) Email.Text = Clipboard.GetTextAsync().ToString();
            Email.WebElement.SendKeys(Email.Text);
            Password.WebElement.SendKeys(Password.Text);
        }

        public IWebElement LoginButton { get => loginButton;}
        internal TextField Email { get => email; }
        internal TextField Password { get => password;}
    }
}
