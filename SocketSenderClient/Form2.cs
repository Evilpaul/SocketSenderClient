using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketSenderClient
{
	public partial class Form2 : Form
	{
		public Form2(string title, string xml_ref)
		{
			InitializeComponent();
			this.Text = title;
			richTextBox1.Text = xml_ref;
		}
	}
}
