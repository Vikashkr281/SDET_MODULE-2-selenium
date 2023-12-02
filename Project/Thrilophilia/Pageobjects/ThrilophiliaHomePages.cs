using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class ThrilophiliaHomePages
    {
        IWebDriver driver;
        public ThrilophiliaHomePages(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//button[@data-tab-name='all']")]
        public IWebElement? SelectButton { get; set; }
        public void SelectButtonFunction()
        {
            SelectButton?.Click();
            Thread.Sleep(3000);
        }
        [FindsBy(How = How.Name, Using = "search")]
        public IWebElement? SearchText { get; set; }
        public void SearchTextFunction(string destination)
        {
            SearchText?.SendKeys(destination);
            Thread.Sleep(3000);

        }
        public SelectDestinationPages EnterFunction()
        {
            SearchText?.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            return new SelectDestinationPages(driver);
        }
    }
}
