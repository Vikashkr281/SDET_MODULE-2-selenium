using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class Login
    {
        IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);

        }
        [FindsBy(How =How.Id, Using = "login-email")]
        public IWebElement Email { get; set; }
        [FindsBy(How =How.Id,Using = "login-password")] 
        public IWebElement Password { get; set;}
        [FindsBy(How=How.Id,Using = "login-btn")]
        public IWebElement Submit { get; set; }

        public void LoginDetails(string email,string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
           // Submit.Click();

            
        }
        public void BackToHomePage()
        {

            driver.Navigate().GoToUrl("https://www.thrillophilia.com/");
            

        }
    }
}
