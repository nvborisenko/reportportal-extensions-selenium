using OpenQA.Selenium;
using ReportPortal.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public class WebDriverListener : OpenQA.Selenium.Support.Events.EventFiringWebDriver
    {
        const Client.Models.LogLevel LEVEL = Client.Models.LogLevel.Trace;
        const string MARKDOWN_MODE = "!!!MARKDOWN_MODE!!!";

        protected Options _options;

        public WebDriverListener(IWebDriver parentDriver, Options options) : base(parentDriver)
        {
            _options = options;

            this.Navigating += WebDriverListener_Navigating;
            this.Navigated += WebDriverListener_Navigated;
            this.ElementClicking += WebDriverListener_ElementClicking;
        }

        private void WebDriverListener_Navigated(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)
        {
            var screenshot = ((ITakesScreenshot)base.WrappedDriver).GetScreenshot().AsByteArray;
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = LEVEL,
                Time = DateTime.UtcNow,
                Text = $"Navigated to {e.Url}",
                Attach = new Client.Models.Attach
                {
                    Name = "Screenshot",
                    MimeType = "image/png",
                    Data = screenshot
                }
            });
        }

        private void WebDriverListener_Navigating(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)
        {
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = LEVEL,
                Time = DateTime.UtcNow,
                Text = $"{MARKDOWN_MODE}Navigating to [{e.Url}]({e.Url})"
            });
        }

        private void WebDriverListener_ElementClicking(object sender, OpenQA.Selenium.Support.Events.WebElementEventArgs e)
        {
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = LEVEL,
                Time = DateTime.UtcNow,
                Text = $"Clicking on {e.Element}"
            });
        }
    }
}
