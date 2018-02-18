using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Repka01.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Repka01.Pages
{
    class BasePage
    {
        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchField;

        [FindsBy(How = How.Id, Using = "open-menu")]
        private IWebElement _mainCatalog;

        [FindsBy(How = How.XPath, Using = "//div[@id='dropdown-menu-wraper']/ul[@class='dropdown-menu']/li/a/span")]
        private IList<IWebElement> _mainCatalogItemsElements;

        [FindsBy(How = How.CssSelector, Using = "div[onclick='javascript:socialLogin.open();']")]
        private IWebElement _loginButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='magestore-sociallogin-popup-email']")]
        private IWebElement _emailField;

        [FindsBy(How = How.XPath, Using = "//input[@id='magestore-sociallogin-popup-pass pass']")]
        private IWebElement _passwordField;

        [FindsBy(How = How.XPath, Using = "//button[@id='magestore-button-sociallogin']")]
        private IWebElement _submitLoginButton;

        [FindsBy(How = How.CssSelector, Using = ".account-holder.repka_popup_holder")]
        private IWebElement _accountButton;

        [FindsBy(How = How.CssSelector, Using = ".logout")]
        private IWebElement _logoutButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='yes-btn']")]
        private IWebElement _selectCityPopupYesButton;

        [FindsBy(How = How.CssSelector, Using = ".wishlist-holder")]
        private IWebElement _wishListButton;
        

        public IWebDriver Driver { get; set; }

        public static int defaultTime = 10;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);//, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(defaultTime), TimeSpan.FromSeconds(defaultTime / 2)));
        }

        public void SwitchToPageByUrl(string url, string title)
        {
            Driver.Navigate().GoToUrl(url);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(defaultTime))
                .Until(ExpectedConditions.TitleContains(title));
        }

        public void SwitchToPageByUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void SearchProductByText(string text)
        {
            _searchField.Clear();
            _searchField.SendKeys(text);
            _searchField.Submit();
            if (Driver.Url.Contains("catalogsearch"))
            {
                Console.WriteLine("You need to write logic!!!");
            }
            else
            {
                Console.WriteLine("Product page '" + text + "' is opened.");
            }
        }

        public void ClickCatalogItemByText()
        {
            _mainCatalog.Click();
            IList<IWebElement> allMainCatalogElements = _mainCatalogItemsElements;
            IList<String> value = new List<String>();
        }

        public void LogIn()
        {
            _loginButton.Click();

            var user = UserCredentials.users["Test"];
            _emailField.SendKeys(user.Email);
            _passwordField.SendKeys(user.Password);
            _submitLoginButton.Click();

            Thread.Sleep(2000);
            Assert.IsTrue(_logoutButton.Enabled);
            Console.WriteLine("Login is successful.");
        }

        public void LogOut()
        {
            Thread.Sleep(2000);
            _accountButton.Click();
            Thread.Sleep(500);
            _logoutButton.Click();

            Console.WriteLine("Logout is successful.");
        }

        public void SelectCity()
        {
            if (_selectCityPopupYesButton.Displayed)
            {
                _selectCityPopupYesButton.Click();
            }
            else
            {
                Console.WriteLine("Select city popup is not presented.");
            }
        }

        public IWebElement WaitUntilClickable(IWebElement element)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(defaultTime))
                    .Until(ExpectedConditions.ElementToBeClickable(element));
                return element;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return element;
            }
        }

        public void SwitchToWishListPageByMenuButton()
        {
            _wishListButton.Click();
        }
    }
}
