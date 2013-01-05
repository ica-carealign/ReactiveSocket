using System.Net;

namespace ReactiveSocket.Framework
{
	public interface IListenerSocket
	{
		ISocket Socket { get; }

		void StartListening();

		void StartListening(IPEndPoint endPoint);
	}
}