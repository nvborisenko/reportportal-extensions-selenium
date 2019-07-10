using NUnit.Framework;
using OpenQA.Selenium;
using ReportPortal.Extensions.Selenium;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var webDriver = new OpenQA.Selenium.Firefox.FirefoxDriver().AddReportPortal();

            webDriver.Navigate().GoToUrl("https://google.com");

            webDriver.FindElement(By.Name("q")).SendKeys("Report Portal" + Keys.Enter);

            webDriver.Close();

            webDriver.Quit();
        }
    }
}