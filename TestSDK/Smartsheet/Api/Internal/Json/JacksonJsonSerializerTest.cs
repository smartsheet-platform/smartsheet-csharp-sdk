using System;
using System.Collections;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal.Json
{
    using NUnit.Framework;
    using System.IO;
    using System.Text;
    using Smartsheet.Api.Models;
    using Folder = Smartsheet.Api.Models.Folder;
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
					jjs.serialize<Object>(null, new StreamWriter(new MemoryStream()));
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
					jjs.serialize<Object>(null, null);
					Assert.Fail("should throw exception");
				}
				catch (System.ArgumentException)
				{
					//Expected
				}
			}
			catch (JsonSerializationException ex)
			{
				Assert.Fail("Shouldn't have thrown this exception: " + ex);
			}

			// Test successful serialization
			User user = new User();
			user.Email = "test@test.com";
			try
			{
				jjs.serialize(user, new StreamWriter(new MemoryStream()));
			}
			catch (JsonSerializationException)
			{
				Assert.Fail("Shouldn't throw an exception");
			}

			// Test IOException
			string tempFile = null;
			try
			{
                tempFile = Path.GetTempPath() + "json_test"+Guid.NewGuid().ToString() + ".tmp";
                StreamWriter fs = new StreamWriter(tempFile);
                fs.Close();
				try
				{
					jjs.serialize(user, fs);
				}
				catch (JsonSerializationException)
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
					jjs.deserialize<Object>(null);
					Assert.Fail("Exception should have been thrown.");
				}
				catch (System.ArgumentException)
				{
					// Expected
				}

				// Illegal argument due to null
				try
				{
					jjs.deserialize<User>(null);
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
            StreamWriter s = new StreamWriter(new MemoryStream());
			User originalUser = new User();
			originalUser.FirstName = "Test";
			jjs.serialize(originalUser,s);
            s.Flush();
            s.BaseStream.Position = 0;

			// Deserialize User from a byte array
            User user = jjs.deserialize<User>(new StreamReader(s.BaseStream));
			Assert.AreEqual(originalUser.FirstName,user.FirstName);
		}

        [Test]
        public virtual void TestDeserializeMap()
        {
            // Test null pointer exceptions
            try
            {
                jjs.DeserializeMap(null);
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
                jjs.DeserializeMap(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(str))));
                Assert.Fail("Exception should have been thrown.");
            }
            catch (JsonSerializationException)
            {
                // expected
            }

            // Mapping Exception. Can't deserialize a JSON array to a Map object as the key would be an int
            string str1 = "[\"test\",\"test1\"]";
            try
            {
                jjs.DeserializeMap(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(str1))));
                Assert.Fail("Exception should have been thrown.");
            }
            catch (JsonSerializationException)
            {
                //expected
            }

            // Valid deserialize
            string str2 = "{'key':'value'},{'key':'value'}".Replace("'", "\"");
            jjs.DeserializeMap(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(str2))));
        }

        [Test]
        public virtual void TestDeserializeList()
        {
            // Test null pointer exceptions
            try
            {
                jjs.deserializeList<Object>(null);
                Assert.Fail("Exception should have been thrown.");
            }
            catch (System.ArgumentException)
            {
                // expected
            }

            // Test JsonParseException. Can't convert an invalid json array to a list.
            try
            {
                jjs.deserializeList<IList>(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes("[broken jason"))));
                Assert.Fail("Should have thrown a JsonParseException");
            }
            catch (JsonSerializationException)
            {
                // Expected
            }

            // Serialize a User and fail since it is not an ArrayList
            StreamWriter sw = new StreamWriter(new MemoryStream());
            User originalUser = new User();
            jjs.serialize<User>(originalUser, sw); //b has the user in json format in a byte array
            sw.Flush();
            sw.BaseStream.Position = 0;

            try
            {

                jjs.deserializeList<ArrayList>(new StreamReader(sw.BaseStream));
                Assert.Fail("Exception should have been thrown.");
            }
            catch (JsonSerializationException)
            {
                //expected
            }

            // Test serializing/deserializing a simple ArrayList
            jjs = new JsonNetSerializer();
            IList<string> originalList = new List<string>();
            originalList.Add("something");
            originalList.Add("something-else");

            
            StreamWriter sw1 = new StreamWriter(new MemoryStream());
            jjs.serialize(originalList, sw1);
            sw1.Flush();
            sw1.BaseStream.Position = 0;


            IList<string> newList = jjs.deserializeList<string>(new StreamReader(sw1.BaseStream));
            // Verify that the serialized/deserialized object is equal to the original object.
            Assert.AreEqual(originalList, newList);

            // Test JSONSerializerException

            // Test IOException
            try
            {
                string tempFile1 = Path.GetTempPath() + "json_test" + Guid.NewGuid().ToString() + ".tmp";
                StreamWriter fs = new StreamWriter(tempFile1);
                fs.Flush();
                fs.Close();

                jjs.deserializeList<IList>(new StreamReader(fs.BaseStream));
                Assert.Fail("Should have thrown an IOException");
            }
            catch (ArgumentNullException)
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
                    jjs.deserializeResult<Object>(null);
                    Assert.Fail("Exception should have been thrown.");
                }
                catch (System.ArgumentException)
                {
                    // Expected
                }

                try
                {
                    jjs.deserializeResult<User>(null);
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

            RequestResult<Folder> result = new RequestResult<Folder>();
            result.Message = "Test Result";
            StreamWriter sw = new StreamWriter(new MemoryStream());
            sw.BaseStream.Flush();
            sw.BaseStream.Position = 0;

            // Test successful deserialization
            try
            {
                jjs.serialize<RequestResult<Folder>>(result, sw);
                jjs.deserializeResult<RequestResult<Folder>>(new StreamReader(sw.BaseStream));
            }
            catch (JsonSerializationException ex)
            {
                Assert.Fail("Exception should not be thrown: " + ex);
            }

            // Test IOException
            try
            {
                FileStream fs = null;
                try
                {
                    fs = File.Create(Path.GetTempPath() + "json_test" + Guid.NewGuid().ToString() + ".tmp");
                }
                catch (Exception ex)
                {
                    Assert.Fail("Issue running a test where a temp file is being created." + ex);
                }
                StreamReader sr = new StreamReader(fs);
                sr.Close();
                jjs.deserializeResult<RequestResult<Object>>(sr);
                Assert.Fail("Should have thrown an IOException");
            }
            catch (JsonSerializationException)
            {
                //expected
            }

            // Test JsonParseException
            try
            {
                jjs.deserializeResult<RequestResult<Object>>(new StreamReader(new MemoryStream(
                    Encoding.UTF8.GetBytes("{oops it's broken"))));
                Assert.Fail("Should have thrown a JsonParseException");
            }
            catch (JsonSerializationException)
            {
                // Expected
            }
        }

    //    [Test]
    //    public virtual void TestDeserializeListResult()
    //    {
    //        try
    //        {
    //            try
    //            {
    //                jjs.deserializeListResult(null, null);
    //                Assert.Fail("Exception should have been thrown.");
    //            }
    //            catch (System.ArgumentException)
    //            {
    //                // Expected
    //            }

    //            try
    //            {
    //                jjs.deserializeListResult(typeof(User), null);
    //                Assert.Fail("Exception should have been thrown.");
    //            }
    //            catch (System.ArgumentException)
    //            {
    //                // Expected
    //            }

    //            try
    //            {
    //                jjs.deserializeListResult(null, new ByteArrayInputStream(new sbyte[10]));
    //                Assert.Fail("Exception should have been thrown.");
    //            }
    //            catch (System.ArgumentException)
    //            {
    //                // Expected
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Assert.Fail("Exception should not be thrown: " + ex);
    //        }

    //        Result<List<object>> result = new Result<List<object>>();
    //        result.message = "Test Message";
    //        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();

    //        // Test successful deserialization
    //        try
    //        {
    //            jjs.serialize(result, outputStream);
    //            jjs.deserializeListResult(typeof(Result), new ByteArrayInputStream(outputStream.toByteArray()));
    //        }
    //        catch (JSONSerializerException ex)
    //        {
    //            Assert.Fail("Exception should not be thrown: " + ex);
    //        }

    //        // Test IOException
    //        try
    //        {
    //            FileInputStream fis = null;
    //            try
    //            {
    //                fis = new FileInputStream(File.createTempFile("json_test", ".tmp"));
    //                fis.close();
    //            }
    //            catch (Exception ex)
    //            {
    //                Assert.Fail("Issue running a test where a temp file is being created." + ex);
    //            }

    //            jjs.deserializeListResult(typeof(Result), fis);
    //            Assert.Fail("Should have thrown an IOException");
    //        }
    //        catch (JSONSerializerException)
    //        {
    //            //expected
    //        }

    //        // Test JSONMappingException - Test Mapping a list back to one object
    //        try
    //        {
    //            outputStream = new ByteArrayOutputStream();
    //            List<User> users = new List<User>();
    //            jjs.serialize(users, outputStream);
    //            jjs.deserializeListResult(typeof(Result), new ByteArrayInputStream(outputStream.toByteArray()));
    //            Assert.Fail("Exception should have been thrown");
    //        }
    //        catch (JSONSerializerException)
    //        {
    //            // Expected
    //        }


    //        // Test JsonParseException
    //        try
    //        {
    //            jjs.deserializeListResult(typeof(Result), new ByteArrayInputStream("{bad json".GetBytes()));
    //            Assert.Fail("Should have thrown a JsonParseException");
    //        }
    //        catch (JSONSerializerException)
    //        {
    //            // Expected
    //        }
    //    }

    }

}