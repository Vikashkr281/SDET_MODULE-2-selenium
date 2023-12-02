using Thrilophilia.Utilities;
using OpenQA.Selenium.DevTools.V117.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrilophilia.Pageobjects;
using Serilog;

namespace Thrilophilia.TestScripts
{
    [TestFixture]
    internal class DestinationSearchTest : Corecodes
    {
        [Test]
        [Category("End To End")]
        


        public void SearchTest()
        {  //this is for TestData x=excel sheet
            string curDir = Directory.GetParent(@"../../../").FullName;
            string path = curDir + "/Logs/log_" + ".txt" + DateTime.Now.ToString("dd/'search-text'ddMMyyyy-hhmmss");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            string currDir = Directory.GetParent(@"../../../").FullName;
            string excelFilePath = currDir + "/TestData/Thrillophila.xlsx";
            string sheetName = "SearchDestination";

            List<SearchProductData> ?ListSearchProductData = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);
            //yha tak

            var searchdestination = new ThrilophiliaHomePages(driver);


            if (!driver.Url.Equals("https://www.thrillophilia.com/"))
            {
                driver.Navigate().GoToUrl("https://www.thrillophilia.com/");
            }
            searchdestination.SelectButtonFunction();
            Log.Information("Clicked on select button");


            foreach (var excel in ListSearchProductData)
            {
                try
                {
                    searchdestination.SearchTextFunction(excel.Destination);
                    Log.Information("Search destenation");
                    Assert.That(driver.Url.Contains("thrillophilia"));
                    test = extent.CreateTest("Thrillophilia search destination");
                    test.Pass(" success");



                }
                catch (AssertionException)
                {
                    test = extent.CreateTest("Destination Test");
                    test.Fail("Destination Search failed");

                }

                var select = searchdestination.EnterFunction();
                Log.Information("Clicked on search destination");



                var form = select.SelectProduct();

                List<string> lswindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lswindow[1]);

                form.Form(excel.Name, excel.Email, excel.Phone, excel.Count, excel.Message);
                Log.Information("to fill the form");

                form.SelectPAckage();
                Log.Information("To Select package");
                // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
                Thread.Sleep(4000);
                form.date();
                Log.Information("trip starting date");
               // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
                Thread.Sleep(3000);
                form.tripdate();
                form.Slot();
                Log.Information("trip timing slot");

                var login = form.Booktrip();
                Log.Information("Click on Book trip");
                TakeScreenShot();
                Log.Information("to take the screen shoot");
                Thread.Sleep(3000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                login.LoginDetails(excel.LoginEmail, excel.Password);
                Log.Information("For enter the Login id and password");

                TakeScreenShot();
                Log.Information("Final screen shot");
                login.BackToHomePage();
                Log.Information("After completing Back to home page");
                TakeScreenShot();
            }
        }
       


  }

}
