using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ReactiveSocket.Framework
{
	public class EndPointResolver : IEndPointResolver
	{
		private readonly IDnsWrapper _dnsWrapper;

		public EndPointResolver() : this(new DnsWrapper()) {}

		public EndPointResolver(IDnsWrapper dnsWrapper)
		{
			_dnsWrapper = dnsWrapper;
		}
		public virtual IPEndPoint ResolveLocal()
		{
			return ResolveLocal(0);
		}

		public virtual IPEndPoint ResolveLocal(int portNumber)
		{
			return ResolveLocal(portNumber, false);
		}

		public virtual IPEndPoint ResolveLocal(int portNumber, bool useDns)
		{
			return ResolveLocal(portNumber, useDns, true);
		}

		public virtual IPEndPoint ResolveLocal(int portNumber, bool useDns, bool useIpV4)
		{
			var address = useDns ? GetDnsAddress(useIpV4) : IPAddress.Any;
			return new IPEndPoint(address, portNumber);
		}

		private IPAddress GetDnsAddress(bool useIpV4)
		{
			string hostName = _dnsWrapper.GetHostName();
			IPHostEntry hostEntry = _dnsWrapper.GetHostEntry(hostName);
			IEnumerable<IPAddress> addressList = hostEntry.AddressList;
			if (useIpV4) addressList = addressList.Where(ipAddress => ipAddress.AddressFamily == AddressFamily.InterNetwork);
			IPAddress address = addressList.FirstOrDefault();
			return address;
		}
	}
}