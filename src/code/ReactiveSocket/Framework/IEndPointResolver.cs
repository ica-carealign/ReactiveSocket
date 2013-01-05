using System.Net;

namespace ReactiveSocket.Framework
{
	public interface IEndPointResolver
	{
		IPEndPoint ResolveLocal();

		IPEndPoint ResolveLocal(int portNumber);

		IPEndPoint ResolveLocal(int portNumber, bool useDns);

		IPEndPoint ResolveLocal(int portNumber, bool useDns, bool useIpV4);
	}
}