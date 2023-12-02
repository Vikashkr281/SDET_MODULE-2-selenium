using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class ClickOnLoginIcon
    {
        IWebDriver driver;
        public ClickOnLoginIcon(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//span[text()='Log In']")]
        public IWebElement ClickOnLogin { get; set; }
        public CreateAccountPage Clickonlogin()
        {
            ClickOnLogin.Click();
           
            return new CreateAccountPage(driver);
        }
    }
}
