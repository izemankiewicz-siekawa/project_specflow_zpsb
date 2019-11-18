using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTests.Steps
{
    [Binding]
    public class BasePageSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly BasePage _basePage;
        private readonly LoginPage _loginPage;


        public BasePageSteps(IWebDriver driver)
        {
          
            _webdriver = driver;
            _basePage = new BasePage(_webdriver);
            _loginPage = new LoginPage(_webdriver);

        }

        [StepDefinition(@"I open home page")]
        public void GivenIOpenHomePage()
        {
            _basePage.OpenAutomationWebsite();
        }

        [Given(@"I click in Sign in button")]
        public void GivenIClickInSignInButton()
        {
            _basePage.HomeSignInButton.Click();
        }

    }
}