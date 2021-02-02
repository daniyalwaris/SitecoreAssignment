using OpenQA.Selenium;


namespace SitecoreAssignment.Config
{
    class Controls : DriverHelper
    {

        public static void EnterText(IWebElement webelement, string value) => webelement.SendKeys(value);

        public static void Click(IWebElement webElement) => webElement.Click();

        public static string getText(IWebElement webElement) => webElement.GetAttribute("value");

       
   
        public static void waitOnPage(int sec) => System.Threading.Thread.Sleep(sec * 1000);

    }
}
