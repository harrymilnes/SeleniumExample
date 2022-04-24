using SeleniumExample.Support;

namespace SeleniumExample.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void CleanScreenshotDirectory()
        {
            //Do some directory stuff.
            //If exists delete
            //Create directory
        }
        
        [AfterScenario]
        public static void DisposeWebDrivers()
        {
            WebDriverFactory.DisposeWebDrivers();
        }
    }
}