using OpenQA.Selenium;
using SeleniumAutomatization.Components;
using System;
using System.IO;
using System.Net;
using test.Components;

namespace SeleniumAutomatization.Pages
{
    class WeatherCityPage : Page
    {
        private TextField city = new TextField();
        private TextField state = new TextField();
        private TextField licenceKey = new TextField();
        public WeatherCityPage(IWebDriver driverMain)
        {
            driver = driverMain;
            City.WebElement = driver.FindElement(By.Id("city"));
            State.WebElement = driver.FindElement(By.Id("state"));
            LicenceKey.WebElement = driver.FindElement(By.Id("license"));
        }

        public string SendRequest(IWebDriver driver)
        {
            LicenceKey.Text = LicenceKey.WebElement.Text;
            GetRequest("https://api.interzoid.com/getweather?license=" + LicenceKey.Text + "&city=" + City.Text + "&state=" + State.Text);

            IWebElement httpReturn = driver.FindElement(By.CssSelector("pre"));

            return httpReturn.Text;
        }

        public string SendRequest()
        {
            LicenceKey.Text = LicenceKey.WebElement.Text;
            GetRequest("https://api.interzoid.com/getweather?license=" + LicenceKey.Text + "&city=" + City.Text + "&state=" + State.Text);

            IWebElement httpReturn = driver.FindElement(By.CssSelector("pre"));

            return httpReturn.Text;
        }

        public string GetRequest(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var responseStream = httpWebResponse.GetResponseStream();
            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);
                Console.WriteLine(streamReader.ReadToEnd());
                return streamReader.ReadToEnd();
            }
            if (responseStream != null) responseStream.Close();

            return "-1";
        }

        internal TextField City { get => city; set => city = value; }
        internal TextField State { get => state; set => state = value; }
        internal TextField LicenceKey { get => licenceKey; set => licenceKey = value; }
    }
}
