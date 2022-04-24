using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample.Webpage
{
    public abstract class Webpage
    {
        public IWebDriver WebDriver = null!;

        private DefaultWait<IWebDriver> CreateFluentWait()
        {
            var fluentWait = new DefaultWait<IWebDriver>(WebDriver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Failed to find elements";

            return fluentWait;
        }

        protected void WaitForElementVisibility(By findElementQuery)
        {
            var fluentWait = CreateFluentWait();
            fluentWait.Until(x => x.FindElements(findElementQuery));
        }
    }
}