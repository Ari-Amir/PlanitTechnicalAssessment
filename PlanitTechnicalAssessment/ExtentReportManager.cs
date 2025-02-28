using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace PlanitTechnicalAssessment
{
    public static class ExtentReportManager
    {
        private static ExtentReports? _extent;
        private static ExtentSparkReporter? _sparkReporter;
        private static readonly string ReportDirectory = "Reports";
        private static readonly string ReportPath =
            Path.Combine(Environment.GetEnvironmentVariable("REPORT_PATH") ??
            Path.Combine(Directory.GetCurrentDirectory(), "Reports"),
            $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                Directory.CreateDirectory(ReportDirectory);

                _sparkReporter = new ExtentSparkReporter(ReportPath);
                _sparkReporter.Config.Encoding = "UTF-8";
                _sparkReporter.Config.DocumentTitle = "Test Report";
                _sparkReporter.Config.ReportName = "Test Execution Report";
                _sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(_sparkReporter);
            }
            return _extent;
        }
    }
}
