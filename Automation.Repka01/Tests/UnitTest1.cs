using System;
using Automation.Repka01.Base;
using Automation.Repka01.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Automation.Repka01.Tests
{
    [TestFixture]
    [Parallelizable]
    class Test01 : BaseWebDriver
    {
        HomePage homePage;
        ProductPage productPage;
        BasePage basePage;
        WishListPage wishListPage;


        [Test]
        public void ChekingWishList()
        {
            homePage = new HomePage(driver);
            productPage = new ProductPage(driver);
            basePage = new BasePage(driver);
            wishListPage = new WishListPage(driver);

            
            homePage.SwitchToHomePageByUrl();
            homePage.SelectCity();
            homePage.SearchProductByText("311722");
            productPage.LogIn();
            productPage.AddProductToWishList();
            productPage.SearchProductByText("250346");
            productPage.AddProductToWishList();
            productPage.SwitchToWishListPageByMenuButton();
            //wishListPage.CheckProductsAreInWishList();
            wishListPage.ClearWishList();
            wishListPage.LogOut();
        }
        [Test]
        public void CheckingProductLowerAndHigherPrice()
        {
            //OpenHomePage();
            //NavigateToProdFilterPageUsingCatalog("");
            //SearchLowestPriceProduct();
            //AddProductToCart();
            //SearchHighestPriceProduct();
            //AddProductToCart();
            //OpenCartPage();
        }

        [Test]
        public void PlacingOrderAsAnonymous()
        {
            //OpenHomePage();
            //SelectCity("");
            //SearchProductByID("");
            //AddProductToCart();
            //SearchProductByName("");
            //AddProductToCart();
            //OpenCartPage();
            //Checkout();
            //PlaceOrderWithAsAnonymouse();
        }
    }
}
