using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using test.Components;

namespace SeleniumAutomatization.Test2Pages
{
    class CheckOutPage
    {
        private TextField checkOutAddress;
        private TextField checkOutEmail;
        private IWebElement phoneOrderButton;
        private IWebElement agreementButton;
        public CheckOutPage(IWebDriver driver)
        {
            CheckOutAddress.WebElement = driver.FindElement(By.Id("litecheckout_s_address"));
            CheckOutEmail.WebElement = driver.FindElement(By.Id("litecheckout_email"));
            phoneOrderButton = driver.FindElement(By.Id("payments_2"));
            agreementButton = driver.FindElement(By.ClassName("cm-agreement"));
        }

        public bool VerifyCaptha(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("litecheckout__submit-btn")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public IWebElement PhoneOrderButton { get => phoneOrderButton; }
        public IWebElement AgreementButton { get => agreementButton;}
        internal TextField CheckOutAddress { get => checkOutAddress; }
        internal TextField CheckOutEmail { get => checkOutEmail; }
    }
}
