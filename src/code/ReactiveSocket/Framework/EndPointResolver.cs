using System.Linq;
using System.Net;

namespace ReactiveSocket.Framework
{
    public class EndPointResolver : IEndPointResolver
    {
        private readonly IDnsWrapper _dnsWrapper;

        public EndPointResolver(IDnsWrapper dnsWrapper)
        {
            _dnsWrapper = dnsWrapper;
        }

        public IPEndPoint ResolveLocalEndPoint(int portNumber)
        {
            string hostName = _dnsWrapper.GetHostName();
            IPHostEntry hostEntry = _dnsWrapper.GetHostEntry(hostName);
            IPAddress address = hostEntry.AddressList.FirstOrDefault();
            return address == null ? null : new IPEndPoint(address, portNumber);
        }
    }
}