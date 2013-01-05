using System;
using System.Diagnostics;
using System.Net.Sockets;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Cleanup
{
	public class ListenerSocketCleanup : StepBase
	{
		[After("allocatesListenerSocket")]
		public void CloseSocket()
		{
			ISocket socket = Retrieve<IListenerSocket>().Socket;

			try
			{
				if (socket.Connected) socket.Shutdown(SocketShutdown.Both);
			}
			catch (Exception error)
			{
				Debug.WriteLine(error.ToString());
			}

			socket.Close();
		}
	}
}