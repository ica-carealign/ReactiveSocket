Feature: Socket Factory
	As a ReactiveSocket API consumer
	I want to be able to create new Socket instances as easily as possible
	So that I can worry about other things

Scenario Outline: Listener Sockets

	Given I have a socket factory
	When I ask for a listener socket with the <protocol> protocol
	Then the listener socket I got back should have a protocol of <protocol>
	And the listener socket I got back should have an address family of <address family>
	And the listener socket I got back should have a socket type of <socket type>

	Examples: 
	| protocol | address family | socket type |
	| Tcp      | InterNetwork   | Stream      |
	| Udp      | InterNetwork   | Dgram       |

