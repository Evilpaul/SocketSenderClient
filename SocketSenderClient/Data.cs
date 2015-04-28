using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace SocketSenderClient
{
	class Data
	{
		private IProgress<string> progress_str;
		private ListView MessageList;

		public Data(IProgress<string> pr_str, ref ListView msgList)
		{
			progress_str = pr_str;
			MessageList = msgList;
		}

		public void Load(string filePath)
		{
			// load the XSD (schema) from the assembly's embedded resources and add it to schema set
			Assembly assembly = Assembly.GetExecutingAssembly();
			XmlSchema schema;
			using (StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream("SocketSenderClient.Resources.messages.xsd")))
			{
				schema = XmlSchema.Read(streamReader, null);
			}

			// set the validation settings
			XmlReaderSettings readerSettings = new XmlReaderSettings();
			readerSettings.ValidationType = ValidationType.Schema;
			readerSettings.Schemas = new XmlSchemaSet();
			readerSettings.Schemas.Add(schema);

			ListViewItem lvi;
			string name, value;

			MessageList.Items.Clear();

			// create an XmlReader from the passed XML string. Use the reader settings just created
			try
			{
				XmlReader reader = XmlReader.Create(filePath, readerSettings);
				reader.MoveToContent();

				do
				{
					if ((reader.Name == "message") && (reader.NodeType == XmlNodeType.Element))
					{
						reader.MoveToAttribute("name");
						reader.ReadAttributeValue();
						name = reader.Value.ToString();

						reader.MoveToContent();
						value = reader.ReadContentAsString();

						lvi = new ListViewItem(name);
						lvi.SubItems.Add(value);
						MessageList.Items.Add(lvi);
					}
				} while (reader.Read());

				reader.Close();
			}
			catch (XmlSchemaValidationException ex)
			{
				progress_str.Report("Validation error: " + ex.Message);
			}
		}
	}
}