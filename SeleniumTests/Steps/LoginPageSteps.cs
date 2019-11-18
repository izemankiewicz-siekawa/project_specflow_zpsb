using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTests.Steps
{
    [Binding]
    public class LoginPageSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly BasePage _basePage;
        private readonly LoginPage _loginPage;

        public LoginPageSteps(IWebDriver driver)
        {
            _webdriver = driver;
            _basePage = new BasePage(_webdriver);
            _loginPage = new LoginPage(_webdriver);
        }

        [Given(@"I write login '(.*)'")]
        public void GivenIWriteLogin(string login)
        {
            _loginPage.LoginInput.SendKeys(login);
        }



        [Given(@"I write password '(.*)'")]
        public void GivenIWritePassword(string password)
        {
            _loginPage.PasswordInput.SendKeys(password);
        }

        [When(@"I click submit button")]
        public void WhenIClickSubmitButton()
        {
            _loginPage.SubmitButton.Click();
        }

        [Then(@"I see page MY ACCOUNT")]
        public void ThenISeePageMYACCOUNT()
        {
            Assert.True(_loginPage.MyAccountPage.Displayed);
        }


    }
}