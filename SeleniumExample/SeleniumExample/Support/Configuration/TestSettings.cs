using SeleniumExample.Support.Enums;

namespace SeleniumExample.Support.Configuration
{
    public class AppSettings
    {
        public WebDriverBrowser WebDriverBrowser { get; set; }
        public string BooleanApiUrl { get; set; }
        public string DemoCounterUrl { get; set; }
        public string CounterApiUrl { get; set; }
        public bool ScreenshotScenarios { get; set; }
    }
}