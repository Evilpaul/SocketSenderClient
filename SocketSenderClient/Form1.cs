using System;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace SocketSenderClient
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<Boolean> progress_hmi;

		private Client client;

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
				if (!status)
				{
					UpdateOpenBtnStatus();
				}
				else
				{
					OpenSocketButton.Enabled = !status;
				}
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

				if (!status)
				{
					client.closeSocket();
				}
			});

			ServerIpBox.Text = GetIP();
			PortNoBox.Text = "5050";

			toolTip1.SetToolTip(MsgBox, "Hex input (e.g. DEADBEEF01)");

			progress_hmi.Report(false);

			client = new Client(progress_str, progress_hmi);
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

			client.openSocket(parseIpAddr(), parsePortNo());
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

		private void UpdateOpenBtnStatus()
		{
			Match matchIp = Regex.Match(ServerIpBox.Text, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
			Match matchPort = Regex.Match(PortNoBox.Text, @"\d");

			if (String.IsNullOrEmpty(ServerIpBox.Text) || String.IsNullOrEmpty(PortNoBox.Text) || !matchIp.Success || !matchPort.Success)
			{
				OpenSocketButton.Enabled = false;
			}
			else
			{
				OpenSocketButton.Enabled = true;
			}
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

			client.sendMessage(MsgBox.Text);
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
			MsgBox.Text = MessageList.SelectedItems[0].SubItems[1].Text;
		}

		private void MsgBox_TextChanged(object sender, EventArgs e)
		{
			UpdateSendBtnStatus();
		}

		private void ServerIpBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Regex.IsMatch(e.KeyChar.ToString(), "^[0-9.\b]+$"))
			{
				e.Handled = true;
			}
		}

		private void ServerIpBox_TextChanged(object sender, EventArgs e)
		{
			UpdateOpenBtnStatus();
		}

		private void PortNoBox_TextChanged(object sender, EventArgs e)
		{
			UpdateOpenBtnStatus();
		}
	}
}
