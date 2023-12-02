using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrilophilia.Pageobjects;
using Thrilophilia.Utilities;

namespace Thrilophilia.TestScripts
{
    internal class SupportTest : Corecodes
    {
        [Test]
        [Order(4)]
        [Category("Support Testing")]
        public void CheckSupport()
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

            var supportPage = new SupportCheck(driver);
            try
            {
                supportPage.CheckSupport();
                Log.Information("Click on Support button");
                List<string> lswindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lswindow[1]);
              
                Console.WriteLine(driver.Url);
                Assert.That(driver.Url.Equals("https://thrillophilia.freshdesk.com/support/home"));
                test = extent.CreateTest("Support is working or not");
                test.Pass(" success");



            }
            catch (AssertionException)
            {
                test = extent.CreateTest("support Test");
                test.Fail("support Search failed");

            }
            try
            {
                supportPage.CheckRefendRelatedIssue();
                Log.Information("Click on RefendButton ");
                List<string> lswindow1 = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lswindow1[1]);
                Console.WriteLine(driver.Url);
                Assert.That(driver.Url.Equals("https://thrillophilia.freshdesk.com/support/solutions/5000174653"));
                test = extent.CreateTest("refund  is working or not");
                test.Pass(" success");
                TakeScreenShot();



            }
            catch (AssertionException)
            {
                test = extent.CreateTest("refund Test");
                test.Fail("refund Search failed");

            }
            




        }
    }
}
