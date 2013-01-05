using System;

using FluentAssertions;

using Moq;

using ReactiveSocket.Framework;
using ReactiveSocket.Specifications.Properties;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Framework
{
	[Binding]
	public abstract class StepBase : TechTalk.SpecFlow.Steps
	{
		protected internal static TObject Retrieve<TObject>(string key = null, bool createIfMissing = false, Func<TObject> creator = null)
		{
			key = ResolveKey<TObject>(key);

			object value = ScenarioContext.Current.ContainsKey(key) ? ScenarioContext.Current[key] : null;

			if (value == null && createIfMissing)
			{
				creator = creator ?? Create<TObject>;
				value = Store(creator(), key);
			}

			value.Should().NotBeNull(Resources.StepBaseRetrieve_Reason_ValueShouldExist, key)
			     .And.BeAssignableTo<TObject>(Resources.StepBaseRetrieve_Reason_ValueShouldBeExpectedType, key);

			return (TObject) value;
		}

		protected internal static TObject Store<TObject>(TObject value, string key = null)
		{
			ScenarioContext.Current[ResolveKey<TObject>(key)] = value;
			return value;
		}

		private static string ResolveKey<TObject>(string key)
		{
			return string.IsNullOrEmpty(key) ? typeof (TObject).AssemblyQualifiedName : key;
		}

		private static TObject Create<TObject>()
		{
			Type type = typeof (TObject);
			return type.IsValueType ? default(TObject) : (TObject) Activator.CreateInstance(type);
		}

		protected internal class FrameworkMocks
		{
			protected internal static Mock<IDnsWrapper> DnsWrapper
			{
				get { return _dnsWrapper.Value; }
			}

			protected internal static Mock<EndPointResolver> EndPointResolver
			{
				get { return _endPointResolver.Value; }
			}

			protected internal static Mock<IListenerSocket> ListenerSocket
			{
				get { return _listenerSocket.Value; }
			}

			protected internal static Mock<ISocketFactory> SocketFactory
			{
				get { return _socketFactory.Value; }
			}

			protected internal static Mock<ISocket> Socket
			{
				get { return _socket.Value; }
			}

			#region Lazy Creators

			private static readonly Lazy<Mock<IDnsWrapper>> _dnsWrapper = new Lazy<Mock<IDnsWrapper>>(Get<Mock<IDnsWrapper>>);
			private static readonly Lazy<Mock<IListenerSocket>> _listenerSocket = new Lazy<Mock<IListenerSocket>>(Get<Mock<IListenerSocket>>);
			private static readonly Lazy<Mock<ISocketFactory>> _socketFactory = new Lazy<Mock<ISocketFactory>>(Get<Mock<ISocketFactory>>);
			private static readonly Lazy<Mock<ISocket>> _socket = new Lazy<Mock<ISocket>>(Get<Mock<ISocket>>);

			private static readonly Lazy<Mock<EndPointResolver>> _endPointResolver
				= new Lazy<Mock<EndPointResolver>>(() => Retrieve(null, true, () => new Mock<EndPointResolver> {CallBase = true}));

			private static TObject Get<TObject>() where TObject : new()
			{
				return Retrieve(null, true, () => new TObject());
			}

			#endregion
		}
	}
}