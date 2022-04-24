Feature: BooleanApi
	Some boolean thingy should do a thing or two.

Scenario: The api should return a success response if the passExpected value is true
	Given the api is called with a passExpected value of true
	Then the api response should be success
	
Scenario: The api should return a bad response if the passExpected value is false
	Given the api is called with a passExpected value of false
	Then the api response should be bad