using System.Collections.Generic;

namespace Smartsheet.Api.Internal.Http
{
	using NUnit.Framework;
	 using System;
	 using System.Text;




	public class DefaultHttpClientTest
	{
		internal HttpClient client;

		[SetUp]
		public virtual void SetUp()
		{
			client = new DefaultHttpClient();
		}



		[Test]
		public virtual void TestDefaultHttpClient()
		{
		}
		[Test]
		public virtual void TestDefaultHttpClientCloseableHttpClient()
		{
		}
		[Test]
		public virtual void TestRequest()
		{
			// Null Argument
			try
			{
				client.Request(null);
				Assert.Fail("Exception should have been thrown");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			HttpRequest request = new HttpRequest();

			// No URL in request
			try
			{
				client.Request(request);

				Assert.Fail("Exception should have been thrown");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			// Test each http method
			request.Uri = new Uri("http://google.com");
			request.Method = HttpMethod.GET;
			client.Request(request);
			client.ReleaseConnection();


			request.Method = HttpMethod.POST;
			client.Request(request);
			client.ReleaseConnection();

			request.Method = HttpMethod.PUT;
			client.Request(request);
			client.ReleaseConnection();

			request.Method = HttpMethod.DELETE;
			client.Request(request);
			client.ReleaseConnection();



			// Test request with set headers and http entity but a null content
			Dictionary<string, string> headers = new Dictionary<string, string>();
			headers["name"] = "value";
			HttpEntity entity = new HttpEntity();
			entity.ContentType = "text/html; charset=ISO-8859-4";
			request.Entity = entity;
			request.Headers = headers;
			request.Method = HttpMethod.POST;
			client.Request(request);
			client.ReleaseConnection();

			// Test request with set headers and http entity and some content
			entity.Content = Encoding.UTF8.GetBytes("Hello World!");
			request.Entity = entity;
			client.Request(request);
			client.ReleaseConnection();

			// Test IOException
			try
			{
				request.Uri = new Uri("http://bad.domain");
				client.Request(request);
				client.ReleaseConnection();
				Assert.Fail("Exception should have been thrown.");
			}
			catch (Exception)
			{
				// Expected
			}


		}

	}

}