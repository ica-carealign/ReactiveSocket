Feature: End Point Resolution
	As a ReactiveSocket API consumer
	I want to be able to resolve IP end points
	So that I can be sure to use meaningful end point entries

Scenario: Resolve Local End Point
	And the DNS Wrapper is configured to return anywhere.com as the host name
	And the DNS Wrapper is configured to return a valid host entry with an address of 127.0.0.1
	And I have an End Point Resolver using the mocked DNS Wrapper
	When I ask the End Point Resolver for a local end point at port 5000, using Dns
	Then the DNS wrapper should have been asked for the host name
	And the DNS wrapper should have been asked for a host entry corresponding with the host name anywhere.com
	And the resolved end point should have an address of 127.0.0.1:5000