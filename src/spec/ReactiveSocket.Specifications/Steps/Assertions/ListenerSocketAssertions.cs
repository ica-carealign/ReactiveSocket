using System;
using System.Net;
using System.Net.Sockets;

using FluentAssertions;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Assertions
{
	[Binding]
	public class ListenerSocketAssertions : StepBase
	{
		[Then(@"the listener socket I got back should have a protocol of (.*)")]
		public void ProtocolType(string protocol)
		{
			var protocolType = (ProtocolType)Enum.Parse(typeof(ProtocolType), protocol);
			var listenerSocket = Retrieve<IListenerSocket>();
			listenerSocket.Socket.ProtocolType.Should().Be(protocolType);
		}

		[Then(@"the listener socket I got back should have an address family of (.*)")]
		public void AddressFamily(string family)
		{
			var addressFamily = (AddressFamily)Enum.Parse(typeof(AddressFamily), family);
			var listenerSocket = Retrieve<IListenerSocket>();
			listenerSocket.Socket.AddressFamily.Should().Be(addressFamily);
		}

		[Then(@"the listener socket I got back should have a socket type of (.*)")]
		public void SocketType(string type)
		{
			var socketType = (SocketType)Enum.Parse(typeof(SocketType), type);
			var listenerSocket = Retrieve<IListenerSocket>();
			listenerSocket.Socket.SocketType.Should().Be(socketType);
		}

		[Then(@"the Listener Socket should have a port number between (.*) and (.*)")]
		public void PortNumber(int min, int max)
		{
			var listenerSocket = Retrieve<IListenerSocket>();
			var endPoint = listenerSocket.Socket.LocalEndPoint as IPEndPoint;
			endPoint.Should().NotBeNull();
			endPoint.Port.Should().BeInRange(min, max);
			ScenarioContext.Current.WriteDebug("Assigned port number was {0}", endPoint.Port);
		}
	}
}