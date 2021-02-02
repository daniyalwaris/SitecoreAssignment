using AventStack.ExtentReports;
using OpenQA.Selenium;
using SitecoreAssignment.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.Config
{
    class Reporting: DriverHelper 
    {
        
        public MediaEntityModelProvider CaptureScreenSHotandReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot().AsBase64EncodedString;
          return  MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();

        }


    }
}
