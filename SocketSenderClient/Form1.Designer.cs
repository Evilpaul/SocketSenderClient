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
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.socketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exampleDataXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exampleSequenceXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.socketLabel = new System.Windows.Forms.Label();
			this.sequenceLabel = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
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
			this.MsgBox.Size = new System.Drawing.Size(251, 20);
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
			this.MessageList.Location = new System.Drawing.Point(337, 27);
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
            this.dataToolStripMenuItem,
            this.sequenceToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(560, 24);
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
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
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
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// sequenceToolStripMenuItem
			// 
			this.sequenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.toolStripSeparator1,
            this.runToolStripMenuItem});
			this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
			this.sequenceToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
			this.sequenceToolStripMenuItem.Text = "Sequence";
			// 
			// loadToolStripMenuItem1
			// 
			this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
			this.loadToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
			this.loadToolStripMenuItem1.Text = "Load...";
			this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.runToolStripMenuItem.Text = "Run...";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exampleDataXMLToolStripMenuItem,
            this.exampleSequenceXMLToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// exampleDataXMLToolStripMenuItem
			// 
			this.exampleDataXMLToolStripMenuItem.Name = "exampleDataXMLToolStripMenuItem";
			this.exampleDataXMLToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.exampleDataXMLToolStripMenuItem.Text = "Example Data XML";
			this.exampleDataXMLToolStripMenuItem.Click += new System.EventHandler(this.exampleDataXMLToolStripMenuItem_Click);
			// 
			// exampleSequenceXMLToolStripMenuItem
			// 
			this.exampleSequenceXMLToolStripMenuItem.Name = "exampleSequenceXMLToolStripMenuItem";
			this.exampleSequenceXMLToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.exampleSequenceXMLToolStripMenuItem.Text = "Example Sequence XML";
			this.exampleSequenceXMLToolStripMenuItem.Click += new System.EventHandler(this.exampleSequenceXMLToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "XML file|*.xml|All files|*.*";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.Filter = "XML file|*.xml|All files|*.*";
			// 
			// socketLabel
			// 
			this.socketLabel.AutoSize = true;
			this.socketLabel.Location = new System.Drawing.Point(261, 30);
			this.socketLabel.Name = "socketLabel";
			this.socketLabel.Size = new System.Drawing.Size(70, 13);
			this.socketLabel.TabIndex = 11;
			this.socketLabel.Text = "Socket Open";
			this.socketLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sequenceLabel
			// 
			this.sequenceLabel.AutoSize = true;
			this.sequenceLabel.Location = new System.Drawing.Point(232, 56);
			this.sequenceLabel.Name = "sequenceLabel";
			this.sequenceLabel.Size = new System.Drawing.Size(99, 13);
			this.sequenceLabel.TabIndex = 12;
			this.sequenceLabel.Text = "Sequence Running";
			this.sequenceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 327);
			this.Controls.Add(this.sequenceLabel);
			this.Controls.Add(this.socketLabel);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.MessageList);
			this.Controls.Add(this.MsgBox);
			this.Controls.Add(this.SendMsgButton);
			this.Controls.Add(this.OutputLog);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PortNoBox);
			this.Controls.Add(this.ServerIpBox);
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
		private System.Windows.Forms.ToolStripMenuItem sequenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exampleDataXMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exampleSequenceXMLToolStripMenuItem;
		private System.Windows.Forms.Label socketLabel;
		private System.Windows.Forms.Label sequenceLabel;
	}
}

