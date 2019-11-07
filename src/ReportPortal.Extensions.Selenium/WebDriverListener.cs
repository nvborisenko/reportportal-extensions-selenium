using OpenQA.Selenium;
using ReportPortal.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public class WebDriverListener : OpenQA.Selenium.Support.Events.EventFiringWebDriver
    {
        protected Options _options;

        public WebDriverListener(IWebDriver parentDriver, Options options) : base(parentDriver)
        {
            _options = options;

            this.Navigating += WebDriverListener_Navigating;
            this.Navigated += WebDriverListener_Navigated;
            this.FindingElement += WebDriverListener_FindingElement;
            this.ElementClicking += WebDriverListener_ElementClicking;
            this.ElementClicked += WebDriverListener_ElementClicked;
            this.ElementValueChanged += WebDriverListener_ElementValueChanged;
        }

        private void WebDriverListener_Navigating(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)
        {
            LogMessage($"Navigating to {e.Url}");
        }

        private void WebDriverListener_ElementClicked(object sender, OpenQA.Selenium.Support.Events.WebElementEventArgs e)
        {
            LogScreenshot($"{e.Element} clicked");
        }

        private void WebDriverListener_ElementClicking(object sender, OpenQA.Selenium.Support.Events.WebElementEventArgs e)
        {
            LogMessage($"Clicking on the {e.Element.TagName} `{e.Element.Text}` {e.Element}");
        }

        private void WebDriverListener_FindingElement(object sender, OpenQA.Selenium.Support.Events.FindElementEventArgs e)
        {
            LogMessage($"Finding element `{e.FindMethod}`");
        }

        private void WebDriverListener_ElementValueChanged(object sender, OpenQA.Selenium.Support.Events.WebElementValueEventArgs e)
        {
            LogScreenshot($"Value of the {e.Element} changed to `{e.Value}`");
        }

        private void WebDriverListener_Navigated(object sender, OpenQA.Selenium.Support.Events.WebDriverNavigationEventArgs e)
        {
            LogScreenshot($"Navigated to [{e.Driver.Title}]({e.Url})");
        }

        private void LogMessage(string text)
        {
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = _options.Level,
                Time = DateTime.UtcNow,
                Text = $"{_options.MarkdownPrefix}{text}"
            });
        }

        private void LogScreenshot(string text)
        {
            var screenshot = base.GetScreenshot().AsByteArray;
            Log.Message(new Client.Requests.AddLogItemRequest
            {
                Level = _options.Level,
                Time = DateTime.UtcNow,
                Text = $"{_options.MarkdownPrefix}{text}",
                Attach = new Client.Models.Attach
                {
                    Name = "Screenshot",
                    MimeType = "image/png",
                    Data = screenshot
                }
            });
        }
    }
}
