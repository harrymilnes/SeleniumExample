using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SeleniumExample.Support.Enums;

namespace SeleniumExample.Support
{
    public static class WebDriverFactory
    {
        private static IWebDriver? _webDriver;

        public static IWebDriver AddWebDriver(WebDriverBrowser webDriverBrowser)
        {
            _webDriver = webDriverBrowser switch
            {
                WebDriverBrowser.Edge => CreateEdgeWebDriver(),
                WebDriverBrowser.Chrome => CreateChromeWebDriver(),
                _ => throw new ArgumentOutOfRangeException($"Browser {webDriverBrowser} not supported")
            };

            return _webDriver;
        }

        private static IWebDriver CreateEdgeWebDriver()
        {
            var edgeOptions = new EdgeOptions
            {
                AcceptInsecureCertificates = true //TODO: AcceptInsecureCertificates - Wouldn't do this with production code.
            };

            var driver = new EdgeDriver(edgeOptions);
            return driver;
        }

        private static IWebDriver CreateChromeWebDriver()
        {
            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true //TODO: AcceptInsecureCertificates - Wouldn't do this with production code.
            };
            
            var driver = new ChromeDriver(chromeOptions);
            return driver;
        }

        public static void DisposeWebDrivers()
        {
            if (_webDriver == null)
                return;
            
            _webDriver.Close();
            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }
}