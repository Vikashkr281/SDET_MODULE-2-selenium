using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class SupportCheck
    {
        IWebDriver driver;
        public SupportCheck(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//a[normalize-space()='SUPPORT']")]
        public IWebElement Support {  get; set; }
        public void CheckSupport()
        {
            Support.Click();
            Thread.Sleep(3000);
        }
        [FindsBy(How =How.XPath,Using = "//p[normalize-space()='Refund related issues']")]
        public IWebElement Refend { get; set; }
        public void CheckRefendRelatedIssue()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()",Refend);
            // Refend.Click();
            //Thread.Sleep(2000);
        }

    }
}
