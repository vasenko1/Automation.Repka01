using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation.Repka01.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void SwitchToHomePageByUrl()
        {
            SwitchToPageByUrl("https://m.repka.ua/", "Repka.UA — надежный интернет-магазин");
        }

    }
}
