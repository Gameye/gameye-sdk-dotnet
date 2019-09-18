using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Gameye.Sdk.Tests.TestUtils
{
    internal class HttpServer
    {
        private static int nextAvailablePort = 6677;
        public static int GetNextPort() => nextAvailablePort++;

        public int Port { get; private set; }

        private HttpListener listener;
        private const int PORT_NUMBER = 6677;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public Action<Uri, NameValueCollection, Stream> OnRequest;
        public Action<HttpListenerResponse> HandleResponse;

        public HttpServer(int portNumber = PORT_NUMBER)
        {
            Port = portNumber;
            listener = new HttpListener();
            listener.Prefixes.Add($"http://127.0.0.1:{portNumber}/");
            listener.Prefixes.Add($"http://localhost:{portNumber}/");
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("HttpServer: Started");

            Task.Run(() =>
            {

                var token = tokenSource.Token;
                while (!token.IsCancellationRequested)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerResponse response = context.Response;
                    OnRequest?.Invoke(context.Request.Url, context.Request.Headers, context.Request.InputStream);
                    HandleResponse?.Invoke(context.Response);
                    
                    context.Response.Close();
                }

                Console.WriteLine("HttpServer: Stopped");
            });            
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }
    }
}
