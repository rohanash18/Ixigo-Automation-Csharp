using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OfficeOpenXml;
using System.Collections;
namespace IxigoFlightProject.PageObjects
{
    public class FlightBookingPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private string excelfilepath = @"C:\Users\roharish\OneDrive - Capgemini\Desktop\ixigo_input.xlsx";
        //constructor
        

        //locators
        
        [FindsBy(How = How.XPath , Using = "//input[@value='hotelUpsell']")]
        private IWebElement hotelcheck;
        [FindsBy(How = How.XPath , Using = "//p[text()='From']")]
        private IWebElement src_field;
        [FindsBy(How = How.XPath , Using ="//label[text()='From']/following-sibling::input")]
        private IWebElement src_input;
        [FindsBy(How =How.XPath, Using = "//label[text()='To']/following-sibling::input")]
        private IWebElement dest_input;
        [FindsBy(How=How.XPath , Using = "//button[text()='Search']")]
        private IWebElement search_button;
        [FindsBy(How = How.XPath , Using = "//h6[text()='No flights found!']")]
        private IWebElement isFlightShown;
        [FindsBy(How = How.XPath , Using = "//p[text()='Non-Stop']/ancestor::div/following-sibling::span/input")]
        private IWebElement non_stop_check;

        public FlightBookingPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver , TimeSpan.FromSeconds(15));
            PageFactory.InitElements(driver,this);
        }
        //Methods
        public void navigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void selectTripType(string type)
        {
            string type_xpath = "//button[text()='" + type + "']";
            driver.FindElement(By.XPath(type_xpath)).Click();
            hotelcheck.Click();
        }

        public void selectDeptCity(string city)
        {
            src_field.Click();
            src_input.SendKeys(city);
            Thread.Sleep(1500);
            string search_sug_xpath = "//span[contains(normalize-space(text()), '"+city+"')]";
            IWebElement search_result = driver.FindElement(By.XPath(search_sug_xpath));
            search_result.Click();
        }

        public void selectDestCity(string city)
        {
            //dest_input.Click();
            dest_input.SendKeys(city);
            Thread.Sleep(1500);
            //ReadOnlyCollection<IWebElement> search_sug_list = driver.FindElements(By.XPath("//div[@role='listitem']"));
            string search_sug_xpath = "//span[contains(normalize-space(text()), '"+city+"')]";
            IWebElement search_result = driver.FindElement(By.XPath(search_sug_xpath));
            search_result.Click();
        }

        public void selectDate(string date)
        {
            Thread.Sleep(500);
            string input_date = "//abbr[contains(@aria-label,'"+date+"')]";
            driver.FindElement(By.XPath(input_date)).Click();
        }

        public void clickSearch()
        {
            search_button.Click();
        }

        public void displayFlight()
        {
            //wait logic
           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='flex flex-col']")));
            //ReadOnlyCollection<IWebElement> flightName = driver.FindElements(By.XPath("//div[contains(@class, 'airlineInfo')]/div[2]/p[1]"));
            ReadOnlyCollection<IWebElement> flightName = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class, 'airlineInfo')]/div[2]/p[1]")));
            ReadOnlyCollection<IWebElement> flightNo = driver.FindElements(By.XPath("//div[contains(@class, 'airlineInfo')]/div[2]/p[2]"));
            ReadOnlyCollection<IWebElement> flightPrices = driver.FindElements(By.XPath("//h6[@data-testid = 'pricing']"));

            for(int i=0;i<flightName.Count;i++)
            {
               Console.Write(flightName[i].Text);
               System.Diagnostics.Debug.WriteLine(flightName[i].Text);
            //    TestContext.Write(flightName[i].Text);
                Console.Write(flightNo[i].Text);
                System.Diagnostics.Debug.WriteLine(flightNo[i].Text);
                // TestContext.Write(flightNo[i].Text);
                Console.Write(flightPrices[i].Text);
                // TestContext.Write(flightPrices[i].Text);
               Console.WriteLine();
            //    TestContext.WriteLine();
            }

        }
    
        public void selectFlight()
        {
            
           // var a = driver.WindowHandles;
            // ReadOnlyCollection<IWebElement> book_buttons = driver.FindElements(By.XPath("//button[text()='Book']"));
            // book_buttons[0].Click();
            // IWebElement book_button = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Book']")));
            // book_button.Click();
            //driver.FindElement(By.XPath("//button[text()='Book']")).Click();
            IWebElement button = driver.FindElement(By.XPath("//button[text()='Book']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);
        }
        public void checkMessage(string msg)
        {
            if(isFlightShown.Displayed)
            {
                //Console.WriteLine(msg);
                TestContext.WriteLine(msg);
            }
        }
        public void applyFilter(string filter)
        {
            non_stop_check.Click();
        }

        public void readDataFromExcel()
        {
            using var package = new ExcelPackage(new FileInfo(excelfilepath));
            var worksheet = package.Workbook.Worksheets[0];
            string src_city = worksheet.Cells[2, 1].Text;
            selectDeptCity(src_city);
            string dest_city = worksheet.Cells[2, 2].Text;
            selectDestCity(dest_city);
            string date = worksheet.Cells[2, 3].Text;
            selectDate(date);
        }
        
        public void writeDataToExcel()
        {
            using var package = new ExcelPackage(new FileInfo(excelfilepath));
            var worksheet = package.Workbook.Worksheets[0];
            ReadOnlyCollection<IWebElement> flightName = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class, 'airlineInfo')]/div[2]/p[1]")));
            ReadOnlyCollection<IWebElement> flightNo = driver.FindElements(By.XPath("//div[contains(@class, 'airlineInfo')]/div[2]/p[2]"));
            ReadOnlyCollection<IWebElement> flightPrices = driver.FindElements(By.XPath("//h6[@data-testid = 'pricing']"));

            worksheet.Cells[2,4].Value = flightName[0].Text;
            worksheet.Cells[2,5].Value = flightNo[0].Text;
            worksheet.Cells[2,6].Value = flightPrices[0].Text;
            package.Save();
        }
        public string capture_screeshot(string scenarioName)
        {
            string file_dir = "";
            if(driver is ITakesScreenshot sc_driver)
            {
                var screenshot = sc_driver.GetScreenshot();
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string screenshotFileName = $"{scenarioName}_{timestamp}.png";
                string screenshotDirectory = "C://Users//roharish//OneDrive - Capgemini//Desktop//Selenium C#//IxigoFlightProject//Screenshots";
                file_dir = screenshotDirectory + "//" + screenshotFileName;
                screenshot.SaveAsFile(file_dir);
                Console.WriteLine("Screenshot saved!");
            }
            return file_dir;
        }
    }
}