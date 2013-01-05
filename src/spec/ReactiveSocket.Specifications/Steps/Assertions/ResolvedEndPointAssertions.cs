using System.Net;

using FluentAssertions;

using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Assertions
{
	[Binding]
	public class ResolvedEndPointAssertions : StepBase
	{
		[Then(@"the resolved end point should have an address of (.*)")]
		public void AssertResolvedEndPoint(string address)
		{
			var resolvedEndPoint = Retrieve<IPEndPoint>();
			resolvedEndPoint.Should().NotBeNull();
			resolvedEndPoint.ToString().Should().Be(address);
		}
	}
}