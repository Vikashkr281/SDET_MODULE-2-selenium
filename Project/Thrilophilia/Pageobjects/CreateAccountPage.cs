using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class CreateAccountPage
    {
        IWebDriver driver;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//ul//li[text()='Sign Up']")]
        public IWebElement Signup { get; set; }
        public void ClickOnSignup()
        {
            Signup.Click();

        }
        [FindsBy(How =How.XPath,Using = "//input[@id='signup-name']")]
        public IWebElement NAME { get; set; }
        [FindsBy(How =How.Name,Using = "phoneNumber")]
        public IWebElement Phone { get; set; }
        [FindsBy(How=How.Id,Using = "signup-email")]
        public IWebElement Email { get; set; }
        [FindsBy(How=How.XPath,Using = "//input[@id='signup-password']")]
        public IWebElement Password { get; set; }
        [FindsBy(How=How.Id,Using = "signup-password-confirmation")]
        public IWebElement PasswordHash { get; set; }
        public void YourName(string name,string phone,string email,string password,string passwordhash)
        {
            NAME.SendKeys(name);
            Phone.SendKeys(phone);
            Email.SendKeys(email);
            Password.SendKeys(password);
            PasswordHash.SendKeys(passwordhash);
        }
        [FindsBy(How =How.Id,Using = "sign-up-btn")]
       public IWebElement btnsignup { get; set; }
        public void Signupbtn()
        {
            btnsignup.Click();
        }
        [FindsBy(How=How.Id,Using = "react-tabs-2")]
        public IWebElement loginbtn { get; set; }
        public void ClickloginBtn()
        {
            loginbtn.Click();
          
        }
        [FindsBy(How =How.Id,Using = "login-email")]
        public IWebElement lEmail { get; set;}
        [FindsBy(How=How.Id,Using = "login-password")]
        public IWebElement lPassword { get; set;}
        public void LoginiAccount(string email,string password)
        {
            lEmail.SendKeys(email);
            lPassword.SendKeys(password);
        }
        [FindsBy(How=How.Id,Using = "login-btn")]
        public IWebElement loginbtnClick { get; set; }
        public SupportCheck LoginbtnClick()
        {
            loginbtnClick.Click();
            return new SupportCheck(driver);
            
        }

    }
}

