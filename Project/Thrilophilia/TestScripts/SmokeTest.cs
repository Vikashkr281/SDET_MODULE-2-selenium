using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Thrilophilia.Pageobjects;
using Thrilophilia.Utilities;

namespace Thrilophilia.TestScripts
{
    [TestFixture]
    internal class SmokeTest :Corecodes
    {
        [Test]
        [Order(2)]
        [Category("SmokeTesting")]
        public void CheckSignupAndLogin()
        {
            string curDir = Directory.GetParent(@"../../../").FullName;
            string path = curDir + "/Logs/log_" + ".txt" + DateTime.Now.ToString("dd/'search-text'ddMMyyyy-hhmmss");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string excelFilePath = currDir + "/TestData/Thrillophila.xlsx";
            string sheetName = "SignUpLogin";
            List<LoginForm> LoginData = ExcelUtilities.ReadExcelData2(excelFilePath, sheetName);
            if (!driver.Url.Equals("https://www.thrillophilia.com/"))
            {
                driver.Navigate().GoToUrl("https://www.thrillophilia.com/");
            }
            var createAccount = new ClickOnLoginIcon(driver);
            foreach (var excel1 in LoginData)
            {
                try
                {

                    Assert.That(driver.Url.Contains("thrillophilia"));
                    test = extent.CreateTest("Thrillophilia LoginAndSignUp Function");
                    test.Pass(" success");



                }
                catch (AssertionException)
                {
                    test = extent.CreateTest("Destination Test");
                    test.Fail("Destination Search failed");

                }

                var create = createAccount.Clickonlogin();
                Log.Information("Click on Login icon to register ");
                List<string> lswindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lswindow[1]);
                Thread.Sleep(5000);
               // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                create.ClickOnSignup();
                Log.Information("Click on signup to create new account");
                Thread.Sleep(3000);
               // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                create.YourName(excel1.Name,excel1.Phone,excel1.Email,excel1.Password,excel1.Re_Password);
                Log.Information("Filling the required field like Name Email Passwords etc");
                create.Signupbtn();
                Log.Information("Click on Signup now to create your account");
                create.ClickloginBtn();
                Log.Information("Click on login button to login into the account");
                create.LoginiAccount(excel1.Email, excel1.Password);
                Log.Information("Enter email and password for varification");
                create.LoginbtnClick();
                Log.Information("click on login button");
                TakeScreenShot();
                
           }
        }

        [Test]
        [Order(3)]
        [Category("Smoke testing link status check")]
        public void Linkcheck()
        {
            string curDir = Directory.GetParent(@"../../../").FullName;
            string path = curDir + "/Logs/log_" + ".txt" + DateTime.Now.ToString("dd/'search-text'ddMMyyyy-hhmmss");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string excelFilePath = currDir + "/TestData/Thrillophila.xlsx";
            string sheetName = "SignUpLogin";
            List<LoginForm> LoginData = ExcelUtilities.ReadExcelData2(excelFilePath, sheetName);
            if (!driver.Url.Equals("https://www.thrillophilia.com/"))
            {
                driver.Navigate().GoToUrl("https://www.thrillophilia.com/");
            }
            try
            {
                CheckLinkStatus("https://www.thrillophilia.com/");
                Assert.That(driver.Url.Contains("thrillophilia"));
                test = extent.CreateTest("Thrillophilia LoginAndSignUp Function");
                test.Pass(" success");
                TakeScreenShot();



            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Destination Test");
                test.Fail("Destination Search failed");

            }

            

        }

    }
}
