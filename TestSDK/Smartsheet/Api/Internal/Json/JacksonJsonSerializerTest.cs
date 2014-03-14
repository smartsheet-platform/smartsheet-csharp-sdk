using System;
using System.Collections;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal.Json
{
	using NUnit.Framework;





	using JsonParseException = fasterxml.jackson.core.JsonParseException;
	using JsonMappingException = fasterxml.jackson.databind.JsonMappingException;
	using Folder = Smartsheet.Api.Models.Folder;
	using Result = Smartsheet.Api.Models.Result;
	using User = Smartsheet.Api.Models.User;

	public class JacksonJsonSerializerTest
	{
		internal JsonNetSerializer jjs;

		[SetUp]
		public virtual void SetUp()
		{
			jjs = new JsonNetSerializer();
		}

		[Test]
		public virtual void TestJacksonJsonSerializer()
		{
		}
		[Test]
		public virtual void TestInit()
		{
		}
		[Test]
		public virtual void TestSerialize()
		{
			try
			{
				// Illegal Argument due to null
				try
				{
					jjs.serialize(null, new ByteArrayOutputStream());
					Assert.Fail("should throw exception");
				}
				catch (System.ArgumentException)
				{
					//Expected
				}

				// Illegal Argument due to null
				try
				{
					jjs.serialize(new object(), null);
					Assert.Fail("should throw exception");
				}
				catch (System.ArgumentException)
				{
					//Expected
				}

				// Illegal Argument due to null
				try
				{
					jjs.Serialize(null, null);
					Assert.Fail("should throw exception");
				}
				catch (System.ArgumentException)
				{
					//Expected
				}
			}
			catch (JSONSerializerException ex)
			{
				Assert.Fail("Shouldn't have thrown this exception: " + ex);
			}

			// Mapping Exception. Can't serialize to an object and can't create an empty bean serializer
			try
			{
				jjs.serialize(new object(), new ByteArrayOutputStream());
				Assert.Fail("Should throw a JSONMappingException");
			}
			catch (JSONSerializerException)
			{
				// Expected
			}

			// Test successful serialization
			User user = new User();
			user.email = "test@test.com";
			try
			{
				jjs.serialize(user, new ByteArrayOutputStream());
			}
			catch (JSONSerializerException)
			{
				Assert.Fail("Shouldn't throw an exception");
			}

			// Test IOException
			File tempFile = null;
			try
			{
				tempFile = File.createTempFile("json_test", ".tmp");
				FileOutputStream fos = new FileOutputStream(tempFile);
				fos.close();
				try
				{
					jjs.serialize(user, fos);
				}
				catch (JSONSerializerException)
				{
					// Expected

				}
			}
			catch (IOException)
			{
				Assert.Fail("Trouble creating a temp file");
			}
		}

		[Test]
		public virtual void TestDeserialize()
		{
			try
			{
				// Illegal argument due to null
				try
				{
					jjs.deserialize(null, null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				// Illegal argument due to null
				try
				{
					jjs.deserialize(typeof(User), null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				// ILlegal argument due to null
				try
				{
					jjs.deserialize(null, new ByteArrayInputStream(new sbyte[10]));
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception should not be thrown: " + ex);
			}


			// Test Successful deserialize of a serialized user back to a User Object

			// Serialize User
			ByteArrayOutputStream b = new ByteArrayOutputStream();
			User originalUser = new User();
			originalUser.firstName = "Test";
			jjs.serialize(originalUser,b);

			// Deserialize User from a byte array
			User user = jjs.deserialize(typeof(User), new ByteArrayInputStream(b.toByteArray()));
			Assert.AreEqual(originalUser.firstName,user.firstName);
		}

		[Test]
		public virtual void TestDeserializeMap()
		{
			// Test null pointer exceptions
			try
			{
				jjs.deserializeMap(null);
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.ArgumentException)
			{
				// expected
			}

			// Parse Exception / invalid json
			try
			{
				string str = "test";
				jjs.deserializeMap(new ByteArrayInputStream(str.GetBytes()));
				Assert.Fail("Exception should have been thrown.");
			}
			catch (JSONSerializerException)
			{
				// expected
			}

			// Mapping Exception. Can't deserialize a JSON array to a Map object as the key would be an int
			string str = "[\"test\",\"test1\"]";
			try
			{
				jjs.deserializeMap(new ByteArrayInputStream(str.GetBytes()));
				Assert.Fail("Exception should have been thrown.");
			}
			catch (JSONSerializerException)
			{
				//expected
			}

			// IO Exception
			try
			{
				FileInputStream fis = new FileInputStream(File.createTempFile("json_test", ".tmp"));
				fis.close();

				jjs.deserializeMap(fis);
				Assert.Fail("Should have thrown an IOException");
			}
			catch (JSONSerializerException)
			{
				//expected
			}

			// Valid deserialize
			str = "{'key':'value'},{'key':'value'}".Replace("'", "\"");
			jjs.deserializeMap(new ByteArrayInputStream(str.GetBytes()));
		}

		[Test]
		public virtual void TestDeserializeList()
		{
			// Test null pointer exceptions
			try
			{
				jjs.deserializeList(null, null);
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.ArgumentException)
			{
				// expected
			}
			try
			{
				jjs.deserializeList(typeof(ArrayList), null);
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.ArgumentException)
			{
				// expected
			}
			try
			{
				jjs.deserializeList(null, new ByteArrayInputStream(new sbyte[10]));
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.ArgumentException)
			{
				// expected
			}

			// Test JsonParseException. Can't convert an invalid json array to a list.
			try
			{
				jjs.deserializeList(typeof(IList), new ByteArrayInputStream("[broken jason".GetBytes()));
				Assert.Fail("Should have thrown a JsonParseException");
			}
			catch (JSONSerializerException)
			{
				// Expected
			}

			// Serialize a User and fail since it is not an ArrayList
			ByteArrayOutputStream b = new ByteArrayOutputStream();
			User originalUser = new User();
			jjs.serialize(originalUser,b); //b has the user in json format in a byte array
			try
			{
				jjs.deserializeList(typeof(ArrayList), new ByteArrayInputStream(b.toByteArray()));
				Assert.Fail("Exception should have been thrown.");
			}
			catch (JSONSerializerException)
			{
				//expected
			}

			// Test serializing/deserializing a simple ArrayList
			jjs = new JacksonJsonSerializer();
			IList<string> originalList = new List<string>();
			originalList.Add("something");
			originalList.Add("something-else");
			b = new ByteArrayOutputStream();
			jjs.serialize(originalList, b);
			IList<string> newList = jjs.deserializeList(typeof(string), new ByteArrayInputStream(b.toByteArray()));
			// Verify that the serialized/deserialized object is equal to the original object.
			if (!newList.Equals(originalList))
			{
				Assert.Fail("Types should be identical. Serialization/Deserialation might have failed.");
			}

			// Test JSONSerializerException

			// Test IOException
			try
			{
				FileInputStream fis = new FileInputStream(File.createTempFile("json_test", ".tmp"));
				fis.close();

				jjs.deserializeList(typeof(IList), fis);
				Assert.Fail("Should have thrown an IOException");
			}
			catch (JSONSerializerException)
			{
				//expected
			}
		}



		[Test]
		public virtual void TestDeserializeResult()
		{
			try
			{
				try
				{
					jjs.deserializeResult(null, null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				try
				{
					jjs.deserializeResult(typeof(User), null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				try
				{
					jjs.deserializeResult(null, new ByteArrayInputStream(new sbyte[10]));
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception should not be thrown: " + ex);
			}

			Result<Folder> result = new Result<Folder>();
			result.message = "Test Result";
			ByteArrayOutputStream outputStream = new ByteArrayOutputStream();

			// Test successful deserialization
			try
			{
				jjs.serialize(result, outputStream);
				jjs.deserializeResult(typeof(Result), new ByteArrayInputStream(outputStream.toByteArray()));
			}
			catch (JSONSerializerException ex)
			{
				Assert.Fail("Exception should not be thrown: " + ex);
			}

			// Test JSONMappingException - Test Mapping a list back to one object
			try
			{
				outputStream = new ByteArrayOutputStream();
				List<User> users = new List<User>();
				jjs.serialize(users, outputStream);
				jjs.deserializeResult(typeof(Result), new ByteArrayInputStream(outputStream.toByteArray()));
				Assert.Fail("Exception should have been thrown");
			}
			catch (JSONSerializerException)
			{
				// Expected
			}

			// Test IOException
			try
			{
				FileInputStream fis = null;
				try
				{
					fis = new FileInputStream(File.createTempFile("json_test", ".tmp"));
					fis.close();
				}
				catch (Exception ex)
				{
					Assert.Fail("Issue running a test where a temp file is being created." + ex);
				}

				jjs.deserializeResult(typeof(Result), fis);
				Assert.Fail("Should have thrown an IOException");
			}
			catch (JSONSerializerException)
			{
				//expected
			}

			// Test JsonParseException
			try
			{
				jjs.deserializeResult(typeof(Result), new ByteArrayInputStream("{oops it's broken".GetBytes()));
				Assert.Fail("Should have thrown a JsonParseException");
			}
			catch (JSONSerializerException)
			{
				// Expected
			}
		}

		[Test]
		public virtual void TestDeserializeListResult()
		{
			try
			{
				try
				{
					jjs.deserializeListResult(null, null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				try
				{
					jjs.deserializeListResult(typeof(User), null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				try
				{
					jjs.deserializeListResult(null, new ByteArrayInputStream(new sbyte[10]));
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception should not be thrown: " + ex);
			}

			Result<List<object>> result = new Result<List<object>>();
			result.message = "Test Message";
			ByteArrayOutputStream outputStream = new ByteArrayOutputStream();

			// Test successful deserialization
			try
			{
				jjs.serialize(result, outputStream);
				jjs.deserializeListResult(typeof(Result), new ByteArrayInputStream(outputStream.toByteArray()));
			}
			catch (JSONSerializerException ex)
			{
				Assert.Fail("Exception should not be thrown: " + ex);
			}

			// Test IOException
			try
			{
				FileInputStream fis = null;
				try
				{
					fis = new FileInputStream(File.createTempFile("json_test", ".tmp"));
					fis.close();
				}
				catch (Exception ex)
				{
					Assert.Fail("Issue running a test where a temp file is being created." + ex);
				}

				jjs.deserializeListResult(typeof(Result), fis);
				Assert.Fail("Should have thrown an IOException");
			}
			catch (JSONSerializerException)
			{
				//expected
			}

			// Test JSONMappingException - Test Mapping a list back to one object
			try
			{
				outputStream = new ByteArrayOutputStream();
				List<User> users = new List<User>();
				jjs.serialize(users, outputStream);
				jjs.deserializeListResult(typeof(Result), new ByteArrayInputStream(outputStream.toByteArray()));
				Assert.Fail("Exception should have been thrown");
			}
			catch (JSONSerializerException)
			{
				// Expected
			}


			// Test JsonParseException
			try
			{
				jjs.deserializeListResult(typeof(Result), new ByteArrayInputStream("{bad json".GetBytes()));
				Assert.Fail("Should have thrown a JsonParseException");
			}
			catch (JSONSerializerException)
			{
				// Expected
			}
		}

	}

}