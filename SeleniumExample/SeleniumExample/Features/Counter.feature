Feature: Counter
	The counter should do some stuff

@browser-test
Scenario: UI: The default value is 0
	Given the user is on the counter webpage
	And the counter has not been clicked
	When the counter is displayed
	Then the counter value should be 0
	
@browser-test
Scenario: UI: The counter button increments when clicked
	Given the user is on the counter webpage
	And the counter has been clicked
	When the counter is displayed
	Then the counter value should be 1
	
@api-test
@smoke-test
Scenario: API: The API returns an increment of the input value
	Given the api is called with a currentNumber of 1
	And the api response should be success with the value of 2