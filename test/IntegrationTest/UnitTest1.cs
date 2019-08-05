using NUnit.Framework;
using OpenQA.Selenium;
using ReportPortal.Extensions.Selenium;
using System;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var webDriver = new OpenQA.Selenium.Firefox.FirefoxDriver().AddReportPortal();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            webDriver.Navigate().GoToUrl("https://google.com");

            webDriver.FindElement(By.Name("q")).SendKeys("Report Portal");
            webDriver.FindElement(By.Name("btnK")).Click();

            webDriver.Close();

            webDriver.Quit();
        }
    }
}