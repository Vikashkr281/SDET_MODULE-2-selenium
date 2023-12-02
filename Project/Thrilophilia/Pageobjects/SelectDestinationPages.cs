using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class SelectDestinationPages
    {
        IWebDriver? driver;
        public SelectDestinationPages(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Grand Island Goa Scuba Diving with Transfers")]
        public IWebElement Destinationselect { get; set; }

        public SelectedDestinationPages SelectProduct()
        {
            Destinationselect?.Click();
            return new SelectedDestinationPages(driver);
        }
    }
}

