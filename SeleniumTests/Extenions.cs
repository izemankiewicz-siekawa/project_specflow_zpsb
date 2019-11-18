using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Pages;
using System;

namespace SeleniumTests
{
    public static class Extensions
    {
        /// <summary>
        /// Use it when React loads element and u wait for text in it
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        public static void WaitToLoadText(this IWebElement element, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, (int)BasePage.TimeoutDeclare.Timeout));

            string textcmp, text = "";
            wait.Until(webdriver =>
            {
                textcmp = text;
                text = element.Text;
                return (text.Equals(textcmp) & text.Length > 0) ? element : null;
            });
        }

        public static string WaitForElementToBeClickable(this IWebElement element, IWebDriver driver)
        {
            BasePage.Sleep(500);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, (int)BasePage.TimeoutDeclare.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return element.Text;
        }

        /// <summary>
        /// Wait for element to be part of DOM and it is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IWebElement WaitForElementToBeStaleAndClickable(this IWebDriver driver, IWebElement element, By selector)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, (int)BasePage.TimeoutDeclare.Timeout));
            try
            {
                BasePage.Sleep(500);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return element;
            }
            catch (Exception e) when (e is WebDriverTimeoutException || e is StaleElementReferenceException)
            {
                element = driver.FindElement(selector);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return element;
            }
        }

        /// <summary>
        /// Clear text from input
        /// </summary>
        /// <param name="element"></param>
        public static void ClearText(this IWebElement element)
        {
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Control + Keys.Backspace);
        }

        /// <summary>
        /// This is faster but less safe than WaitUntilElementNotExist function to see if element is present on the pgae
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static bool ElementNotExist(this IWebDriver driver, By selector)
        {
            return (driver.FindElements(selector).Count.Equals(0)) ? true : false;
        }

        /// <summary>
        /// This will cause some delay to the test.
        /// Use it when u dont have element on page and u need to be sure that it is not present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static bool WaitUntilElementNotExist(this IWebDriver driver, By selector)
        {
            BasePage.Sleep(500);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, (int)BasePage.TimeoutDeclare.TimeoutShort));
            try
            {
                wait.Until(webdriver => (driver.FindElements(selector).Count.Equals(0)));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Use it when you have element and u need to be sure that it disappeared
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void WaitUntilElementDisapears(this IWebDriver driver, IWebElement element)
        {
            BasePage.Sleep(500);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, (int)BasePage.TimeoutDeclare.TimeoutShort));
            try
            {
                wait.Until(webdriver => element.Displayed ? false : true);
            }
            catch (Exception e) when (e is WebDriverTimeoutException || e is StaleElementReferenceException)
            {
                return;
            }
        }
    }
}