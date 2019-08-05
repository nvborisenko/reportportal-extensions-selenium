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

            webDriver.Navigate().GoToUrl("https://www.nuget.org");

            webDriver.FindElement(By.Name("q")).SendKeys("ReportPortal.Extensions");
            webDriver.FindElement(By.ClassName("btn-search")).Click();

            webDriver.Quit();
        }
    }
}