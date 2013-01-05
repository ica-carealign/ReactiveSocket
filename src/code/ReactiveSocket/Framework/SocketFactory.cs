using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ReactiveSocket.Framework
{
	public class SocketFactory : ISocketFactory
	{
		private static readonly IDictionary<ProtocolType, Func<IListenerSocket>> _listenerSocketCreators
			= new Dictionary<ProtocolType, Func<IListenerSocket>>
			{
				{ ProtocolType.Tcp, CreateTcpListenerSocket },
				{ ProtocolType.Udp, CreateUdpListenerSocket }
			};

		private static ListenerSocket CreateUdpListenerSocket()
		{
			return new ListenerSocket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		}

		private static ListenerSocket CreateTcpListenerSocket()
		{
			var listener = new ListenerSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			listener.Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
			return listener;
		}

		public IListenerSocket CreateListenerSocket(ProtocolType protocolType)
		{
			if(!_listenerSocketCreators.ContainsKey(protocolType)) throw new NotSupportedException();

			Func<IListenerSocket> factory = _listenerSocketCreators[protocolType];
			return factory();
		}
	}
}