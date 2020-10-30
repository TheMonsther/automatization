using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using test.Components;

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
            phoneOrderButton = driver.FindElement(By.Id("payments_2"));
        }

        public void CheckOut()
        {
            int count = 0;
            try
            {
                IWebElement agreementButton = driver.FindElement(By.CssSelector(".litecheckout__terms input[id^=\"id_accept_terms\"]"));
                agreementButton.Click();
            }
            catch (OpenQA.Selenium.StaleElementReferenceException)
            {
                IWebElement agreementButton = driver.FindElement(By.CssSelector(".litecheckout__terms input[id^=\"id_accept_terms\"]"));
                agreementButton.Click();
            }

            MessageBox.Show("Waiting until Captha be manual solved.");
            while (TryCheckOut() == false)
            {
                Console.WriteLine("Waiting until Captha be manual solved.");
                count++;
                if (count > 10) Debug.Assert(true);
            }
        }

        public void SetDatas()
        {
            CheckOutAddress.WebElement.Click();
            checkOutAddressTxt.WebElement.SendKeys(CheckOutAddress.Text);

            CheckOutEmail.WebElement.Click();
            checkOutEmailTxt.WebElement.SendKeys(CheckOutEmail.Text);
        }
        public bool TryCheckOut()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                orderButton = driver.FindElement(By.CssSelector(".litecheckout__submit-btn"));
                orderButton.Click();
                new Actions(driver).MoveToElement(orderButton).Click().Perform();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("password1")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public IWebElement PhoneOrderButton { get => phoneOrderButton; }
        internal TextField CheckOutAddress { get => checkOutAddress; }
        internal TextField CheckOutEmail { get => checkOutEmail; }
        public IWebElement OrderButton { get => orderButton; }
    }
}
