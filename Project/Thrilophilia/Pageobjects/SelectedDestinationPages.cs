using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrilophilia.Pageobjects
{
    internal class SelectedDestinationPages
    {
        IWebDriver? driver;
        DefaultWait<IWebDriver> wait;
        public SelectedDestinationPages(IWebDriver? driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
        }
        public void DynamicWait()
        {
             wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "Element not Found";
        }
        [FindsBy(How = How.Name, Using = "enquirer_name")]
        public IWebElement Name { get; set; }
        [FindsBy(How=How.Name,Using = "enquirer_email")]
        public IWebElement Email { get; set;}
        [FindsBy(How=How.XPath,Using = "//input[@Placeholder=\"Phone\"]")]
        public IWebElement Phone { get; set;}
        [FindsBy(How=How.Id,Using = "enquiry-date-input")]
        public IWebElement Date { get; set;}
        [FindsBy(How=How.XPath,Using = "//*[@aria-label=\"Choose Friday, December 15th, 2023\"]")]
        public IWebElement Chosedate { get; set;}
        [FindsBy(How=How.Name,Using = "number_of_pax")]
        public IWebElement Count { get; set;}
        [FindsBy(How=How.XPath,Using = "//textarea[@placeholder=\"Message\"]")]
        public IWebElement Message { get; set;}
        public void Form(string? name, string? email,string? phone,string? count,string? message) 
        {
            Name.SendKeys(name);
            Email.SendKeys(email);
            Phone.SendKeys(phone);
            Count.SendKeys(count);
            Message.SendKeys(message);
            Thread.Sleep(5000);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
      //  [FindsBy(How =How.XPath,Using = "//button[text()='Package Options']")]
       // public IWebElement package { get; set;}
        [FindsBy(How=How.XPath,Using = "(//div[@class='variant__head'])[1]")]
      
        public IWebElement cost { get; set;}
        public void SelectPAckage()
        {
            DynamicWait();
            //package.Click();
            wait.Until(d => cost.Displayed);
            cost.SendKeys(Keys.Enter);
        }

        [FindsBy(How=How.XPath,Using = "(//label[@class='info-with-icon__info-heading'])[1]")]
        public IWebElement dateselect { get; set;}
        public void date()
        {
            DynamicWait();
           wait.Until(d => dateselect.Displayed);
            dateselect.Click();

        }
        [FindsBy(How =How.XPath,Using = "//div[@aria-label='Choose Wednesday, December 20th, 2023']")]
        public IWebElement dateselected { get; set;}
        public void tripdate()
        {

            DynamicWait();
            wait.Until(d => dateselected.Displayed);
            dateselected.SendKeys(Keys.Enter);
        }

        //for selecting the slot
        [FindsBy(How =How.XPath,Using = "//div[div[text()='Travel Time']]")]
        public IWebElement timeselect { get; set;}

        [FindsBy(How =How.XPath,Using = "//label[@id='popularity_widget_toggler']")]
        public IWebElement CloseButton { get; set;}
        public void Slot()
        {

           Thread.Sleep(10000);
            DynamicWait();

            wait.Until(d => CloseButton.Displayed);
            CloseButton.Click();
            timeselect.Click();
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter).Perform();
        
            
        }
        [FindsBy(How =How.XPath,Using = "//button[text()='Book Now']")]
        public IWebElement Book { get; set;}
        public Login Booktrip()
        {
            Book.Click();
            return new Login(driver);
        }
    }
}
