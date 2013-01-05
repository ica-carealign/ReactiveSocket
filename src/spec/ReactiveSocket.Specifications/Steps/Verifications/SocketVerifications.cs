using System.Net;

using Moq;

using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Verifications
{
	[Binding]
	public class SocketVerifications : StepBase
	{
		[Then(@"the mocked Socket should have been bound to an end point with an address of (.*)")]
		public void VerifyBind(string address)
		{
			FrameworkMocks.Socket.Verify(socket => socket.Bind(It.Is<IPEndPoint>(point => point.ToString() == address)));
		}

		[Then(@"the mocked Socket should have been told to Listen using the maximum possible backlog value")]
		public void VerifyListen()
		{
			FrameworkMocks.Socket.Verify(socket => socket.Listen(It.Is<int>(backLog => backLog == int.MaxValue)));
		}
	}
}