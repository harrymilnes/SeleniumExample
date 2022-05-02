using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using SeleniumExample.Support.Configuration;
using SeleniumExample.Webpage;

namespace SeleniumExample.Steps;

[Binding]
public class CounterStepDefinitions
{
    private readonly DemoWebpage _demoWebpage;
    private static string ApiResponseScenarioContextKey => "count-api-response";

    private readonly AppSettings _appSettings;
    private readonly ScenarioContext _scenarioContext;
    
    public CounterStepDefinitions(DemoWebpage demoWebpage, IOptions<AppSettings> options, ScenarioContext scenarioContext)
    {
        _demoWebpage = demoWebpage;
        _scenarioContext = scenarioContext;
        _appSettings = options.Value;
    }

    [Given(@"the user is on the counter webpage")]
    public void GivenTheUserIsOnTheCounterWebpage()
    {
        _demoWebpage.OpenCounterWebpage();
    }
    
    [Given(@"the counter has not been clicked")]
    public static void GivenTheCounterHasNotBeenClicked()
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

    private IFlurlRequest CreateCountApiRequest(int currentNumber)
    {
        return _appSettings.CounterApiUrl
            .AppendPathSegment($"/increment/{currentNumber}")
            .AllowAnyHttpStatus();
    }
    
    [Given(@"the api is called with a currentNumber of (.*)")]
    public async Task GivenTheApiIsCalledWithACurrentNumberOf(int currentNumber)
    {
        var apiRequest = CreateCountApiRequest(currentNumber);
        var flurlResponse = await apiRequest.PostAsync();
        _scenarioContext.Set(flurlResponse, ApiResponseScenarioContextKey);
    }

    [Given(@"the api response should be success with the value of (.*)")]
    public async Task GivenTheApiResponseShouldBeSuccessWithTheValueOf(int expectedNumber)
    {
        var apiResponse = _scenarioContext.Get<IFlurlResponse>(ApiResponseScenarioContextKey);
        var content = await apiResponse.ResponseMessage.Content.ReadAsStringAsync();

        Assert.AreEqual(int.Parse(content), expectedNumber);
    }
}