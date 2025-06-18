using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IxigoFlightProject.Driver
{
    public static class DriverFactory
    {
        private static IWebDriver? driver;
        public static IWebDriver GetDriver()
        {
            if(driver == null)
            {
                //driver = new ChromeDriver();
                ChromeOptions options = new ChromeOptions();
                string profilePath = @"C:\Users\roharish\AppData\Local\Google\Chrome\User Data";
                options.AddArgument("user-data-dir=" + profilePath);
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return driver;
        }

        public static void CloseDriver()
        {
            if(driver!=null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}