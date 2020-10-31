using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SeleniumAutomatization.Components
{
    class Page
    {
        protected IWebDriver driver;
        protected IWebElement navBarRegisterButton;
        protected IWebElement navBarServiceButton;
        protected IList<IWebElement> navBarElements;

        public void LoadUpperNavBarOptionsBar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("navbarSupport1")));

            navBarElements = driver.FindElements(By.Id("navbarSupport1"));
            try
            {
                navBarRegisterButton = NavBarElements.Last<IWebElement>().FindElement(By.CssSelector("a[href*=\"register\"]"));
            }
            catch (NoSuchElementException)
            {
                //Its fine. May the user is logged
            }
            navBarServiceButton = NavBarElements.First<IWebElement>().FindElement(By.CssSelector("a[href*=\"services\"]"));
        }

        public string GetHttpStatus(string url) => RequestAndResponse(url);

        public string GetHttpStatus(string licence, string city, string state)
        {
            string url = "https://api.interzoid.com/getweather?license=" + licence + "&city=" + city + "&state=" + state;
            return RequestAndResponse(url);
        }

        private string RequestAndResponse(string url)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = (HttpWebResponse)request.GetResponse();


                //StreamReader sr = new StreamReader(response.GetResponseStream());
                //Console.WriteLine(sr.ReadToEnd());
                //MessageBox.Show("\r\nStatus code is: " + (int)response.StatusCode);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)e.Response;
                }
                else
                {
                    Console.WriteLine("Error: " + e.Status);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : " + e.Message);
            }

            string toReturn = "" + (int)response.StatusCode + ":" + response.StatusDescription;
            if (response != null) response.Close();

            return toReturn;
        }



        public IWebElement NavBarRegisterButton { get => navBarRegisterButton; }
        public IList<IWebElement> NavBarElements { get => navBarElements; }
        public IWebElement NavBarServiceButton { get => navBarServiceButton; }
    }
}
