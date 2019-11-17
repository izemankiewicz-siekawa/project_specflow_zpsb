using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumTests
{
    [Binding]
    class GenerateOutput
    {
        private readonly IWebDriver _driver;
        public GenerateOutput(IWebDriver driver)
        {
            _driver = driver;
        }
        public void SaveScreenshotAndLogsOnError()
        {
            SaveLogs();
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                SaveScreenshot();
            }
        }
        private void SaveLogs()
        {
            string logsFilePath = "logs.txt";
            var logsParsed = new List<string>();

            try
            {
                IList<LogEntry> logs = _driver.Manage().Logs.GetLog(LogType.Browser);
                logs.ToList().ForEach(log => logsParsed.Add(log.ToString()));
                File.WriteAllLines(logsFilePath, logsParsed.ToArray(), Encoding.UTF8);
                TestContext.AddTestAttachment(logsFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving logs: {0}", ex);
            }
        }
        private void SaveScreenshot()
        {
            try
            {
                if (_driver is ITakesScreenshot takesScreenshot)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = Path.Combine("screenshot.png");
                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                    TestContext.AddTestAttachment(screenshotFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}
