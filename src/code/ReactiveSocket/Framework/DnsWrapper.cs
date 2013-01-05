using System.Net;

namespace ReactiveSocket.Framework
{
	public class DnsWrapper : IDnsWrapper
	{
		public string GetHostName()
		{
			return Dns.GetHostName();
		}

		public IPHostEntry GetHostEntry(string hostNameOrAddress)
		{
			return Dns.GetHostEntry(hostNameOrAddress);
		}
	}
}