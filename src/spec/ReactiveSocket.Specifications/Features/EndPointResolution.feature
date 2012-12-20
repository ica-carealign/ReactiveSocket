Feature: End Point Resolution
	As a ReactiveSocket API consumer
	I want to be able to resolve IP end points
	So that I can be sure to use meaningful end point entries

Scenario: Resolve Local End Point
	Given I have mocked a DNS wrapper
	And the DNS wrapper is configured to return test.battecode.com as the host name
	And the DNS wrapper is configured to return a valid host entry with an address of 127.0.0.1
	And I have an end point resolver using the mocked DNS wrapper
	When I ask the end point resolver for a local end point at port 5000
	Then the DNS wrapper should have been asked for the host name
	And the DNS wrapper should have been asked for a host entry corresponding with the host name test.battecode.com
	And the resolved end point should have an address of 127.0.0.1:5000