using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumTests.Pages
{
    [Binding]
    public class BasePage
    {
        private IWebDriver _webdriver;
        public static string AutomationWebsite = "http://automationpractice.com/index.php";

        public enum TimeoutDeclare 
        {
        Timeout = 5,
        TimeoutShort = 2,
        TimeoutLong = 10,
        }

        public BasePage(IWebDriver driver)
        {
            _webdriver = driver;
        }

        public IWebElement HomeSignInButton => _webdriver.FindElement(By.XPath("//a[@class='login']"));

        public void OpenAutomationWebsite()
        {
            _webdriver.Navigate().GoToUrl(AutomationWebsite);
        }

        public static void Sleep(int millisecond)
        {
            try
            {
                Thread.Sleep(millisecond);
            }
            catch { }
        }
    }
}