using System.Net;

using Moq;

using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Initializations
{
	[Binding]
	public class DnsWrapperInitializations : StepBase
	{
		[Given(@"the DNS Wrapper is configured to return (.*) as the host name")]
		public void ConfigureGetHostName(string returnValue)
		{
			FrameworkMocks.DnsWrapper.Setup(wrapper => wrapper.GetHostName()).Returns(returnValue);
		}

		[Given(@"the DNS Wrapper is configured to return a valid host entry with an address of (.*)")]
		public void ConfigureGetHostEntry(string address)
		{
			FrameworkMocks.DnsWrapper.Setup(wrapper => wrapper.GetHostEntry(It.IsAny<string>())).Returns<string>(host => new IPHostEntry
			{
				HostName = host,
				AddressList = new[] {IPAddress.Parse(address)}
			});
		}
	}
}