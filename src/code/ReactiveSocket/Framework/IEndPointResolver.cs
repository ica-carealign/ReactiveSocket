using System.Net;

namespace ReactiveSocket.Framework
{
    public interface IEndPointResolver
    {
        IPEndPoint ResolveLocalEndPoint(int portNumber);
    }
}