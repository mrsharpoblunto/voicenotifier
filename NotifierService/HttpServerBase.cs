using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace NotifierService
{
    public abstract class HttpServerBase
    {
        private readonly int _port = 8080;
        private Thread _thread;
        private TcpListener listener;

        public string Name = "MyHTTPServer/1.0.*";
        public Dictionary<int, string> respStatus;

        public HttpServerBase()
        {
            respStatusInit();
        }

        public HttpServerBase(int thePort)
        {
            _port = thePort;
            respStatusInit();
        }

        public bool IsAlive
        {
            get { return _thread.IsAlive; }
        }

        private void respStatusInit()
        {
            respStatus = new Dictionary<int, string>();

            respStatus.Add(200, "200 Ok");
            respStatus.Add(201, "201 Created");
            respStatus.Add(202, "202 Accepted");
            respStatus.Add(204, "204 No Content");

            respStatus.Add(301, "301 Moved Permanently");
            respStatus.Add(302, "302 Redirection");
            respStatus.Add(304, "304 Not Modified");

            respStatus.Add(400, "400 Bad Request");
            respStatus.Add(401, "401 Unauthorized");
            respStatus.Add(403, "403 Forbidden");
            respStatus.Add(404, "404 Not Found");

            respStatus.Add(500, "500 Internal Server Error");
            respStatus.Add(501, "501 Not Implemented");
            respStatus.Add(502, "502 Bad Gateway");
            respStatus.Add(503, "503 Service Unavailable");
        }

        public void Listen()
        {
            bool done = false;

            listener = new TcpListener(_port);

            listener.Start();

            WriteLog("Server Listening On: " + _port);

            while (!done)
            {
                WriteLog("Waiting for connection...");
                var newRequest
                    = new HttpRequest(listener.AcceptTcpClient(), this);
                var thread = new Thread(newRequest.Process);
                thread.Name = "HTTP Request";
                thread.Start();
            }
        }

        public void WriteLog(string EventMessage)
        {
            Console.WriteLine(EventMessage);
        }

        public void Start()
        {
            _thread = new Thread(Listen);
            _thread.Start();
        }

        public void Stop()
        {
            listener.Stop();
            _thread.Abort();
        }

        public void Suspend()
        {
            _thread.Suspend();
        }

        public void Resume()
        {
            _thread.Resume();
        }

        public abstract void OnResponse(ref HTTPRequestStruct request,ref HTTPResponseStruct response);
    }
}