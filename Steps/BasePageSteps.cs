using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumTests.Steps
{
    [Binding]
    public class BasePageSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly BasePage _basePage;
        private readonly LoginPage _loginPage;
        

        public BasePageSteps(IWebDriver driver, Translations translation)
        {
            _
            _webdriver = driver;
            _basePage = new BasePage(_webdriver);
            _loginPage = new LoginPage(_webdriver);
           
        }

        [StepDefinition(@"I open login page")]
        public void GivenIOpen()
        {
            _basePage.Open();
        }

        
       
        

      
     
    }
}