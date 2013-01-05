using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Initializations
{
	[Binding]
	public class SocketFactoryInitializations : StepBase
	{
		[Given(@"I have a socket factory")]
		public void Create()
		{
			Store((ISocketFactory) new SocketFactory());
		}
	}
}