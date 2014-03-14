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

namespace Smartsheet.Api
{
    public class HttpTestServer
    {
        int port;
        HttpListener server = null;
        string contentType;
        string responseBody;
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

                byte[] buffer = Encoding.UTF8.GetBytes(responseBody);

                response.ContentLength64 = buffer.Length;
                Stream st = response.OutputStream;
                st.Write(buffer, 0, buffer.Length);

                context.Response.Close();
            }
            receive();
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

        public string ResponseBody
        {
            get { return responseBody; }
            set
            {
                if (File.Exists(value))
                {
                    responseBody = File.ReadAllText(value);
                }
                else
                {
                    //responseBody = value;
                    throw new Exception("FILE NOT FOUND: " + value);
                }
            }


        }
    }
}