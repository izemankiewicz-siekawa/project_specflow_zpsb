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

        [Given(@"I can see login view")]
        public void WhenICanSeeLoginView()
        {
            Assert.True(_loginPage.LoginForm.Displayed);
        }

        [When(@"I write login '(.*)'")]
        public void WhenIWriteLogin(string login)
        {
            _loginPage.LoginInput.SendKeys(login);
        }

        [When(@"I write password '(.*)'")]
        public void WhenIWritePassword(string password)
        {
            _loginPage.PasswordInput.SendKeys(password);
        }

        [When(@"I write tenant '(.*)'")]
        public void WhenIWriteTenant(string tenant)
        {
            _loginPage.TenantInput.SendKeys(tenant);
        }

        [When(@"I click on Submit button")]
        public void WhenIClickOnSubmitButton()
        {
            _loginPage.SubmitButton.Click();
        }

        [When(@"I click ENTER on keyboard")]
        public void WhenIClickENTEROnKeyboard()
        {
            _loginPage.PasswordInput.SendKeys(Keys.Enter);
        }


        [Then(@"I am logged to J\.S\.Hamilton main page")]
        public void ThenIAmLoggedToJ_S_HamiltonMainPage()
        {
            Assert.True(_basePage.LAB20Label.Displayed);
        }

        [Then(@"I can see error message")]
        public void ThenICanSeeErrorMessage()
        {
            Assert.True(_loginPage.LoginErrorMessage.Displayed);
        }

        [Then(@"I can see J\.S\.Hamilton login form")]
        public void ThenICanSeeJ_S_HamiltonLoginForm()
        {
            Assert.True(_loginPage.LoginForm.Displayed);
        }

        [Then(@"I am redirected to J\.S\.Hamiltin login page")]
        public void ThenIAmRedirectedToJ_S_HamiltinLoginPage()
        {
            Assert.True(_loginPage.LoginForm.Displayed);
        }
    }
}