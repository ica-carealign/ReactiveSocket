using System;
using System.Net.Sockets;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Initializations
{
	[Binding]
	public class ListenerSocketInitializations : StepBase
	{
		[Given(@"I have a Listener Socket using the mocked Socket and mocked End Point Resolver")]
		public void CreateWithMockedDependencies()
		{
			Store((IListenerSocket) new ListenerSocket(FrameworkMocks.Socket.Object, FrameworkMocks.EndPointResolver.Object));
		}

		[Given(@"I have created a real (.*) Listener Socket")]
		public void Create(string protocol)
		{
			var protocolType = (ProtocolType)Enum.Parse(typeof(ProtocolType), protocol);
			var factory = new ReactiveSocket.Framework.SocketFactory();
			Store(factory.CreateListenerSocket(protocolType));
		}
	}
}