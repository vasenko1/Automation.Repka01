using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Repka01.Pages
{
    class ProductPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "li.like>span")]
        private IWebElement _addToWishListButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='wishlist_popup']/span[@class='add_to_wishlist']")]
        private IWebElement _addToWishListPopupButton;
               

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddProductToWishList()
        {
            WaitUntilClickable(_addToWishListButton).Click();
            WaitUntilClickable(_addToWishListPopupButton).Click();
            Console.WriteLine("The product is added to wish-list.");
        }
    }
}
