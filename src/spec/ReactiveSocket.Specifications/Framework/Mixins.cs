using System.Diagnostics;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Framework
{
	public static class Mixins
	{
		private const string _prefix = "-> debug: ";

		public static void WriteDebug(this ScenarioContext context, string format, params object[] args)
		{
			Debug.WriteLine(_prefix + format, args);
		}
	}
}