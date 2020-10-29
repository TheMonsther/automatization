using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SeleniumAutomatization.Pages
{
    class TenMinuteMail
    {
        private IWebElement copyButton;
        private IWebElement mailConfirmationBranch;
        private IReadOnlyCollection<IWebElement> mailContent;

        public TenMinuteMail(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("mail_messages_content")));

            MailContent = driver.FindElements(By.Id("mail_messages_content"));
            CopyButton = driver.FindElement(By.Id("copy_address"));
        }

        public string GetConfirmationLink(IWebDriver driver)
        {
            string link;
            IWebElement openMailMessage;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(".message_bottom p")));
            } catch(OpenQA.Selenium.WebDriverTimeoutException)
            {
                Debug.Assert(true, "email delayed too much");
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

        public IWebElement CopyButton { get => copyButton; set => copyButton = value; }
        public IReadOnlyCollection<IWebElement> MailContent { get => mailContent; set => mailContent = value; }
        public IWebElement MailConfirmationBranch { get => mailConfirmationBranch; set => mailConfirmationBranch = value; }
    }
}
