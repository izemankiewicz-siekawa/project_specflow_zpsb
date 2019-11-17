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
        public static string HamiltonWebsite = "https://d-hamilton.azurewebsites.net/";
        public string HamiltonDashboard = $"{HamiltonWebsite}dashboard";
        public string HamiltonContractorModule = $"{HamiltonWebsite}contractor-module";

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

        //NAVIGATION
        public IWebElement navBackButton => _webdriver.FindElement(By.XPath
            ("//*[contains(@class,'sidebar-nav-back-button__button')]"));

        public IWebElement navCapitalsGroupButton => _webdriver.FindElement(By.XPath
            ("//*[contains(@class,'sidebar-nav-link__button') and text()='Grupy Kapitałowe']"));

        //VIEW
        public By TableListXPath = By.XPath("//*[@class='table__grid']");
        public IWebElement TableList => _webdriver.FindElement(TableListXPath);
        public IWebElement TableListCell => _webdriver.FindElement(By.XPath("//*[@class='table__cell']"));
        public IWebElement LoginFormPane => _webdriver.FindElement(By.XPath("//div[@id='root']/div/div/div"));

        public IWebElement pageLoaderSpinner => _webdriver.FindElement(By.CssSelector
            (".loader"));

        public IWebElement LAB20Label => _webdriver.FindElement(By.CssSelector
            ("#root > div > div.basic-layout > div > div.header > div.header__logo > a"));

        public By NickNameLabelCss = By.CssSelector("#root > div > div.basic-layout > div > div.header > div:nth-child(3) > div > div");
        public IWebElement NickNameLabel => _webdriver.FindElement(NickNameLabelCss);
        public By NavNickNameLabelXPath = By.XPath("//div[@id='root']//nav[@class='sidebar-nav']//div[@class='user-details']/div");
        public IWebElement NavNickNameLabel => _webdriver.FindElement(NavNickNameLabelXPath);

        public string ToastMessageValue;
        public By ToastMessageXpath => By.XPath ("//*[@class='messages-message__text' and text()='"+ ToastMessageValue + "']");
        public IWebElement ToastMessage => _webdriver.FindElement(ToastMessageXpath);
        public IWebElement ToastAnyMessage => _webdriver.FindElement(By.XPath("//*[@class='messages-message__text']"));

        public By CountOfListItemsXPath = By.XPath("//*[@class='table__pagination-total']");
        public IWebElement CountOfListItems => _webdriver.FindElement(CountOfListItemsXPath);

        //BIG BUTTONS
        public IWebElement BigContractorButton => _webdriver.FindElement(By.XPath
            ("//a[@href='/contractor-module' and text()='Kontrahent']"));

        public IWebElement BigControlPanelButton => _webdriver.FindElement(By.XPath
            ("//a[@href='/configuration-module' and text()='Panel Sterowania']"));

        public IWebElement BigRegistrationButton => _webdriver.FindElement(By.XPath("//a[@href='/registration-module' and text()='Rejestracja']"));

        //BUTTONS
        public By HistoryButtonXPath = By.XPath("//*[@class='link-button__element' and contains(text(), 'Historia zmian')]");
        public IWebElement HistoryButton => _webdriver.FindElement(HistoryButtonXPath);

        public By HistoricalDataButtonXPath = By.XPath("//*[@class='link-button__element' and text()='Historyczne dane']");
        public IWebElement HistoricalDataButton => _webdriver.FindElement(HistoricalDataButtonXPath);

        public IWebElement SaveButton => _webdriver.FindElement(By.XPath
            ("//div[@id='root']//div[@class='contractor-form__section-footer']/div[@class='button']/span"));

        public IWebElement SaveButtonOffering => _webdriver.FindElement(By.XPath
            ("//span[@class='button__title' and text()='Zapisz usługę']"));

        public By LogoutButtonXPath = By.XPath("//div[@id='root']//div[@class='header__exit']//span[@class='button__title']");
        public IWebElement LogoutButton => _webdriver.FindElement(LogoutButtonXPath);

        public IWebElement CloseModuleButton => _webdriver.FindElement(By.XPath
            ("//*[@class='header__exit-module']/a"));

        public string SelectDropdownValue;
        public By SelectDropdownTextXpath => By.XPath("//div[@class=' css-26l3qy-menu']/div/div[contains(text(),'" + SelectDropdownValue + "')]");
        public IWebElement SelectDropdownByText => _webdriver.FindElement(SelectDropdownTextXpath);

        public By SelectDropdownIdXpath => By.XPath("//div[@class=' css-26l3qy-menu']/div/div[substring(@id,string-length(@id) - string-length('" + SelectDropdownValue + "') +1)='" + SelectDropdownValue + "']");
        public IWebElement SelectDropdownById => _webdriver.FindElement(SelectDropdownIdXpath);

        public IWebElement LanguageButton => _webdriver.FindElement(By.XPath("//select[@class='lang-switch']"));
        public string LanguageOptionButtonValue = "en";
        public By LanguageOptionButtonXPath => By.XPath($"//select[@class='lang-switch']/option[@value='{LanguageOptionButtonValue}']");
        public IWebElement LanguageOptionButton => _webdriver.FindElement(LanguageOptionButtonXPath);

        //FILTERS
        public string FilterHamburgerNameValue;
        public string FilterItemNameValue;
        public By FilterHamburgerXpath => By.XPath("//div[@id='root']//div[@class='filters-list']/following::div[@class='table__header' and text()='" + FilterHamburgerNameValue + "']//div[contains(@class,'filter__button')]");
        public By FilterDropdownInputXpath => By.XPath("//div[@id='root']//div[@class='table__header' and text()='" + FilterHamburgerNameValue + "']//div[@class=' css-7wli7a']//input");
        public By FilterDropdownButtonXpath => By.XPath("//div[@id='root']//div[@class='table__header' and text()='" + FilterHamburgerNameValue + "']//div[@class=' css-1wy0on6']");
        public By FilterClearButtonXpath => By.XPath("//div[@id='root']//div[@class='table__header' and text()='" + FilterHamburgerNameValue + "']//span[@class='link-button__element']");
        public By FilterApplyButtonXpath => By.XPath("//div[@id='root']//div[@class='table__header' and text()='" + FilterHamburgerNameValue + "']//span[@class='button__title']");
        public By FilterRemoveItemButtonXpath => By.XPath(
            "//div[@id='root']//div[@class='table__header' and text()='" + FilterHamburgerNameValue + "']//div[@class=' css-7wli7a']//div[@class='css-12jo7m5' and text()='" + FilterItemNameValue + "']/following-sibling::div");
        
        public IWebElement FilterHamburger => _webdriver.FindElement(FilterHamburgerXpath);
        public IWebElement FilterDropdownInput => _webdriver.FindElement(FilterDropdownInputXpath);
        public IWebElement FilterDropdownButton => _webdriver.FindElement(FilterDropdownButtonXpath);
        public IWebElement FilterApplyButton => _webdriver.FindElement(FilterApplyButtonXpath);
        public IWebElement FilterClearButton => _webdriver.FindElement(FilterClearButtonXpath);
        public IWebElement FilterRemoveItemButton => _webdriver.FindElement(FilterRemoveItemButtonXpath);

        public By FilterChoosenButtonXPath = By.XPath("//div[@id='root']//div[@class='filters-list__button']");
        public IWebElement FilterChoosenButton=> _webdriver.FindElement(FilterChoosenButtonXPath);
        public IWebElement FilterCreateLink => _webdriver.FindElement(By.XPath("//div[@id='root']//span[@class='link-button__element' and text()='Utwórz nowy']"));
        public string FilterUpdateLinkValue = "Zaktualizuj zmieniony widok";
        public IWebElement FilterUpdateLink => _webdriver.FindElement(By.XPath("//div[@id='root']//span[@class='link-button__element' and text()='"+ FilterUpdateLinkValue + "']"));
        public IList<IWebElement> FilterHeaderLinks => _webdriver.FindElements(By.XPath("//div[@id='root']//div[@class='filters-list__popup-actions']//span[@class='link-button__element']"));
        public IWebElement FilterCreateNameInput => _webdriver.FindElement(By.XPath("//div[@id='root']//div[@class='filters-list__popup-create-grid']//input[@name='name']"));
        public IWebElement FilterCreateAccessDropDown => _webdriver.FindElement(By.XPath("//div[contains(@class,'filters-list__popup-create-title') and text()='Utwórz nowy']/following-sibling::div//div[@class=' css-7wli7a']"));
        public By FilterSaveNewButtonXPath = By.XPath("//div[@id='root']//div[@class='filters-list__popup-create-grid']//div[@class='button']");
        public IWebElement FilterSaveNewButton => _webdriver.FindElement(FilterSaveNewButtonXPath);

        public By FilterCloseCreateButtonXPath = By.XPath("//div[@id='root']//div[@class='filters-list__popup-footer']//span[@class='button__title']");
        public IWebElement FilterCloseCreateButton => _webdriver.FindElement(FilterCloseCreateButtonXPath);

        public string FilterSavedNameLinkValueInTable;
        public By FilterSavedNameLinkInTableXpath => By.XPath("//div[@id='root']//div[@class='filters-list__popup-list-item']/div[@class='filters-list__popup-list-item-name']/div/span[text()='" + FilterSavedNameLinkValueInTable + "']");
        public IWebElement FilterSavedNameLinkInTable => _webdriver.FindElement(FilterSavedNameLinkInTableXpath);
        public By FilterSavedDeleteLinkInTableXpath => By.XPath("//div[@id='root']//div[@class='filters-list__popup-list-item']/div[@class='filters-list__popup-list-item-name']/div/span[text()='" + FilterSavedNameLinkValueInTable + "']/../../following-sibling::div[@class='filters-list__popup-list-item-delete']/div/span");
        public IWebElement FilterSavedDeleteLinkInTable => _webdriver.FindElement(FilterSavedDeleteLinkInTableXpath);
        public By FilterSavedEditNameLinkInTableXPath => By.XPath("//div[@id='root']//div[@class='filters-list__popup-list-item']/div[@class='filters-list__popup-list-item-name']/div/span[text()='" + FilterSavedNameLinkValueInTable + "']/../../following-sibling::div[@class='filters-list__popup-list-item-update']/div/span");
        public IWebElement FilterSavedEditNameLinkInTable => _webdriver.FindElement(FilterSavedEditNameLinkInTableXPath);
        public By FilterSavedDefaultLinkInTableXpath => By.XPath("//div[@id='root']//div[@class='filters-list__popup-list-item']/div[@class='filters-list__popup-list-item-name']/div/span[text()='" + FilterSavedNameLinkValueInTable + "']/../../following-sibling::div[@class='filters-list__popup-list-item-default']/div/span");
        public IWebElement FilterSavedDefaultLinkInTable => _webdriver.FindElement(FilterSavedDefaultLinkInTableXpath);
        public By FilterSavedModalConfirmButtonXpath => By.XPath("//div[@id='root']//div[@class='modal']//div[contains(text(),'" + FilterSavedNameLinkValueInTable + "') or text() ='" + FilterSavedNameLinkValueInTable + "']/..//span[@class='button__title']");
        public IWebElement FilterSavedModalConfirmButton => _webdriver.FindElement(FilterSavedModalConfirmButtonXpath);
        public By FilterSavedModalDeleteButtonXpath => By.XPath("//div[@id='root']//div[@class='modal']//div[contains(text(),'" + FilterSavedNameLinkValueInTable + "') or text() ='" + FilterSavedNameLinkValueInTable + "']/..//span[@class='button__title']");
        public IWebElement FilterSavedModalDeleteButton => _webdriver.FindElement(FilterSavedModalDeleteButtonXpath);
        public By FilterSavedModalNameInputXpath => By.XPath("//div[@id='root']//div[@class='modal']//div[contains(text(),'" + FilterSavedNameLinkValueInTable + "') or text() ='" + FilterSavedNameLinkValueInTable + "']/..//input[@name='name']");
        public IWebElement FilterSavedModalNameInput => _webdriver.FindElement(FilterSavedModalNameInputXpath);

        public By FiltersSavedNamesLinksInTableXpath = By.XPath("//div[@id='root']//div[@class='filters-list__popup-list-item']//div[@class='filters-list__popup-list-item-name']//span");
        public IList<IWebElement> FiltersSavedNamesLinksInTable => _webdriver.FindElements(FiltersSavedNamesLinksInTableXpath);


        public void OpenHamiltonWebsite()
        {
            _webdriver.Navigate().GoToUrl(HamiltonWebsite);
        }

        //DON'T USE IT IN DEVELOPMENT ENVIROMENT//
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