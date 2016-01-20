using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Smartsheet.Api.Internal.Utility;

namespace Smartsheet.Api
{
	public class HttpTestServer
	{
		int port;
		HttpListener server = null;
		string contentType;
		byte[] responseBody = new byte[0];
		HttpStatusCode status;


		public HttpTestServer()
		{
				port = 9090;
				server = new HttpListener();
				contentType = "application/json";
				status = HttpStatusCode.OK;
		}

		public void Start()
		{
				server.Prefixes.Add("http://127.0.0.1:"+port+"/");
				server.Prefixes.Add("http://localhost:"+port+"/");
				server.Start();

				receive();
		}

		private void receive()
		{
				IAsyncResult result = server.BeginGetContext(new AsyncCallback(ListenerCallback), server);
		}

		public HttpStatusCode Status
		{
				get { return status; }
				set { status = value; }
		}

		private void ListenerCallback(IAsyncResult result)
		{
				if (server.IsListening)
				{
					HttpListenerContext context = server.EndGetContext(result);
					HttpListenerResponse response = context.Response;
					response.ContentType = contentType;
					response.StatusCode = (int)status;

					response.ContentLength64 = responseBody.Length;
					Stream st = response.OutputStream;
					st.Write(responseBody, 0, responseBody.Length);

					context.Response.Close();
					receive();
				}
		}
		public void Stop()
		{
				if (server.IsListening)
				{
					server.Stop();
				}
		}

		public string ContentType
		{
				get { return contentType; }
				set { contentType = value; }
		}

		public byte[] ResponseBody
		{
				get { return responseBody; }
		}

		public void setResponseBody(string file)
		{
				if (File.Exists(file))
				{
					using (BinaryReader br = new BinaryReader(new FileStream(file, FileMode.Open)))
					{
						responseBody = Utility.ReadAllBytes(br);
					}
				}
		}


	}
}