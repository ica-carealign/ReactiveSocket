using System.Net;

namespace ReactiveSocket.Framework
{
    public interface IDnsWrapper
    {
        string GetHostName();

        IPHostEntry GetHostEntry(string hostNameOrAddress);
    }
}