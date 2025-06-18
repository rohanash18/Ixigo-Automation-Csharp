
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace IxigoFlightProject.Helpers
{
    public class ExtentReportHelper
    {
        private static ExtentReports extent;
        private static ExtentTest test;

        public static void InitializeReport()
        {
            var sparkReporter = new ExtentSparkReporter("C://Reports");
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
        }
        public static void StartTest(string testname)
        {
            test = extent.CreateTest(testname);
        }
        public static void LogPass(string msg)
        {
            test.Pass(msg);
        }
        public static void LogFail(string msg, string ss_path)
        {
            test.Fail(msg).AddScreenCaptureFromPath(ss_path);
        }
        public static void EndTest()
        {
            extent.Flush();
        }
        public static ExtentTest GetCurrentTest()
        {
            return test;
        }
    }
}