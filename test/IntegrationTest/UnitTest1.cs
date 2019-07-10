using NUnit.Framework;
using ReportPortal.Extensions.Selenium;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var webDriver = new OpenQA.Selenium.Chrome.ChromeDriver().AddReportPortal();

            webDriver.Navigate().GoToUrl("http://google.com");

            webDriver.Close();

            webDriver.Quit();
        }
    }
}