using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Verifications
{
	[Binding]
	public class EndPointResolverVerifications : StepBase
	{
		[Then(@"the End Point Resolver should have been asked for an end point at port (.*)")]
		public void VerifyResolveLocal(int portNumber)
		{
			FrameworkMocks.EndPointResolver.Verify(resolver => resolver.ResolveLocal(portNumber));
		}
	}
}