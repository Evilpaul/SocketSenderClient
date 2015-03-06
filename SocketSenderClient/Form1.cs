using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SocketSenderClient
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<Boolean> progress_hmi;

		byte[] m_dataBuffer = new byte[10];
		IAsyncResult m_result;
		public AsyncCallback m_pfnCallBack;
		private Socket m_clientSocket;

		public Form1()
		{
			InitializeComponent();

			progress_str = new Progress<string>(status =>
			{
				OutputLog.Items.Add(status);
				OutputLog.TopIndex = OutputLog.Items.Count - 1;
			});

			progress_hmi = new Progress<Boolean>(status =>
			{
				ServerIpBox.Enabled = !status;
				PortNoBox.Enabled = !status;
				OpenSocketButton.Enabled = !status;
				CloseSocketButton.Enabled = status;
				if (status)
				{
					UpdateSendBtnStatus();
				}
				else
				{
					SendMsgButton.Enabled = status;
				}
				MsgBox.Enabled = status;
				MessageList.Enabled = status;

				if ((status == false) && (m_clientSocket != null))
				{
					m_clientSocket.Close();
					m_clientSocket = null;
				}
			});

			ServerIpBox.Text = GetIP();
			PortNoBox.Text = "5050";

			toolTip1.SetToolTip(MsgBox, "Hex input (e.g. DEADBEEF01)");
		}

		private string GetIP()
		{
			String strHostName = Dns.GetHostName();

			// Find host by name
			IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

			// Grab the first IP addresses
			String IPStr = "";
			foreach (IPAddress ipaddress in iphostentry.AddressList)
			{
				IPStr = ipaddress.ToString();
				return IPStr;
			}
			return IPStr;
		}

		public static byte[] StringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .ToArray();
		}

		public void OnDataReceived(IAsyncResult asyn)
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

		public void WaitForData()
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

		public class SocketPacket
		{
			public System.Net.Sockets.Socket thisSocket;
			public byte[] dataBuffer = new byte[1];
		}

		private void OpenSocketButton_Click(object sender, EventArgs e)
		{
			OpenSocketButton.Enabled = false;
			progress_str.Report("Opening Socket...");

			// See if we have text on the IP and Port text fields
			if (ServerIpBox.Text == "" || PortNoBox.Text == "")
			{
				progress_str.Report("IP Address and Port Number are required to connect to the Server");
				progress_hmi.Report(false);
				return;
			}

			try
			{
				// Create the socket instance
				m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				m_clientSocket.ReceiveTimeout = 15000;

				// Cet the remote IP address
				IPAddress ip = parseIpAddr();
				int iPortNo = parsePortNo();

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

		private IPAddress parseIpAddr()
		{
			try
			{
				IPAddress ip = IPAddress.Parse(ServerIpBox.Text);
				return ip;
			}
			catch(Exception e)
			{
				progress_str.Report("ERROR: Could not parse server IP!");
				progress_str.Report(e.ToString());
			}

			return null;
		}

		private int parsePortNo()
		{
			int port = -1;

			try
			{
				port = System.Convert.ToInt16(PortNoBox.Text);
			}
			catch (Exception e)
			{
				progress_str.Report("ERROR: Could not parse port number!");
				progress_str.Report(e.ToString());
			}

			return port;
		}

		private void UpdateSendBtnStatus()
		{
			if(String.IsNullOrEmpty(MsgBox.Text))
			{
				SendMsgButton.Enabled = false;
			}
			else
			{
				SendMsgButton.Enabled = true;
			}
		}

		private void CloseSocketButton_Click(object sender, EventArgs e)
		{
			progress_str.Report("Closing Socket..."); 
			
			progress_hmi.Report(false);
		}

		private void SendMsgButton_Click(object sender, EventArgs e)
		{
			progress_str.Report("Sending Msg...");

			try
			{
				Object objData = MsgBox.Text;
				byte[] byData = StringToByteArray(objData.ToString());
				progress_str.Report(MsgBox.Text);
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

		private void PortNoBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Regex.IsMatch(e.KeyChar.ToString(), "^[0-9\b]+$"))
			{
				e.Handled = true;
			}
		}

		private void MsgBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			
			if (!Regex.IsMatch(e.KeyChar.ToString(), "^[0-9a-fA-F\b]+$"))
			{
				e.Handled = true;
			}
		}

		private void MessageList_ItemActivate(object sender, EventArgs e)
		{
			MsgBox.Text = MessageList.SelectedItems[0].Tag.ToString();
		}

		private void MsgBox_TextChanged(object sender, EventArgs e)
		{
			UpdateSendBtnStatus();
		}
	}
}
