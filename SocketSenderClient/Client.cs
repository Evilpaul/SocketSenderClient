using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketSenderClient
{
	class Client
	{
		private IProgress<string> progress_str;
		private IProgress<Boolean> progress_hmi;

		private byte[] m_dataBuffer = new byte[10];
		private IAsyncResult m_result;
		private AsyncCallback m_pfnCallBack;
		private Socket m_clientSocket;

		public Client(IProgress<string> pr_str, IProgress<Boolean> pr_hmi)
		{
			progress_str = pr_str;
			progress_hmi = pr_hmi;
		}

		public void openSocket(IPAddress ip, int iPortNo)
		{
			try
			{
				// Create the socket instance
				m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				m_clientSocket.ReceiveTimeout = 15000;

				if ((ip != null) && (iPortNo >= System.Net.IPEndPoint.MinPort) && (iPortNo <= System.Net.IPEndPoint.MaxPort))
				{
					// Create the end point
					IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);

					// Connect to the remote host
					m_clientSocket.Connect(ipEnd);
					if (m_clientSocket.Connected)
					{
						progress_hmi.Report(true);
						//Wait for data asynchronously
						WaitForData();
					}
					else
					{
						progress_hmi.Report(false);
					}
				}
				else
				{
					progress_hmi.Report(false);
				}
			}
			catch (SocketException se)
			{
				progress_str.Report("Connection failed, is the server running?");
				progress_str.Report(se.Message);
				progress_hmi.Report(false);
			}
		}

		public void sendMessage(string msg)
		{
			try
			{
				Object objData = msg;
				byte[] byData = StringToByteArray(objData.ToString());
				progress_str.Report(msg);
				if (m_clientSocket != null)
				{
					m_clientSocket.Send(byData);
				}
			}
			catch (SocketException se)
			{
				progress_str.Report(se.Message);
			}
		}

		public void closeSocket()
		{
			if (m_clientSocket != null)
			{
				m_clientSocket.Close();
				m_clientSocket = null;
			}
		}

		private static byte[] StringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .ToArray();
		}

		private void OnDataReceived(IAsyncResult asyn)
		{
			try
			{
				SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
				int iRx = theSockId.thisSocket.EndReceive(asyn);
				char[] chars = new char[iRx + 1];
				Decoder d = Encoding.UTF8.GetDecoder();
				int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
				String szData = new String(chars);
				progress_str.Report(szData);
				WaitForData();
			}
			catch (ObjectDisposedException)
			{
				progress_str.Report("OnDataReceived: Socket has been closed");
			}
			catch (SocketException se)
			{
				progress_str.Report(se.Message);
				progress_hmi.Report(false);
			}
		}

		private void WaitForData()
		{
			try
			{
				if (m_pfnCallBack == null)
				{
					m_pfnCallBack = new AsyncCallback(OnDataReceived);
				}
				SocketPacket theSocPkt = new SocketPacket();
				theSocPkt.thisSocket = m_clientSocket;
				// Start listening to the data asynchronously
				m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
														0,
														theSocPkt.dataBuffer.Length,
														SocketFlags.None,
														m_pfnCallBack,
														theSocPkt);
			}
			catch (SocketException se)
			{
				progress_str.Report(se.Message);
			}
		}

		private class SocketPacket
		{
			public Socket thisSocket;
			public byte[] dataBuffer = new byte[1];
		}
	}
}
