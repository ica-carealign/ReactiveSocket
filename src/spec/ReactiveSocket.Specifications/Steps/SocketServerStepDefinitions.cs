using System.Net;

using FluentAssertions;

using Moq;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Framework;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Steps
{
    [Binding]
    public class SocketServerStepDefinitions : StepBase
    {
        [Given(@"I have mocked a DNS wrapper")]
        public void CreateDnsWrapperMock()
        {
            Store(new Mock<IDnsWrapper>(), ContextKeys.DnsWrapperMock);
        }

        [Given(@"the DNS wrapper is configured to return (.*) as the host name")]
        public void ConfigureDnsWrapperMockGetHostName(string returnValue)
        {
            var mock = Retrieve<Mock<IDnsWrapper>>(ContextKeys.DnsWrapperMock);
            mock.Setup(wrapper => wrapper.GetHostName()).Returns(returnValue);
        }

        [Given(@"the DNS wrapper is configured to return a valid host entry with an address of (.*)")]
        public void ConfigureDnsWrapperMockGetHostEntry(string address)
        {
            var mock = Retrieve<Mock<IDnsWrapper>>(ContextKeys.DnsWrapperMock);
            mock.Setup(wrapper => wrapper.GetHostEntry(It.IsAny<string>())).Returns<string>(host => new IPHostEntry
            {
                HostName = host,
                AddressList = new[] {IPAddress.Parse(address)}
            });
        }

        [Given(@"I have an end point resolver using the mocked DNS wrapper")]
        public void CreateEndPointResolverWithDnsWrapperMock()
        {
            IEndPointResolver resolver = new EndPointResolver(Retrieve<Mock<IDnsWrapper>>(ContextKeys.DnsWrapperMock).Object);
            Store(resolver, ContextKeys.EndPointResolver);
        }

        [When(@"I ask the end point resolver for a local end point at port (.*)")]
        public void ResolveLocalEndPoint(int portNumber)
        {
            var resolver = Retrieve<IEndPointResolver>(ContextKeys.EndPointResolver);
            Store(resolver.ResolveLocalEndPoint(portNumber), ContextKeys.ResolvedEndPoint);
        }

        [Then(@"the DNS wrapper should have been asked for the host name")]
        public void VerifyDnsWrapperMockGetHostName()
        {
            Retrieve<Mock<IDnsWrapper>>(ContextKeys.DnsWrapperMock).Verify(wrapper => wrapper.GetHostName(), Times.Once());
        }

        [Then(@"the DNS wrapper should have been asked for a host entry corresponding with the host name (.*)")]
        public void VerifyDnsWrapperMockGetHostEntry(string host)
        {
            Retrieve<Mock<IDnsWrapper>>(ContextKeys.DnsWrapperMock).Verify(wrapper => wrapper.GetHostEntry(host), Times.Once());
        }

        [Then(@"the resolved end point should have an address of (.*)")]
        public void AssertResolvedEndPoint(string address)
        {
            var resolvedEndPoint = Retrieve<IPEndPoint>(ContextKeys.ResolvedEndPoint);
            resolvedEndPoint.Should().NotBeNull();
            resolvedEndPoint.ToString().Should().Be(address);
        }
    }
}