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

        public By loginFormTitleXpath = By.XPath("//h3[@class='login-form__title']");
        public IWebElement LoginFormTitle => _webdriver.FindElement(loginFormTitleXpath);

        public IWebElement LoginForm => _webdriver.FindElement(By.XPath("//div[@id='root']//form"));

        public IWebElement LoginErrorMessage => _webdriver.FindElement(By.CssSelector
            ("#root div[class='login-form'] div[class='login-form__error']"));

        public IWebElement TenantInput => _webdriver.FindElement(By.XPath
            ("//div[@id='root']//form/input[@placeholder='Tenant']"));

        public IWebElement LoginInput => _webdriver.FindElement(By.XPath
            ("//div[@id='root']//form/input[@name='UserNameOrEmail']"));

        public IWebElement PasswordInput => _webdriver.FindElement(By.XPath
            ("//div[@id='root']//form/input[@type='password']"));

        public IWebElement SubmitButton => _webdriver.FindElement(By.XPath
            ("//div[@id='root']//form/input[@type='submit']"));
    }
}