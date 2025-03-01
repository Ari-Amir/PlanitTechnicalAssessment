using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace PlanitTechnicalAssessment
{     
    public static class ExtentReportManager                               //Configures and manages a single ExtentReports instance for testLogger logging.
    {                
        private static readonly Lazy<ExtentReports> _extent 
            = new Lazy<ExtentReports>(() =>                               //Uses Lazy<T> to create ExtentReports only once, when first accessed.
        {            
            
            string reportPath = Path.Combine(                             //Builds the full path for the report file.
                Environment.GetEnvironmentVariable("REPORT_PATH") ??      //Checks environment variable REPORT_PATH
                Path.Combine(Directory.GetCurrentDirectory(), "Reports"), //Falls back to "Reports" folder in current directory
                $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");       //Adds timestamp to filename

            string directory = Path.GetDirectoryName(reportPath);         //Extracts the directory part from reportPath and prevents errors when saving the report file.


            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var sparkReporter = new ExtentSparkReporter(reportPath);       //Sets up the HTML reporter with the reportPath. This will generate the actual report file.
            sparkReporter.Config.Encoding = "UTF-8";                       //Encoding: UTF-8 for proper character support.
            sparkReporter.Config.DocumentTitle = "Test Report";            //DocumentTitle: "Test Report" as the browser tab title.
            sparkReporter.Config.ReportName = "Test Execution Report";     //ReportName: "Test Execution Report" as the report header.
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;


            var extent = new ExtentReports();                              //Creates a new ExtentReports instance for logging testLogger results.
            extent.AttachReporter(sparkReporter);                          //Attaches the sparkReporter to the reports instance and links the HTML reporter to the logging system.

            return extent;                                                 //Returns the configured reports object which Lazy<T> will store and reuse.
        });

        public static ExtentReports GetInstance()                          //Returns the configured ExtentReports object when called.
        {
            return _extent.Value; 
        }
    }
}
