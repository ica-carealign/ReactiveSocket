using Moq;

using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Verifications
{
	[Binding]
	public class DnsWrapperVerifications : StepBase
	{
		[Then(@"the DNS wrapper should have been asked for the host name")]
		public void VerifyGetHostName()
		{
			FrameworkMocks.DnsWrapper.Verify(wrapper => wrapper.GetHostName(), Times.Once());
		}

		[Then(@"the DNS wrapper should have been asked for a host entry corresponding with the host name (.*)")]
		public void VerifyGetHostEntry(string host)
		{
			FrameworkMocks.DnsWrapper.Verify(wrapper => wrapper.GetHostEntry(host), Times.Once());
		}
	}
}