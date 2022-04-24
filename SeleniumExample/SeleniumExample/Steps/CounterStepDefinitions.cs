using NUnit.Framework;
using SeleniumExample.Webpage;

namespace SeleniumExample.Steps;

[Binding]
public class CounterStepDefinitions
{
    private readonly DemoWebpage _demoWebpage;

    public CounterStepDefinitions(DemoWebpage demoWebpage)
    {
        _demoWebpage = demoWebpage;
    }

    [Given(@"the user is on the counter webpage")]
    public void GivenTheUserIsOnTheCounterWebpage()
    {
        _demoWebpage.OpenCounterWebpage();
    }
    
    [Given(@"the counter has not been clicked")]
    public void GivenTheCounterHasNotBeenClicked()
    {
        //Do nout.
    }
    
    [When(@"the counter is displayed")]
    public void WhenTheCounterIsDisplayed()
    {
        _demoWebpage.WaitForCounterToRender();
    }
    
    [Then(@"the counter value should be (.*)")]
    public void ThenTheCounterValueShouldBe(int expectedValue)
    {
        var counterValue = _demoWebpage.GetCounterValue();
        Assert.AreEqual(expectedValue.ToString(), counterValue);
    }

    [Given(@"the counter has been clicked")]
    public void GivenTheCounterHasBeenClicked()
    {
        _demoWebpage.ClickCounterButton();
    }
}