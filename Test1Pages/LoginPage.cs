﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;
using test.Components;
using Xamarin.Essentials;

namespace SeleniumAutomatization.Pages
{
    class LoginPage : Page
    {
        private TextField email = new TextField();
        private TextField password = new TextField();
        private IWebElement loginButton;

        public LoginPage(IWebDriver driverMain)
        {
            driver = driverMain;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));

            Email.WebElement = driver.FindElement(By.Id("email"));
            Password.WebElement = driver.FindElement(By.Id("password"));
            loginButton = driver.FindElement(By.ClassName("btn"));
        }

        public LoginPage(IWebDriver driverMain, string email)
        {
            driver = driverMain;
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

        public IWebElement LoginButton { get => loginButton; }
        internal TextField Email { get => email; }
        internal TextField Password { get => password; }
    }
}
