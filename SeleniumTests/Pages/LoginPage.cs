using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumTests.Pages
{
    [Binding]
    public class LoginPage
    {
        private IWebDriver _webdriver;

        public LoginPage(IWebDriver driver)
        {
            _webdriver = driver;
        }

        public IWebElement LoginInput => _webdriver.FindElement(By.Id("email"));

        public IWebElement PasswordInput => _webdriver.FindElement(By.Id("passwd"));

        public IWebElement SubmitButton => _webdriver.FindElement(By.XPath("//button[@id='SubmitLogin']"));

        public IWebElement MyAccountPage => _webdriver.FindElement(By.XPath("//h1[@class='page-heading' and text()='My account']"));

    }
}