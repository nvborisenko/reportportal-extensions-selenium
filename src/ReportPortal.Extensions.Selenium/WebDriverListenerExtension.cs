using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public static class WebDriverListenerExtension
    {
        public static IWebDriver AddReportPortal(this IWebDriver webDriver)
        {
            var rpListener = new WebDriverListener(webDriver, null);

            return rpListener;
        }
    }
}
