using System.ComponentModel;
using IxigoFlightProject.Driver;
using IxigoFlightProject.PageObjects;
using IxigoFlightProject.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace IxigoFlightProject.StepDefinitions
{
    [Binding]
    public class FlightBookingSteps
    {
        private IWebDriver driver;
        private FlightBookingPage fbPage;
        private readonly ScenarioContext sc;
        public FlightBookingSteps(ScenarioContext sc)
        {
           driver = DriverFactory.GetDriver();
           fbPage = new FlightBookingPage(driver);
           this.sc = sc;
        }
        [BeforeScenario]
        public static void BeforeScenario()
        {
            ExtentReportHelper.InitializeReport();
            ExtentReportHelper.StartTest("Flight Booking");
        }

        [Given(@"I navigate to ""(.*)""")]
        public void Given_I_Navigate_To(string url)
        {
            fbPage.navigateToUrl(url);
            ExtentReportHelper.LogPass("Navigated to flight booking page");
        }
        [When(@"I select ""(.*)"" as the trip type")]
        public void When_I_Select_Trip_Type(string type)
        {
            fbPage.selectTripType(type);
            ExtentReportHelper.LogPass("Selected the trip type.");
        }
        [When(@"I enter ""(.*)"" as the departure city")]
        public void When_I_Select_Dept_City(string city)
        {
            fbPage.selectDeptCity(city);
            ExtentReportHelper.LogPass("Selected Departure City.");
        }
        [When(@"I enter ""(.*)"" as the destination city")]
        public void When_I_Select_DestCity(string city)
        {
            fbPage.selectDestCity(city);
            ExtentReportHelper.LogPass("Selected Destination city.");
        }
        [When(@"I select ""(.*)"" as the departure date")]
        public void When_I_SelectDate(string date)
        {
            fbPage.selectDate(date);
            ExtentReportHelper.LogPass("Date Selected.");
        }
        [When(@"I click on the Search button")]
        public void I_Click_On_SearchButton()
        {
            fbPage.clickSearch();
            ExtentReportHelper.LogPass("Search Button Clicked.");
        }
        [When(@"I apply the ""(.*)"" filter")]
        public void I_apply_the_filter(string filter)
        {
            fbPage.applyFilter(filter);
            ExtentReportHelper.LogPass("Filter Applied.");
        }
        [When(@"I enter flight details from excel file")]
        public void I_enter_flight_details_from_excel_file()
        {
            fbPage.readDataFromExcel();
            ExtentReportHelper.LogPass("Data is read from Excel file.");
        }
        [Then(@"I should see a list of available flights")]
        public void I_Should_See_Available_Flights()
        {
            fbPage.displayFlight();
            ExtentReportHelper.LogPass("Available flights are displayed.");
        }
        [Then(@"I should see only direct flights")]
        public void I_Should_See_Only_Direct_Flights()
        {
            fbPage.displayFlight();
            ExtentReportHelper.LogPass("Only Direct Flights Displayed.");
        }
        [Then(@"I should be able to select flight")]
        public void I_Should_be_Able_To_Select_Flight()
        {
            fbPage.selectFlight();
            ExtentReportHelper.LogPass("Flight Selected");
        }
        [Then(@"I should see a message stating ""(.*)""")]
        public void I_should_see_a_message_stating(string msg)
        {
            fbPage.checkMessage(msg);
            ExtentReportHelper.LogPass("Message is seen.");
        }
        [Then(@"I should see the results in excel file")]
        public void I_should_see_the_results_in_excel_file()
        {
            fbPage.writeDataToExcel();
            ExtentReportHelper.LogPass("Data written to excel file.");
        }
        [AfterScenario]
        public void AfterScenario()
        {
            if(sc.TestError != null)
            {
                string scenarioName = sc.ScenarioInfo.Title;
                string ss_path = fbPage.capture_screeshot(scenarioName);
                ExtentReportHelper.LogFail($"Scenario Failed: {scenarioName}",ss_path );
            }
            ExtentReportHelper.EndTest();
            DriverFactory.CloseDriver();
        }
    }
}