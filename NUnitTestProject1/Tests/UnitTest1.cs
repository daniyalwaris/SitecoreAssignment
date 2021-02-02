using SitecoreAssignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SitecoreAssignment.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SitecoreAssignment
{
    public class AmazonTestScenario : DriverHelper
    {

        private static ExtentReports extent;

        private static ExtentTest test;

       //HOOKS in NUNIT
        [SetUp]
        public void Setup()
        {

            webDriver = new ChromeDriver(@"C:\Driver");
            //Navigaate to the Site 
            webDriver.Navigate().GoToUrl(Data_Driven_Class.baseURL);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {

            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\ReportResults\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

        }

        [Test]
        public void AmazonSearchItemTestCase()
        {
            test = null;
            test = extent.CreateTest("Amazon Search Automation");

            // Initalizing the constructor for references
            HomePage homepage = new HomePage(webDriver);
            SearchPage searchPage = new SearchPage(webDriver);
            ProductPage productpage = new ProductPage(webDriver);
            WebDriverWait wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));

            try
            {
                Assert.That(webDriver.Title.ToString(), Does.Contain("Amazon"), "The user not navigated to the Actual page");
                test.Log(Status.Pass, "Assert Pass");

                test.Log(Status.Info, "Main Page");
                Controls.EnterText(homepage.TxtInputSeachTextField, DataEntry.SeaarchValue);
                Controls.Click(homepage.btnSeachSubmit);
                
                test.Log(Status.Info, "Search Page");
                Controls.Click(searchPage.productlist);

                test.Log(Status.Info, "Product Page");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[contains(@class,'priceBlock')]")));
                string txtPriceElement = productpage.GetPriceValue.Text.ToString();
                int PriceValue = int.Parse(txtPriceElement[1].ToString() + txtPriceElement[2].ToString() + txtPriceElement[3].ToString());
                Console.WriteLine("Actual Sale Price of the Laptop = " + PriceValue);

                Assert.GreaterOrEqual(PriceValue, Laptopprice.CompareValue, "Assert Failed : " + " Actual Price " + PriceValue + " is less than the " + Laptopprice.CompareValue);
                test.Log(Status.Pass, "Assert Pass");

            }

            catch(Exception e)
            {
                test.Log(Status.Fail, "Test Fail");
            }
    }
      
       [TearDown]
         public void CleanUp()
         {
             webDriver.Close();
         }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
        
    }
}