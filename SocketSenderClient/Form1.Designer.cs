namespace SocketSenderClient
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "NightMode: Off",
            "100600"}, -1);
			System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "NightMode: On",
            "100601"}, -1);
			this.OpenSocketButton = new System.Windows.Forms.Button();
			this.CloseSocketButton = new System.Windows.Forms.Button();
			this.ServerIpBox = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.PortNoBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputLog = new System.Windows.Forms.ListBox();
			this.SendMsgButton = new System.Windows.Forms.Button();
			this.MsgBox = new System.Windows.Forms.TextBox();
			this.MessageList = new System.Windows.Forms.ListView();
			this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.socketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// OpenSocketButton
			// 
			this.OpenSocketButton.Location = new System.Drawing.Point(175, 27);
			this.OpenSocketButton.Name = "OpenSocketButton";
			this.OpenSocketButton.Size = new System.Drawing.Size(75, 46);
			this.OpenSocketButton.TabIndex = 0;
			this.OpenSocketButton.Text = "Open Socket";
			this.OpenSocketButton.UseVisualStyleBackColor = true;
			this.OpenSocketButton.Click += new System.EventHandler(this.OpenSocketButton_Click);
			// 
			// CloseSocketButton
			// 
			this.CloseSocketButton.Enabled = false;
			this.CloseSocketButton.Location = new System.Drawing.Point(256, 27);
			this.CloseSocketButton.Name = "CloseSocketButton";
			this.CloseSocketButton.Size = new System.Drawing.Size(75, 46);
			this.CloseSocketButton.TabIndex = 1;
			this.CloseSocketButton.Text = "Close Socket";
			this.CloseSocketButton.UseVisualStyleBackColor = true;
			this.CloseSocketButton.Click += new System.EventHandler(this.CloseSocketButton_Click);
			// 
			// ServerIpBox
			// 
			this.ServerIpBox.ContextMenuStrip = this.contextMenuStrip1;
			this.ServerIpBox.Location = new System.Drawing.Point(69, 27);
			this.ServerIpBox.Name = "ServerIpBox";
			this.ServerIpBox.Size = new System.Drawing.Size(100, 20);
			this.ServerIpBox.TabIndex = 2;
			this.ServerIpBox.TextChanged += new System.EventHandler(this.ServerIpBox_TextChanged);
			this.ServerIpBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerIpBox_KeyPress);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// PortNoBox
			// 
			this.PortNoBox.ContextMenuStrip = this.contextMenuStrip1;
			this.PortNoBox.Location = new System.Drawing.Point(69, 53);
			this.PortNoBox.Name = "PortNoBox";
			this.PortNoBox.Size = new System.Drawing.Size(100, 20);
			this.PortNoBox.TabIndex = 3;
			this.PortNoBox.TextChanged += new System.EventHandler(this.PortNoBox_TextChanged);
			this.PortNoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortNoBox_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Server IP";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Port No.";
			// 
			// OutputLog
			// 
			this.OutputLog.FormattingEnabled = true;
			this.OutputLog.HorizontalScrollbar = true;
			this.OutputLog.Location = new System.Drawing.Point(12, 81);
			this.OutputLog.Name = "OutputLog";
			this.OutputLog.Size = new System.Drawing.Size(319, 212);
			this.OutputLog.TabIndex = 6;
			// 
			// SendMsgButton
			// 
			this.SendMsgButton.Enabled = false;
			this.SendMsgButton.Location = new System.Drawing.Point(12, 297);
			this.SendMsgButton.Name = "SendMsgButton";
			this.SendMsgButton.Size = new System.Drawing.Size(60, 23);
			this.SendMsgButton.TabIndex = 7;
			this.SendMsgButton.Text = "Send";
			this.SendMsgButton.UseVisualStyleBackColor = true;
			this.SendMsgButton.Click += new System.EventHandler(this.SendMsgButton_Click);
			// 
			// MsgBox
			// 
			this.MsgBox.ContextMenuStrip = this.contextMenuStrip1;
			this.MsgBox.Enabled = false;
			this.MsgBox.Location = new System.Drawing.Point(80, 299);
			this.MsgBox.Name = "MsgBox";
			this.MsgBox.Size = new System.Drawing.Size(253, 20);
			this.MsgBox.TabIndex = 8;
			this.MsgBox.TextChanged += new System.EventHandler(this.MsgBox_TextChanged);
			this.MsgBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MsgBox_KeyPress);
			// 
			// MessageList
			// 
			this.MessageList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
			this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Description,
            this.Data});
			this.MessageList.Enabled = false;
			this.MessageList.FullRowSelect = true;
			this.MessageList.GridLines = true;
			this.MessageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			listViewItem9.Tag = "";
			listViewItem10.Tag = "";
			this.MessageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10});
			this.MessageList.Location = new System.Drawing.Point(339, 27);
			this.MessageList.MultiSelect = false;
			this.MessageList.Name = "MessageList";
			this.MessageList.ShowGroups = false;
			this.MessageList.Size = new System.Drawing.Size(213, 292);
			this.MessageList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.MessageList.TabIndex = 9;
			this.MessageList.UseCompatibleStateImageBehavior = false;
			this.MessageList.View = System.Windows.Forms.View.Details;
			this.MessageList.ItemActivate += new System.EventHandler(this.MessageList_ItemActivate);
			// 
			// Description
			// 
			this.Description.Text = "Description";
			this.Description.Width = 82;
			// 
			// Data
			// 
			this.Data.Text = "Data";
			this.Data.Width = 127;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.socketToolStripMenuItem,
            this.dataToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(564, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// socketToolStripMenuItem
			// 
			this.socketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.socketToolStripMenuItem.Name = "socketToolStripMenuItem";
			this.socketToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.socketToolStripMenuItem.Text = "Socket";
			// 
			// dataToolStripMenuItem
			// 
			this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
			this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
			this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.dataToolStripMenuItem.Text = "Data";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 330);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.MessageList);
			this.Controls.Add(this.MsgBox);
			this.Controls.Add(this.SendMsgButton);
			this.Controls.Add(this.OutputLog);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PortNoBox);
			this.Controls.Add(this.ServerIpBox);
			this.Controls.Add(this.CloseSocketButton);
			this.Controls.Add(this.OpenSocketButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Socket Sender - Client";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OpenSocketButton;
		private System.Windows.Forms.Button CloseSocketButton;
		private System.Windows.Forms.TextBox ServerIpBox;
		private System.Windows.Forms.TextBox PortNoBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox OutputLog;
		private System.Windows.Forms.Button SendMsgButton;
		private System.Windows.Forms.TextBox MsgBox;
		private System.Windows.Forms.ListView MessageList;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ColumnHeader Description;
		private System.Windows.Forms.ColumnHeader Data;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem socketToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

