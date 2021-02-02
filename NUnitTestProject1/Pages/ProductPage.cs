using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SitecoreAssignment.Pages
{
    class ProductPage
    {
        public ProductPage (IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; }

     
        public IWebElement GetPriceValue => Driver.FindElement(By.XPath("//*[contains(@class,'priceBlock')]"));



    }

   
}
