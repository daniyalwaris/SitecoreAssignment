using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SitecoreAssignment.Pages
{
    class SearchPage
    {
        public SearchPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; }


        public IWebElement productlist => Driver.FindElement(By.XPath("//*[@data-index='1']//div/span/div/div/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h2/a/span"));
        public IWebElement lnkFristSearchResult => Driver.FindElement(By.XPath("//span[@cel_widget_id='MAIN-SEARCH_RESULTS-0']/div"));




    }
}
