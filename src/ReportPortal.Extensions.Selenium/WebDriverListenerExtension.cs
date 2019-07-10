using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public static class WebDriverListenerExtension
    {


        public static IWebDriver AddReportPortal(this IWebDriver webDriver, Func<Options, Options> optionsFunc = null)
        {
            var options = optionsFunc == null ? DefaultOptions : optionsFunc.Invoke(DefaultOptions);

            var rpListener = new WebDriverListener(webDriver, options);

            return rpListener;
        }

        private static Options DefaultOptions
        {
            get
            {
                return new Options();
            }
        }
    }
}
