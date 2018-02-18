using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Repka01.Pages
{
    class WishListPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//div[@class='info_block']/div/div/a[@class='product_name']")]
        private IList<IWebElement> _productsNames;

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchField;

        [FindsBy(How = How.XPath, Using = "//span[@id='delete_wishlist_item']")]
        private IWebElement _confirmRemoveProduct;

        [FindsBy(How = How.CssSelector, Using = "div.info_box_bottom>span.delete_product.action")]
        private IList<IWebElement> _removeProductElements;

        [FindsBy(How = How.CssSelector, Using = ".wish_list_item.clearfix:nth-child(1) .delete_product")]
        private IWebElement _removeProductElement;

        

        public WishListPage(IWebDriver driver) : base(driver)
        {
        }


        public void SwitchToWishListPageByUrl()
        {
            SwitchToPageByUrl("https://m.repka.ua/cabinet/wish-list");
        }


        public void CheckProductsAreInWishList(string name1, string name2)
        {
            IList<IWebElement> allElements = _productsNames;
            IList<String> text = new List<String>();

            foreach (IWebElement element in allElements)
            {
                text.Add(element.Text);
            }

            Assert.IsTrue(text.Contains(name1));
            Assert.IsTrue(text.Contains(name2));
        }

        public void ClearWishList()
        {
            Thread.Sleep(1000);
            int numberOfRemovedItems = 0;
            IList<IWebElement> list = _removeProductElements;
            if (list.Count > 0)
            {
                Console.WriteLine(list.Count + " items are found in the wish-list.");

                foreach (IWebElement element in list)
                {
                    Actions actions = new Actions(Driver);
                    actions.MoveToElement(element);
                    Thread.Sleep(400);
                    WaitUntilClickable(element).Click();
                    Thread.Sleep(400);
                    WaitUntilClickable(_confirmRemoveProduct).Click();

                    numberOfRemovedItems++;
                }

                Assert.AreEqual(list.Count + 1, numberOfRemovedItems, "Not all items are removed from wish-list.");
                Console.WriteLine("All items are removed from wish-list.");
            }
            else
            {
                Console.WriteLine("There are no products in wish-list.");
            }
        }
    }
}
