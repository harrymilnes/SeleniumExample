using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using SeleniumExample.Support.Configuration;

namespace SeleniumExample.Webpage
{
    public class DemoWebpage : Webpage
    {
        private readonly AppSettings _options;

        public DemoWebpage(IOptions<AppSettings> options)
        {
            _options = options.Value;
        }

        public void WaitForCounterToRender()
        {
            var elementQuery = By.Id("demo-counter");
            WaitForElementVisibility(elementQuery);
        }
        
        public string GetCounterValue()
        {
            var elementQuery = By.Id("demo-counter-value");
            var counterValueElement = WebDriver.FindElement(elementQuery);
            return counterValueElement.Text;
        }

        public void ClickCounterButton()
        {
            var elementQuery = By.Id("demo-button");
            WaitForElementVisibility(elementQuery);
            var buttonElement = WebDriver.FindElement(elementQuery);
            buttonElement.Click();
        }

        public void OpenCounterWebpage()
        {
            WebDriver.Url = _options.DemoCounterUrl;
        }
    }
}