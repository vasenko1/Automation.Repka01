using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Automation.Repka01.Base
{
    class MyFactory
    {
        internal static IWebDriver GetBrowserInstance(string driverName)
        {
            switch (driverName.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("--headless");
                    //chromeOptions.AddArguments("disable-infobars");
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    return new FirefoxDriver();

                case "edge":
                    return new EdgeDriver();

                default:
                    throw new Exception("Unknown driver Name: '" + driverName + "'.");
            }
        }
    }
}
