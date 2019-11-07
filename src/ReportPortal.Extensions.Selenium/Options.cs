using ReportPortal.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public class Options
    {
        public LogLevel Level { get; set; } = LogLevel.Trace;

        public string MarkdownPrefix {get; set; } = "";

        public Options UseDefaultLevel(LogLevel level)
        {
            Level = level;
            return this;
        }

        public Options UseMarkdownPrefix()
        {
            MarkdownPrefix = "!!!MARKDOWN_MODE!!!";
            return this;
        }
    }
}
