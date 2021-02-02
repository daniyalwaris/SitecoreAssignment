
using OpenQA.Selenium;


namespace SitecoreAssignment.Pages
{
    class HomePage 
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; }

        public IWebElement txtTitlePage => Driver.FindElement(By.XPath("//*[@class='main-title long']"));


        public IWebElement TxtInputSeachTextField => Driver.FindElement(By.XPath("//*[@id='twotabsearchtextbox']"));

        public IWebElement btnSeachSubmit => Driver.FindElement(By.XPath("//*[@id='nav-search-submit-button']"));








    }
}
