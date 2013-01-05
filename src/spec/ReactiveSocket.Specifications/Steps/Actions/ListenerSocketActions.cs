using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps.Actions
{
	[Binding]
	public class ListenerSocketActions : StepBase
	{
		[When(@"I tell the Listener Socket to start listening")]
		public void StartListening()
		{
			Retrieve<IListenerSocket>().StartListening();
		}
	}
}