using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Drawing;

namespace Automation.Repka01.Base
{
    [TestFixture]
    [Parallelizable]
    class BaseWebDriver
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
            //reporter
        }

        [SetUp]
        public void SetUp()
        {
            driver = MyFactory.GetBrowserInstance("Chrome");
            driver.Manage().Window.Size = new Size(1920, 1200);  //Maximize();// 
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //reporter -> generate report
        }
    }
}
