using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Steps;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SeleniumTests
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebDriver _webdriver;
        private readonly IObjectContainer _objectContainer;
        private const int _Timeout = 15;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.AddArgument("--start-maximized");
            _webdriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            _webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_Timeout);
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_Timeout);
            _webdriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(_Timeout);
            _webdriver.Manage().Cookies.DeleteAllCookies();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs<IWebDriver>(_webdriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var errorClass = new GenerateOutput(_webdriver);
            errorClass.SaveScreenshotAndLogsOnError();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _webdriver.Quit();
        }
    }
}