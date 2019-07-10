using OpenQA.Selenium;
using ReportPortal.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public class WebDriverListener : OpenQA.Selenium.Support.Events.EventFiringWebDriver
    {
        const string MARKDOWN_MODE = "!!!MARKDOWN_MODE!!!";

        protected Options _options;

        public WebDriverListener(IWebDriver parentDriver, Options options) : base(parentDriver)
        {
            _options = options;

            LogMessage(_options.Level.ToString());

            this.Navigated += WebDriverListener_Navigated;
            this.ElementValueChanged += WebDriverListener_ElementValueChanged;
        }

        private void WebDriverListener_ElementValueChanged(object sender, OpenQA.Selenium.Support.Events.WebElementValueEventArgs e)
        {
            LogMessage($"'{e.Element}' value changed to '{e.Value}'");
        }

        private void WebDriverListener_Navigated(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)
        {
            var screenshot = base.GetScreenshot().AsByteArray;
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = _options.Level,
                Time = DateTime.UtcNow,
                Text = $"{MARKDOWN_MODE}Navigated to [{e.Driver.Title}]({e.Url})",
                Attach = new Client.Models.Attach
                {
                    Name = "Screenshot",
                    MimeType = "image/png",
                    Data = screenshot
                }
            });
        }

        private void LogMessage(string text)
        {
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = _options.Level,
                Time = DateTime.UtcNow,
                Text = text
            });
        }
    }
}
