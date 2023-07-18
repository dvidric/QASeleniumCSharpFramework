using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using NUnit.Framework;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools.V112.Page;
using QASeleniumCSharpFramework.Configuration;

namespace QASeleniumCSharpFramework.utilities
{
    public class Base
    {

        String browserName;
        public ExtentReports extent;
        public ExtentTest test;

        //report file
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath); 
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Envirenment", "QA");
            extent.AddSystemInfo("Username", "Dragana");



        }

        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //browserName = TestContext.Parameters["browserName"];
            if (browserName == null) 
            {
                browserName = ConfigurationProvider.Configuration["browser"];
            }
            
            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = ConfigurationProvider.Configuration["applicationURL"];
        }

        public IWebDriver getDriver()
        {
            return driver.Value;

        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments(GetBrowserArguments());
                    driver.Value = new FirefoxDriver(firefoxOptions);
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(GetBrowserArguments());
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--window-size=1920,1080");
                    driver.Value = new ChromeDriver(chromeOptions);
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments(GetBrowserArguments());
                    driver.Value = new EdgeDriver(edgeOptions);
                    break;

            }

        }

        public string[] GetBrowserArguments()
        {
            if (ConfigurationProvider.Configuration["browserArguments"] != null)
            {
                return ConfigurationProvider.Configuration["browserArguments"].Split(",");
            }
            return Array.Empty<string>();

        }
        public static jsonReader getDataParser() 
        { 
            return new jsonReader();    
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot" + time.ToString("h_mm_s") + ".png";
            if (status == TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "Test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Failed)
                { }

            extent.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)
        {

            ITakesScreenshot ts = (ITakesScreenshot) driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
}
