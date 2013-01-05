using System;
using System.Net.Sockets;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Actions
{
	public class SocketFactoryActions : StepBase
	{
		[When(@"I ask for a listener socket with the (.*) protocol")]
		public void CreateListenerSocket(string protocol)
		{
			var factory = Retrieve<ISocketFactory>();
			var protocolType = (ProtocolType) Enum.Parse(typeof (ProtocolType), protocol);
			IListenerSocket listenerSocket = factory.CreateListenerSocket(protocolType);
			Store(listenerSocket);
		}
	}
}