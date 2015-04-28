﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace SocketSenderClient
{
	class Sequence
	{
		private IProgress<string> progress_str;
		private Client client;
		private bool is_file_loaded = false;
		private bool read_result = false;

		private List<node> list = new List<node>();

		public Sequence(IProgress<string> pr_str, ref Client cl)
		{
			progress_str = pr_str;
			client = cl;
			is_file_loaded = false;
		}

		public bool isLoaded()
		{
			return is_file_loaded;
		}

		public async void Run()
		{
			await do_async();
		}

		private Task do_async()
		{
			return Task.Run(() =>
			{
				if (!is_file_loaded)
				{
					progress_str.Report("ERROR: No sequence loaded!");
					return;
				}

				foreach (node n in list)
				{
					if (!client.isSocketOpen())
						break;

					if (n.getType() == node.NodeType.Delay)
					{
						progress_str.Report("Sleeping for " + n.getDelay() + " milliseconds");
						Thread.Sleep(n.getDelay());
					}
					else
					{
						client.sendMessage(n.getValue());
					}
				}
			});
		}

		public void Load(string filePath)
		{
			read_result = true;

			// load the XSD (schema) from the assembly's embedded resources and add it to schema set
			Assembly assembly = Assembly.GetExecutingAssembly();
			XmlSchema schema;
			using (StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream("SocketSenderClient.Resources.sequence.xsd")))
			{
				schema = XmlSchema.Read(streamReader, SchemaValidationCallback);
			}

			// set the validation settings
			XmlReaderSettings readerSettings = new XmlReaderSettings();
			readerSettings.ValidationType = ValidationType.Schema;
			readerSettings.Schemas = new XmlSchemaSet();
			readerSettings.Schemas.Add(schema);
			readerSettings.ValidationEventHandler += new ValidationEventHandler(DocumentValidationCallback);

			// create an XmlReader from the passed XML string. Use the reader settings just created
			using (XmlReader reader = XmlReader.Create(filePath, readerSettings))
			{
				reader.MoveToContent();

				list.Clear();

				do
				{
					if ((reader.Name == "message") && (reader.NodeType == XmlNodeType.Element))
					{
						reader.MoveToAttribute("name");
						reader.ReadAttributeValue();
						string name = reader.Value.ToString();

						reader.MoveToElement();
						list.Add(new node(reader.ReadElementContentAsString()));
					}
					else if ((reader.Name == "delay") && (reader.NodeType == XmlNodeType.Element))
					{
						reader.MoveToElement();
						list.Add(new node(reader.ReadElementContentAsInt()));
					}
				} while (reader.Read());

				reader.Close();
				is_file_loaded = read_result;
			}
		}

		private void SchemaValidationCallback(object sender, ValidationEventArgs args)
		{
			read_result = false;

			progress_str.Report("Schema error: " + args.Message);
		}

		private void DocumentValidationCallback(object sender, ValidationEventArgs args)
		{
			read_result = false;

			if (args.Severity == XmlSeverityType.Warning)
				progress_str.Report("Warning: Matching schema not found.  No validation occurred." + args.Message);
			else
				progress_str.Report("Validation error: " + args.Message);
		}
	}
}