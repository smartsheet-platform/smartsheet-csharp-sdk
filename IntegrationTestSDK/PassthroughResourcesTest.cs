using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Newtonsoft.Json;

namespace IntegrationTestSDK
{
	[TestClass]
	public class PassthroughResourcesTest
	{
		[TestMethod]
		public void TestPassthroughMethods()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();

			string payload =
				"{\"name\": \"my new sheet\"," +
					"\"columns\": [" +
						"{\"title\": \"Favorite\", \"type\": \"CHECKBOX\", \"symbol\": \"STAR\"}," +
						"{\"title\": \"Primary Column\", \"primary\": true, \"type\": \"TEXT_NUMBER\"}" +
					"]" +
				"}";

			string jsonResponse = smartsheet.PassthroughResources.PostRequest("sheets", payload, null);

			long id = 0;
			JsonReader reader = new JsonTextReader(new StringReader(jsonResponse));
			while(id == 0 && reader.Read()) {
				switch (reader.TokenType)
				{
					case JsonToken.StartObject:
						break;
					case JsonToken.PropertyName:
						if(reader.Value.ToString().Contains("message")) 
						{
							string message = reader.ReadAsString();
							Assert.AreEqual(message, "SUCCESS");
						}
						else if(reader.Value.ToString().Contains("id"))
						{
							reader.Read();
							id = (long)reader.Value;
						}
						else
						{
							reader.Read();
						}
						break;
					default:
						reader.Read();
						break;
				}
			}
			Assert.AreNotEqual(id, 0);

			IDictionary<string, string> parameters = new Dictionary<string,string>();
			parameters.Add("include", "objectValue");
			jsonResponse = smartsheet.PassthroughResources.GetRequest("sheets/" + id, parameters);

			string name = null;
			reader = new JsonTextReader(new StringReader(jsonResponse));
			while (name == null && reader.Read())
			{
				switch (reader.TokenType)
				{
					case JsonToken.StartObject:
						break;
					case JsonToken.PropertyName:
						if (reader.Value.ToString().Contains("name"))
						{
							name = reader.ReadAsString();
						}
						else
						{
							reader.Read();
						}
						break;
					default:
						reader.Read();
						break;
				}
			}
			Assert.AreEqual(name, "my new sheet");

			payload = "{\"name\": \"my new new sheet\"}";
			jsonResponse = smartsheet.PassthroughResources.PutRequest("sheets/" + id, payload, null);

			name = null;
			reader = new JsonTextReader(new StringReader(jsonResponse));
			while (name == null && reader.Read())
			{
				switch (reader.TokenType)
				{
					case JsonToken.StartObject:
						break;
					case JsonToken.PropertyName:
						if (reader.Value.ToString().Contains("name"))
						{
							name = reader.ReadAsString();
						}
						else
						{
							reader.Read();
						}
						break;
					default:
						reader.Read();
						break;
				}
			}
			Assert.AreEqual(name, "my new new sheet");

			jsonResponse = smartsheet.PassthroughResources.DeleteRequest("sheets/" + id);

			bool success = false;
			reader = new JsonTextReader(new StringReader(jsonResponse));
			while (!success && reader.Read())
			{
				switch (reader.TokenType)
				{
					case JsonToken.StartObject:
						break;
					case JsonToken.PropertyName:
						if (reader.Value.ToString().Contains("message"))
						{
							string message = reader.ReadAsString();
							Assert.AreEqual(message, "SUCCESS");
							success = true;
						}
						else
						{
							reader.Read();
						}
						break;
					default:
						reader.Read();
						break;
				}
			}
			Assert.IsTrue(success);
		}
	}
}
