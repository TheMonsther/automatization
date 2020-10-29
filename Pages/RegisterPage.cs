using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using test.Components;

namespace test.Pages
{
    class RegisterPage
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
        private IWebElement captha;
        private IWebElement registerButton;

        

        public RegisterPage(IWebDriver driver, string referralCode)
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
            Agrrement = driver.FindElement(By.Id("acceptCheckbox"));
            Captha = driver.FindElement(By.ClassName("recaptcha-checkbox-border"));
            RegisterButton = driver.FindElement(By.Id("sbut"));

            ReferralCode.Text = referralCode;
        }

        public RegisterPage(IWebDriver driver)
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
            Agrrement = driver.FindElement(By.Id("acceptCheckbox"));
            RegisterButton = driver.FindElement(By.Id("sbut"));

            

            
        }

        public bool VerifyCaptha(IWebDriver driver)
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


        public IWebElement Agrrement { get => agrrement; set => agrrement = value; }
        internal TextField FirstName { get => firstName; set => firstName = value; }
        internal TextField LastName { get => lastName; set => lastName = value; }
        internal TextField EmailAddress { get => emailAddress; set => emailAddress = value; }
        internal TextField ConfirmEmailAddress { get => confirmEmailAddress; set => confirmEmailAddress = value; }
        internal TextField Password { get => password; set => password = value; }
        internal TextField ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        internal TextField Title { get => title; set => title = value; }
        internal TextField Company { get => company; set => company = value; }
        internal TextField Phone { get => phone; set => phone = value; }
        internal TextField Address1 { get => address1; set => address1 = value; }
        internal TextField Address2 { get => address2; set => address2 = value; }
        internal TextField City { get => city; set => city = value; }
        internal TextField StateProvince { get => stateProvince; set => stateProvince = value; }
        internal TextField ZipPostalCode { get => zipPostalCode; set => zipPostalCode = value; }
        internal TextField ZipPostalCodeCountry { get => zipPostalCodeCountry; set => zipPostalCodeCountry = value; }
        internal TextField ReferralCode { get => referralCode; set => referralCode = value; }
        internal TextField WhereHeard { get => whereHeard; set => whereHeard = value; }
        public IWebElement Captha { get => captha; set => captha = value; }
        public IWebElement RegisterButton { get => registerButton; set => registerButton = value; }
    }
}
