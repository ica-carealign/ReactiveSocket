using System.Net;

using Moq;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Initializations
{
	[Binding]
	public class EndPointResolverInitializations : StepBase
	{
		[Given(@"I have an End Point Resolver using the mocked DNS Wrapper")]
		public void CreateWithDnsWrapperMock()
		{
			Store((IEndPointResolver) new EndPointResolver(FrameworkMocks.DnsWrapper.Object));
		}

		[Given(@"the mocked End Point Resolver is configured to return an end point with an address of (.*)")]
		public void ConfigureResolveLocalEndPoint(string address)
		{
			FrameworkMocks.EndPointResolver
			              .Setup(resolver => resolver.ResolveLocal(It.IsAny<int>()))
			              .Returns<int>(portNumber => new IPEndPoint(IPAddress.Parse(address), portNumber));
		}
	}
}