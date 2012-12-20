namespace ReactiveSocket.Specifications.Framework
{
    internal class ContextKeys
    {
        private const string _prefix = "ReactiveSocket.Specs.";
        private const string _mocks = _prefix + "Mocks.";
        private const string _targets = _prefix + "Targets.";
        private const string _results = _prefix + "RetrievedResults.";
        internal const string DnsWrapperMock = _mocks + "DnsWrapperMock";
        internal const string EndPointResolver = _targets + "EndPointResolver";
        internal const string ResolvedEndPoint = _results + "ResolvedEndPoint";
    }
}