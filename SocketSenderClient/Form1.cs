using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace SocketSenderClient
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<Boolean> progress_hmi;

		private Client client;
		private Sequence sequence;
		private Data data;

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
					openToolStripMenuItem.Enabled = !status;
				}
				closeToolStripMenuItem.Enabled = status;
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
			sequence = new Sequence(progress_str, ref client);
			data = new Data(progress_str, ref MessageList);
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
				if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
				{
					IPStr = ipaddress.ToString();
					break;
				}
			}
			return IPStr;
		}

		private void OpenSocketButton_Click(object sender, EventArgs e)
		{
			openToolStripMenuItem.Enabled = false;
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
				openToolStripMenuItem.Enabled = false;
			}
			else
			{
				openToolStripMenuItem.Enabled = true;
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
			if (MsgBox.Text.Length % 2 == 1)
			{
				progress_str.Report("Error: Send data cannot have an odd number of digits");
			}
			else
			{
				progress_str.Report("Sending Msg...");
				client.sendMessage(MsgBox.Text);
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

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openToolStripMenuItem.Enabled = false;
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

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			progress_str.Report("Closing Socket...");

			progress_hmi.Report(false);
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Show the dialog and get result.
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK) // Test result.
			{
				data.Load(openFileDialog1.FileName);
			}
		}

		private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			// Show the dialog and get result.
			DialogResult result = openFileDialog2.ShowDialog();
			if (result == DialogResult.OK) // Test result.
			{
				sequence.Load(openFileDialog2.FileName);
			}
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			sequence.Run();
		}
	}
}
