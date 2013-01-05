using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Actions
{
	[Binding]
	public class EndPointResolverActions : StepBase
	{
		[When(@"I ask the End Point Resolver for a local end point at port (\d+)(, using Dns)?")]
		public void ResolveLocalEndPoint(int portNumber, string useDnsText)
		{
			bool useDns = !string.IsNullOrEmpty(useDnsText);
			Store(Retrieve<IEndPointResolver>().ResolveLocal(portNumber, useDns, true));
		}
	}
}