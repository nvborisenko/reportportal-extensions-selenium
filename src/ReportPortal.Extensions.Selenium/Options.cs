using ReportPortal.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Extensions.Selenium
{
    public class Options
    {
        public LogLevel Level { get; set; } = LogLevel.Trace;

        public Options UseDefaultLevel(LogLevel level)
        {
            Level = level;
            return this;
        }
    }
}
