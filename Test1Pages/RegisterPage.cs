using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SeleniumAutomatization.Test1Pages
{
    class RegisterPage : Page
    {
        private TextField firstName = new TextField();
        private TextField lastName = new TextField();
        private TextField emailAddress = new TextField();
        private TextField confirmEmailAddress = new TextField();
        private TextField password = new TextField();
        private TextField confirmPassword = new TextField();
        private TextField title = new TextField();
        private TextField company = new TextField();
        private TextField phone = new TextField();
        private TextField address1 = new TextField();
        private TextField address2 = new TextField();
        private TextField city = new TextField();
        private TextField stateProvince = new TextField();
        private TextField zipPostalCode = new TextField();
        private TextField zipPostalCodeCountry = new TextField();
        private TextField referralCode = new TextField();
        private TextField whereHeard = new TextField();
        private IWebElement agrrement;
        private IWebElement registerButton;


        public RegisterPage(IWebDriver driverMain, string referral)
        {
            driver = driverMain;
            SetFields();
            ReferralCode.Text = referral;
        }

        public RegisterPage(IWebDriver driverMain)
        {
            driver = driverMain;
            SetFields();
        }

        private void SetFields()
        {
            FirstName.WebElement = driver.FindElement(By.Id("first"));
            LastName.WebElement = driver.FindElement(By.Id("last"));
            EmailAddress.WebElement = driver.FindElement(By.Id("email"));
            ConfirmEmailAddress.WebElement = driver.FindElement(By.Id("confirmemail"));
            Password.WebElement = driver.FindElement(By.Id("password"));
            ConfirmPassword.WebElement = driver.FindElement(By.Id("confirmpassword"));
            Title.WebElement = driver.FindElement(By.CssSelector(".form-control#title"));
            Company.WebElement = driver.FindElement(By.Id("company"));
            Phone.WebElement = driver.FindElement(By.Id("phone"));
            Address1.WebElement = driver.FindElement(By.Id("address1"));
            Address2.WebElement = driver.FindElement(By.Id("address2"));
            City.WebElement = driver.FindElement(By.Id("city"));
            StateProvince.WebElement = driver.FindElement(By.Id("state"));
            ZipPostalCode.WebElement = driver.FindElement(By.Id("postal"));
            ZipPostalCodeCountry.WebElement = driver.FindElement(By.Id("country"));
            ReferralCode.WebElement = driver.FindElement(By.Id("referral"));
            WhereHeard.WebElement = driver.FindElement(By.Id("whereheard"));
            agrrement = driver.FindElement(By.Id("acceptCheckbox"));
            registerButton = driver.FindElement(By.Id("sbut"));
        }

        public void Register()
        {
            int count = 0;
            Agrrement.Click();

            MessageBox.Show("Waiting until Captha be manual solved.\n\nHit OK when the Captha is solved.");
            while (CheckIfEnabled() == false)
            {
                Console.WriteLine("Waiting until Captha be manual solved.");
                count++;
                if (count > 10) Debug.Assert(true);
            }

            RegisterButton.Click();
        }

        public bool CheckIfEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("sbut")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }
        public void SetDatas()
        {
            FirstName.WebElement.SendKeys(FirstName.Text);
            LastName.WebElement.SendKeys(LastName.Text);
            EmailAddress.WebElement.SendKeys(EmailAddress.Text);
            ConfirmEmailAddress.WebElement.SendKeys(ConfirmEmailAddress.Text);
            Password.WebElement.SendKeys(Password.Text);
            ConfirmPassword.WebElement.SendKeys(ConfirmPassword.Text);
            Title.WebElement.SendKeys(Title.Text);
            Company.WebElement.SendKeys(Company.Text);
            Phone.WebElement.SendKeys(Phone.Text);
            Address1.WebElement.SendKeys(Address1.Text);
            Address2.WebElement.SendKeys(Address2.Text);
            City.WebElement.SendKeys(City.Text);
            StateProvince.WebElement.SendKeys(StateProvince.Text);
            ZipPostalCode.WebElement.SendKeys(ZipPostalCode.Text);
            ZipPostalCodeCountry.WebElement.SendKeys(ZipPostalCodeCountry.Text);
            ReferralCode.WebElement.SendKeys(ReferralCode.Text);
            WhereHeard.WebElement.SendKeys(WhereHeard.Text);
        }


        public IWebElement Agrrement { get => agrrement; }
        internal TextField FirstName { get => firstName; }
        internal TextField LastName { get => lastName; }
        internal TextField EmailAddress { get => emailAddress; }
        internal TextField ConfirmEmailAddress { get => confirmEmailAddress; }
        internal TextField Password { get => password; }
        internal TextField ConfirmPassword { get => confirmPassword; }
        internal TextField Title { get => title; }
        internal TextField Company { get => company; }
        internal TextField Phone { get => phone; }
        internal TextField Address1 { get => address1; }
        internal TextField Address2 { get => address2; }
        internal TextField City { get => city; }
        internal TextField StateProvince { get => stateProvince; }
        internal TextField ZipPostalCode { get => zipPostalCode; }
        internal TextField ZipPostalCodeCountry { get => zipPostalCodeCountry; }
        internal TextField ReferralCode { get => referralCode; }
        internal TextField WhereHeard { get => whereHeard; }
        public IWebElement RegisterButton { get => registerButton; }
    }
}
