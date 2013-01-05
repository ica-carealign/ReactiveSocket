using System.Net;
using System.Net.Sockets;

namespace ReactiveSocket.Framework
{
	public class ListenerSocket : IListenerSocket
	{
		private readonly IEndPointResolver _endPointResolver;

		public ListenerSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
			: this(new SocketWrapper(new Socket(addressFamily, socketType, protocolType)), new EndPointResolver(new DnsWrapper())) {}

		public ListenerSocket(ISocket socket, IEndPointResolver endPointResolver)
		{
			_endPointResolver = endPointResolver;
			Socket = socket;
		}

		public ISocket Socket { get; private set; }

		public void StartListening()
		{
			StartListening(null);
		}

		public void StartListening(IPEndPoint endPoint)
		{
			endPoint = endPoint ?? _endPointResolver.ResolveLocal();
			Socket.Bind(endPoint);
			Socket.Listen(int.MaxValue);
		}
	}
}