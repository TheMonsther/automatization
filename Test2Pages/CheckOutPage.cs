using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SeleniumAutomatization.Test2Pages
{
    class CheckOutPage : Page
    {
        private TextField checkOutAddressTxt = new TextField();
        private TextField checkOutAddress = new TextField();
        private TextField checkOutEmailTxt = new TextField();
        private TextField checkOutEmail = new TextField();
        private IWebElement phoneOrderButton;
        private IWebElement orderButton;
        private IWebElement signinButton;
        public CheckOutPage(IWebDriver driverMain)
        {
            driver = driverMain;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(".litecheckout__group")));

            CheckOutAddress.WebElement = driver.FindElements(By.CssSelector(".litecheckout__group")).ElementAt<IWebElement>(8);
            CheckOutAddress.WebElement = CheckOutAddress.WebElement.FindElement((By.ClassName("litecheckout__label")));

            checkOutAddressTxt.WebElement = driver.FindElements(By.CssSelector(".litecheckout__group")).ElementAt<IWebElement>(8);
            checkOutAddressTxt.WebElement = checkOutAddressTxt.WebElement.FindElement((By.Id("litecheckout_s_address")));

            CheckOutEmail.WebElement = driver.FindElements(By.CssSelector("#litecheckout_step_customer_info .litecheckout__field")).Last<IWebElement>();
            checkOutEmailTxt.WebElement = CheckOutEmail.WebElement.FindElement((By.Id("litecheckout_email")));
            signinButton = driver.FindElement(By.CssSelector(".litecheckout__item .cm-dialog-opener"));
        }

        public void CheckOut()
        {
            int count = 0;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            Thread.Sleep(2000);
            new Actions(driver).SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            Thread.Sleep(1000);
            phoneOrderButton = driver.FindElement(By.Id("payments_2"));
            PhoneOrderButton.Click();
            Thread.Sleep(2000);
            IWebElement agreementButton = driver.FindElement(By.CssSelector(".litecheckout__terms input[id^=\"id_accept_terms\"]"));
            agreementButton.Click();


            while (TryCheckOut() == false)
            {
                count++;
                if (count > 10) Debug.Assert(false);
            }
        }
        public bool TryCheckOut()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            new Actions(driver).SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            try
            {
                orderButton = driver.FindElement(By.CssSelector(".litecheckout__submit-btn"));
                new Actions(driver).MoveToElement(orderButton).Click().Perform();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(".ty-mainbox-body p")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public void Signin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            signinButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".ty-btn__login")));
            IWebElement signinButton2 = driver.FindElement(By.CssSelector(".ty-btn__login"));
            new Actions(driver).MoveToElement(signinButton2).Click().Perform();

        }

        public void SetDatas()
        {
            CheckOutAddress.WebElement.Click();
            checkOutAddressTxt.WebElement.SendKeys(CheckOutAddress.Text);

            CheckOutEmail.WebElement.Click();
            checkOutEmailTxt.WebElement.SendKeys(CheckOutEmail.Text);
        }


        public IWebElement PhoneOrderButton { get => phoneOrderButton; }
        internal TextField CheckOutAddress { get => checkOutAddress; }
        internal TextField CheckOutEmail { get => checkOutEmail; }
        public IWebElement OrderButton { get => orderButton; }
        public IWebElement SigninButton { get => signinButton; }
    }
}
