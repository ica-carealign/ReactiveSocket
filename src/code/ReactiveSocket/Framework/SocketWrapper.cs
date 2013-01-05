using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ReactiveSocket.Framework
{
	#region Interface

	public interface ISocket
	{
		int Available{ get; }
		EndPoint LocalEndPoint{ get; }
		EndPoint RemoteEndPoint{ get; }
		IntPtr Handle{ get; }
		bool Blocking{ get; set; }
		bool UseOnlyOverlappedIO{ get; set; }
		bool Connected{ get; }
		AddressFamily AddressFamily{ get; }
		SocketType SocketType{ get; }
		ProtocolType ProtocolType{ get; }
		bool IsBound{ get; }
		bool ExclusiveAddressUse{ get; set; }
		int ReceiveBufferSize{ get; set; }
		int SendBufferSize{ get; set; }
		int ReceiveTimeout{ get; set; }
		int SendTimeout{ get; set; }
		LingerOption LingerState{ get; set; }
		bool NoDelay{ get; set; }
		short Ttl{ get; set; }
		bool DontFragment{ get; set; }
		bool MulticastLoopback{ get; set; }
		bool EnableBroadcast{ get; set; }
		bool DualMode{ get; set; }

		int IOControl(IOControlCode ioControlCode, byte[] optionInValue, byte[] optionOutValue);
		void SetIPProtectionLevel(IPProtectionLevel level);
		void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue);
		void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue);
		void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue);
		void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue);
		object GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName);
		void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue);
		byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength);
		bool Poll(int microSeconds, SelectMode mode);
		IAsyncResult BeginSendFile(string fileName, AsyncCallback callback, object state);
		IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state);
		SocketInformation DuplicateAndClose(int targetProcessId);
		IAsyncResult BeginConnect(string host, int port, AsyncCallback requestCallback, object state);
		IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback requestCallback, object state);
		IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback requestCallback, object state);
		IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback callback, object state);
		void Disconnect(bool reuseSocket);
		void EndConnect(IAsyncResult asyncResult);
		void EndDisconnect(IAsyncResult asyncResult);
		IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state);
		IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state);
		IAsyncResult BeginSendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags, AsyncCallback callback, object state);
		IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback callback, object state);
		IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state);
		int EndSend(IAsyncResult asyncResult);
		int EndSend(IAsyncResult asyncResult, out SocketError errorCode);
		void EndSendFile(IAsyncResult asyncResult);
		IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP, AsyncCallback callback, object state);
		int EndSendTo(IAsyncResult asyncResult);
		IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state);
		IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state);
		IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback callback, object state);
		IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state);
		int EndReceive(IAsyncResult asyncResult);
		int EndReceive(IAsyncResult asyncResult, out SocketError errorCode);
		IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback callback, object state);
		int EndReceiveMessageFrom(IAsyncResult asyncResult, ref SocketFlags socketFlags, ref EndPoint endPoint, out IPPacketInformation ipPacketInformation);
		IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback callback, object state);
		int EndReceiveFrom(IAsyncResult asyncResult, ref EndPoint endPoint);
		IAsyncResult BeginAccept(AsyncCallback callback, object state);
		IAsyncResult BeginAccept(int receiveSize, AsyncCallback callback, object state);
		IAsyncResult BeginAccept(Socket acceptSocket, int receiveSize, AsyncCallback callback, object state);
		Socket EndAccept(IAsyncResult asyncResult);
		Socket EndAccept(out Byte[] buffer, IAsyncResult asyncResult);
		Socket EndAccept(out Byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult);
		void Shutdown(SocketShutdown how);
		void Dispose();
		bool AcceptAsync(SocketAsyncEventArgs e);
		bool ConnectAsync(SocketAsyncEventArgs e);
		bool DisconnectAsync(SocketAsyncEventArgs e);
		bool ReceiveAsync(SocketAsyncEventArgs e);
		bool ReceiveFromAsync(SocketAsyncEventArgs e);
		bool ReceiveMessageFromAsync(SocketAsyncEventArgs e);
		bool SendAsync(SocketAsyncEventArgs e);
		bool SendPacketsAsync(SocketAsyncEventArgs e);
		bool SendToAsync(SocketAsyncEventArgs e);
		void Bind(EndPoint localEP);
		void Connect(EndPoint remoteEP);
		void Connect(IPAddress address, int port);
		void Connect(string host, int port);
		void Connect(IPAddress[] addresses, int port);
		void Close();
		void Close(int timeout);
		void Listen(int backlog);
		Socket Accept();
		int Send(byte[] buffer, int size, SocketFlags socketFlags);
		int Send(byte[] buffer, SocketFlags socketFlags);
		int Send(byte[] buffer);
		int Send(IList<ArraySegment<byte>> buffers);
		int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);
		int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode);
		void SendFile(string fileName);
		void SendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags);
		int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags);
		int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode);
		int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP);
		int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP);
		int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP);
		int SendTo(byte[] buffer, EndPoint remoteEP);
		int Receive(byte[] buffer, int size, SocketFlags socketFlags);
		int Receive(byte[] buffer, SocketFlags socketFlags);
		int Receive(byte[] buffer);
		int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);
		int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode);
		int Receive(IList<ArraySegment<byte>> buffers);
		int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags);
		int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode);
		int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation);
		int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP);
		int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP);
		int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP);
		int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP);
		int IOControl(int ioControlCode, byte[] optionInValue, byte[] optionOutValue);
	}

	#endregion

	#region Wrapper

	public class SocketWrapper : ISocket
	{
		private readonly Socket _innerType;

		public SocketWrapper(Socket innerType)
		{
			_innerType = innerType;
		}

		public virtual int Available
		{
			get{ return _innerType.Available; }
		}

		public virtual EndPoint LocalEndPoint
		{
			get{ return _innerType.LocalEndPoint; }
		}

		public virtual EndPoint RemoteEndPoint
		{
			get{ return _innerType.RemoteEndPoint; }
		}

		public virtual IntPtr Handle
		{
			get{ return _innerType.Handle; }
		}

		public virtual bool Blocking
		{
			get{ return _innerType.Blocking; }
			set{ _innerType.Blocking = value; }
		}

		public virtual bool UseOnlyOverlappedIO
		{
			get{ return _innerType.UseOnlyOverlappedIO; }
			set{ _innerType.UseOnlyOverlappedIO = value; }
		}

		public virtual bool Connected
		{
			get{ return _innerType.Connected; }
		}

		public virtual AddressFamily AddressFamily
		{
			get{ return _innerType.AddressFamily; }
		}

		public virtual SocketType SocketType
		{
			get{ return _innerType.SocketType; }
		}

		public virtual ProtocolType ProtocolType
		{
			get{ return _innerType.ProtocolType; }
		}

		public virtual bool IsBound
		{
			get{ return _innerType.IsBound; }
		}

		public virtual bool ExclusiveAddressUse
		{
			get{ return _innerType.ExclusiveAddressUse; }
			set{ _innerType.ExclusiveAddressUse = value; }
		}

		public virtual int ReceiveBufferSize
		{
			get{ return _innerType.ReceiveBufferSize; }
			set{ _innerType.ReceiveBufferSize = value; }
		}

		public virtual int SendBufferSize
		{
			get{ return _innerType.SendBufferSize; }
			set{ _innerType.SendBufferSize = value; }
		}

		public virtual int ReceiveTimeout
		{
			get{ return _innerType.ReceiveTimeout; }
			set{ _innerType.ReceiveTimeout = value; }
		}

		public virtual int SendTimeout
		{
			get{ return _innerType.SendTimeout; }
			set{ _innerType.SendTimeout = value; }
		}

		public virtual LingerOption LingerState
		{
			get{ return _innerType.LingerState; }
			set{ _innerType.LingerState = value; }
		}

		public virtual bool NoDelay
		{
			get{ return _innerType.NoDelay; }
			set{ _innerType.NoDelay = value; }
		}

		public virtual short Ttl
		{
			get{ return _innerType.Ttl; }
			set{ _innerType.Ttl = value; }
		}

		public virtual bool DontFragment
		{
			get{ return _innerType.DontFragment; }
			set{ _innerType.DontFragment = value; }
		}

		public virtual bool MulticastLoopback
		{
			get{ return _innerType.MulticastLoopback; }
			set{ _innerType.MulticastLoopback = value; }
		}

		public virtual bool EnableBroadcast
		{
			get{ return _innerType.EnableBroadcast; }
			set{ _innerType.EnableBroadcast = value; }
		}

		public virtual bool DualMode
		{
			get{ return _innerType.DualMode; }
			set{ _innerType.DualMode = value; }
		}

		public virtual int IOControl(IOControlCode ioControlCode, byte[] optionInValue, byte[] optionOutValue)
		{
			return _innerType.IOControl(ioControlCode, optionInValue, optionOutValue);
		}

		public virtual void SetIPProtectionLevel(IPProtectionLevel level)
		{
			_innerType.SetIPProtectionLevel(level);
		}

		public virtual void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
		{
			_innerType.SetSocketOption(optionLevel, optionName, optionValue);
		}

		public virtual void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
		{
			_innerType.SetSocketOption(optionLevel, optionName, optionValue);
		}

		public virtual void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
		{
			_innerType.SetSocketOption(optionLevel, optionName, optionValue);
		}

		public virtual void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue)
		{
			_innerType.SetSocketOption(optionLevel, optionName, optionValue);
		}

		public virtual object GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName)
		{
			return _innerType.GetSocketOption(optionLevel, optionName);
		}

		public virtual void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
		{
			_innerType.GetSocketOption(optionLevel, optionName, optionValue);
		}

		public virtual byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength)
		{
			return _innerType.GetSocketOption(optionLevel, optionName, optionLength);
		}

		public virtual bool Poll(int microSeconds, SelectMode mode)
		{
			return _innerType.Poll(microSeconds, mode);
		}

		public virtual IAsyncResult BeginSendFile(string fileName, AsyncCallback callback, object state)
		{
			return _innerType.BeginSendFile(fileName, callback, state);
		}

		public virtual IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state)
		{
			return _innerType.BeginConnect(remoteEP, callback, state);
		}

		public virtual SocketInformation DuplicateAndClose(int targetProcessId)
		{
			return _innerType.DuplicateAndClose(targetProcessId);
		}

		public virtual IAsyncResult BeginConnect(string host, int port, AsyncCallback requestCallback, object state)
		{
			return _innerType.BeginConnect(host, port, requestCallback, state);
		}

		public virtual IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback requestCallback, object state)
		{
			return _innerType.BeginConnect(address, port, requestCallback, state);
		}

		public virtual IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback requestCallback, object state)
		{
			return _innerType.BeginConnect(addresses, port, requestCallback, state);
		}

		public virtual IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback callback, object state)
		{
			return _innerType.BeginDisconnect(reuseSocket, callback, state);
		}

		public virtual void Disconnect(bool reuseSocket)
		{
			_innerType.Disconnect(reuseSocket);
		}

		public virtual void EndConnect(IAsyncResult asyncResult)
		{
			_innerType.EndConnect(asyncResult);
		}

		public virtual void EndDisconnect(IAsyncResult asyncResult)
		{
			_innerType.EndDisconnect(asyncResult);
		}

		public virtual IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
		{
			return _innerType.BeginSend(buffer, offset, size, socketFlags, callback, state);
		}

		public virtual IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
		{
			return _innerType.BeginSend(buffer, offset, size, socketFlags, out errorCode, callback, state);
		}

		public virtual IAsyncResult BeginSendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags, AsyncCallback callback, object state)
		{
			return _innerType.BeginSendFile(fileName, preBuffer, postBuffer, flags, callback, state);
		}

		public virtual IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback callback, object state)
		{
			return _innerType.BeginSend(buffers, socketFlags, callback, state);
		}

		public virtual IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
		{
			return _innerType.BeginSend(buffers, socketFlags, out errorCode, callback, state);
		}

		public virtual int EndSend(IAsyncResult asyncResult)
		{
			return _innerType.EndSend(asyncResult);
		}

		public virtual int EndSend(IAsyncResult asyncResult, out SocketError errorCode)
		{
			return _innerType.EndSend(asyncResult, out errorCode);
		}

		public virtual void EndSendFile(IAsyncResult asyncResult)
		{
			_innerType.EndSendFile(asyncResult);
		}

		public virtual IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP, AsyncCallback callback, object state)
		{
			return _innerType.BeginSendTo(buffer, offset, size, socketFlags, remoteEP, callback, state);
		}

		public virtual int EndSendTo(IAsyncResult asyncResult)
		{
			return _innerType.EndSendTo(asyncResult);
		}

		public virtual IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
		{
			return _innerType.BeginReceive(buffer, offset, size, socketFlags, callback, state);
		}

		public virtual IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
		{
			return _innerType.BeginReceive(buffer, offset, size, socketFlags, out errorCode, callback, state);
		}

		public virtual IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback callback, object state)
		{
			return _innerType.BeginReceive(buffers, socketFlags, callback, state);
		}

		public virtual IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
		{
			return _innerType.BeginReceive(buffers, socketFlags, out errorCode, callback, state);
		}

		public virtual int EndReceive(IAsyncResult asyncResult)
		{
			return _innerType.EndReceive(asyncResult);
		}

		public virtual int EndReceive(IAsyncResult asyncResult, out SocketError errorCode)
		{
			return _innerType.EndReceive(asyncResult, out errorCode);
		}

		public virtual IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback callback, object state)
		{
			return _innerType.BeginReceiveMessageFrom(buffer, offset, size, socketFlags, ref remoteEP, callback, state);
		}

		public virtual int EndReceiveMessageFrom(IAsyncResult asyncResult, ref SocketFlags socketFlags, ref EndPoint endPoint, out IPPacketInformation ipPacketInformation)
		{
			return _innerType.EndReceiveMessageFrom(asyncResult, ref socketFlags, ref endPoint, out ipPacketInformation);
		}

		public virtual IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback callback, object state)
		{
			return _innerType.BeginReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP, callback, state);
		}

		public virtual int EndReceiveFrom(IAsyncResult asyncResult, ref EndPoint endPoint)
		{
			return _innerType.EndReceiveFrom(asyncResult, ref endPoint);
		}

		public virtual IAsyncResult BeginAccept(AsyncCallback callback, object state)
		{
			return _innerType.BeginAccept(callback, state);
		}

		public virtual IAsyncResult BeginAccept(int receiveSize, AsyncCallback callback, object state)
		{
			return _innerType.BeginAccept(receiveSize, callback, state);
		}

		public virtual IAsyncResult BeginAccept(Socket acceptSocket, int receiveSize, AsyncCallback callback, object state)
		{
			return _innerType.BeginAccept(acceptSocket, receiveSize, callback, state);
		}

		public virtual Socket EndAccept(IAsyncResult asyncResult)
		{
			return _innerType.EndAccept(asyncResult);
		}

		public virtual Socket EndAccept(out Byte[] buffer, IAsyncResult asyncResult)
		{
			return _innerType.EndAccept(out buffer, asyncResult);
		}

		public virtual Socket EndAccept(out Byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult)
		{
			return _innerType.EndAccept(out buffer, out bytesTransferred, asyncResult);
		}

		public virtual void Shutdown(SocketShutdown how)
		{
			_innerType.Shutdown(how);
		}

		public virtual void Dispose()
		{
			_innerType.Dispose();
		}

		public virtual bool AcceptAsync(SocketAsyncEventArgs e)
		{
			return _innerType.AcceptAsync(e);
		}

		public virtual bool ConnectAsync(SocketAsyncEventArgs e)
		{
			return _innerType.ConnectAsync(e);
		}

		public virtual bool DisconnectAsync(SocketAsyncEventArgs e)
		{
			return _innerType.DisconnectAsync(e);
		}

		public virtual bool ReceiveAsync(SocketAsyncEventArgs e)
		{
			return _innerType.ReceiveAsync(e);
		}

		public virtual bool ReceiveFromAsync(SocketAsyncEventArgs e)
		{
			return _innerType.ReceiveFromAsync(e);
		}

		public virtual bool ReceiveMessageFromAsync(SocketAsyncEventArgs e)
		{
			return _innerType.ReceiveMessageFromAsync(e);
		}

		public virtual bool SendAsync(SocketAsyncEventArgs e)
		{
			return _innerType.SendAsync(e);
		}

		public virtual bool SendPacketsAsync(SocketAsyncEventArgs e)
		{
			return _innerType.SendPacketsAsync(e);
		}

		public virtual bool SendToAsync(SocketAsyncEventArgs e)
		{
			return _innerType.SendToAsync(e);
		}

		public virtual void Bind(EndPoint localEP)
		{
			_innerType.Bind(localEP);
		}

		public virtual void Connect(EndPoint remoteEP)
		{
			_innerType.Connect(remoteEP);
		}

		public virtual void Connect(IPAddress address, int port)
		{
			_innerType.Connect(address, port);
		}

		public virtual void Connect(string host, int port)
		{
			_innerType.Connect(host, port);
		}

		public virtual void Connect(IPAddress[] addresses, int port)
		{
			_innerType.Connect(addresses, port);
		}

		public virtual void Close()
		{
			_innerType.Close();
		}

		public virtual void Close(int timeout)
		{
			_innerType.Close(timeout);
		}

		public virtual void Listen(int backlog)
		{
			_innerType.Listen(backlog);
		}

		public virtual Socket Accept()
		{
			return _innerType.Accept();
		}

		public virtual int Send(byte[] buffer, int size, SocketFlags socketFlags)
		{
			return _innerType.Send(buffer, size, socketFlags);
		}

		public virtual int Send(byte[] buffer, SocketFlags socketFlags)
		{
			return _innerType.Send(buffer, socketFlags);
		}

		public virtual int Send(byte[] buffer)
		{
			return _innerType.Send(buffer);
		}

		public virtual int Send(IList<ArraySegment<byte>> buffers)
		{
			return _innerType.Send(buffers);
		}

		public virtual int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
		{
			return _innerType.Send(buffers, socketFlags);
		}

		public virtual int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
		{
			return _innerType.Send(buffers, socketFlags, out errorCode);
		}

		public virtual void SendFile(string fileName)
		{
			_innerType.SendFile(fileName);
		}

		public virtual void SendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags)
		{
			_innerType.SendFile(fileName, preBuffer, postBuffer, flags);
		}

		public virtual int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
		{
			return _innerType.Send(buffer, offset, size, socketFlags);
		}

		public virtual int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
		{
			return _innerType.Send(buffer, offset, size, socketFlags, out errorCode);
		}

		public virtual int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP)
		{
			return _innerType.SendTo(buffer, offset, size, socketFlags, remoteEP);
		}

		public virtual int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP)
		{
			return _innerType.SendTo(buffer, size, socketFlags, remoteEP);
		}

		public virtual int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP)
		{
			return _innerType.SendTo(buffer, socketFlags, remoteEP);
		}

		public virtual int SendTo(byte[] buffer, EndPoint remoteEP)
		{
			return _innerType.SendTo(buffer, remoteEP);
		}

		public virtual int Receive(byte[] buffer, int size, SocketFlags socketFlags)
		{
			return _innerType.Receive(buffer, size, socketFlags);
		}

		public virtual int Receive(byte[] buffer, SocketFlags socketFlags)
		{
			return _innerType.Receive(buffer, socketFlags);
		}

		public virtual int Receive(byte[] buffer)
		{
			return _innerType.Receive(buffer);
		}

		public virtual int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags)
		{
			return _innerType.Receive(buffer, offset, size, socketFlags);
		}

		public virtual int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
		{
			return _innerType.Receive(buffer, offset, size, socketFlags, out errorCode);
		}

		public virtual int Receive(IList<ArraySegment<byte>> buffers)
		{
			return _innerType.Receive(buffers);
		}

		public virtual int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
		{
			return _innerType.Receive(buffers, socketFlags);
		}

		public virtual int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
		{
			return _innerType.Receive(buffers, socketFlags, out errorCode);
		}

		public virtual int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation)
		{
			return _innerType.ReceiveMessageFrom(buffer, offset, size, ref socketFlags, ref remoteEP, out ipPacketInformation);
		}

		public virtual int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
		{
			return _innerType.ReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP);
		}

		public virtual int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
		{
			return _innerType.ReceiveFrom(buffer, size, socketFlags, ref remoteEP);
		}

		public virtual int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP)
		{
			return _innerType.ReceiveFrom(buffer, socketFlags, ref remoteEP);
		}

		public virtual int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP)
		{
			return _innerType.ReceiveFrom(buffer, ref remoteEP);
		}

		public virtual int IOControl(int ioControlCode, byte[] optionInValue, byte[] optionOutValue)
		{
			return _innerType.IOControl(ioControlCode, optionInValue, optionOutValue);
		}

	}

	#endregion
}