using System.Net.Sockets;

namespace ReactiveSocket.Framework
{
	public interface ISocketFactory
	{
		IListenerSocket CreateListenerSocket(ProtocolType protocolType);
	}
}