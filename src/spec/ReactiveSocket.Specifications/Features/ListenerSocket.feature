Feature: Listener Socket
	As a ReactiveSocket API consumer
	I want to be able to use a socket to start listening at a specific IP end point
	So that I can begin accepting incoming requests

# This scenario tests the IListenerSocket.StartListening() method.
# The Listener Socket is wired up with nothing but mocked
# components for its dependencies. This provides a call-pattern test,
# where we assert that the listener socket is utilizing the underlying
# types within System.Net.Sockets appropriately.

# Note: Forcing the socket to listen using the maximum possible backlog value guarantees that
# on Windows Home and Workstation class machines, the actual backlog value used is the
# Operating System max of 5, and on Server class machines, the OS max of 200 is used.
# Source: http://tangentsoft.net/wskfaq/advanced.html#backlog

Scenario: Listen using mocked socket and mocked end point
	Given the mocked End Point Resolver is configured to return an end point with an address of 127.0.0.1
	And I have a Listener Socket using the mocked Socket and mocked End Point Resolver
	When I tell the Listener Socket to start listening
	Then the End Point Resolver should have been asked for an end point at port 0
	And the mocked Socket should have been bound to an end point with an address of 127.0.0.1:0
	And the mocked Socket should have been told to Listen using the maximum possible backlog value

# This scenario also tests the IListenerSocket.StartListening() method.
# The Listener Socket is provided by the default Socket Factory. This means
# that actual network socket allocations will occur as a part of this scenario.

# Note: Using a default port number of zero (shown to occur in the above Scenario) should cause
# the actual port assignment to fall within the range of 49152 to 65535, as recommended by
# the IETF for private and/or dynamic ports.
# Source: http://www.ietf.org/assignments/port-numbers

@allocatesListenerSocket
Scenario: Listen on new TCP port
	Given I have created a real Tcp Listener Socket
	When I tell the Listener Socket to start listening
	Then the Listener Socket should have a port number between 49152 and 65535