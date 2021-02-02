using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SitecoreAssignment.Config
{
    public class ActionClass
    {
       

        public void  initializedriver()
        {
            // Intializing the obj of the class
            DriverHelper Driver = new DriverHelper();

            Driver.webDriver = new ChromeDriver();
            Driver.webDriver.Navigate().GoToUrl(Data_Driven_Class.baseURL);

            
        }




    }
}
