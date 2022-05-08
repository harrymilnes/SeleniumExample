using Autofac;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExample.Support;
using SeleniumExample.Support.Configuration;

namespace SeleniumExample.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IComponentContext _componentContext;
        private readonly AppSettings _appSettings;
        private const string ScreenshotDirectoryPath = "./screenshots";

        public Hooks(ScenarioContext scenarioContext, IComponentContext componentContext, IOptions<AppSettings> options)
        {
            _scenarioContext = scenarioContext;
            _componentContext = componentContext;
            _appSettings = options.Value;
        }

        [BeforeTestRun]
        public static void CleanScreenshotDirectory()
        {
            CreateOrDeleteScreenshotsDirectory();
        }

        [AfterScenario]
        public void Screenshot()
        {
            if (!_appSettings.ScreenshotScenarios)
                return;
            
            if (!_scenarioContext.ScenarioInfo.Tags.Contains(Constants.BrowserTestTag)) 
                return;

            SaveScreenshotFromWebDriver();
        }

        private void SaveScreenshotFromWebDriver()
        {
            var webDriver = _componentContext.Resolve<IWebDriver>();
            var screenshot = webDriver.TakeScreenshot();
            var screenshotFileName = DateTime.UtcNow.ToString("dd_MM_yyyy_h_mm_ss");
            screenshot.SaveAsFile($"{ScreenshotDirectoryPath}/{screenshotFileName}.jpg", ScreenshotImageFormat.Jpeg);
        }

        private static void CreateOrDeleteScreenshotsDirectory()
        {
            if (Directory.Exists(ScreenshotDirectoryPath))
            {
                Directory.Delete(ScreenshotDirectoryPath, true);
            }

            Directory.CreateDirectory(ScreenshotDirectoryPath);
        }

        [AfterScenario]
        public static void DisposeWebDrivers()
        {
            WebDriverFactory.DisposeWebDrivers();
        }
    }
}