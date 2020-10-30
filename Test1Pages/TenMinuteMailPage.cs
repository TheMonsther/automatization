using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatization.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SeleniumAutomatization.Pages
{
    class TenMinuteMailPage : Page
    {
        private IWebElement copyButton;
        private IWebElement mailConfirmationBranch;
        private IReadOnlyCollection<IWebElement> mailContent;

        public TenMinuteMailPage(IWebDriver driverMain)
        {
            driver = driverMain;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("mail_messages_content")));

            mailContent = driver.FindElements(By.Id("mail_messages_content"));
            copyButton = driver.FindElement(By.Id("copy_address"));
        }

        public string GetConfirmationLink()
        {
            string link;
            IWebElement openMailMessage;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(".message_bottom p")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                Debug.Assert(false, "email delayed too much");
            }
            openMailMessage = driver.FindElement(By.ClassName("message_top"));
            openMailMessage.Click();

            Thread.Sleep(2000);//time to site think

            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".message_bottom p"));
            MailConfirmationBranch = elements.ElementAt<IWebElement>(9);
            link = MailConfirmationBranch.Text;

            link = link.Substring(93);

            return link;
        }

        public IWebElement CopyButton { get => copyButton; }
        public IReadOnlyCollection<IWebElement> MailContent { get => mailContent; }
        public IWebElement MailConfirmationBranch { get => mailConfirmationBranch; set => mailConfirmationBranch = value; }
    }
}
