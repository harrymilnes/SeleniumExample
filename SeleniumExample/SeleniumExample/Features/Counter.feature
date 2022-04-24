Feature: Counter
	The counter should do some stuff

Scenario: The default value is 0
	Given the user is on the counter webpage
	And the counter has not been clicked
	When the counter is displayed
	Then the counter value should be 0
	
Scenario: The counter button increments when clicked
	Given the user is on the counter webpage
	And the counter has been clicked
	When the counter is displayed
	Then the counter value should be 1