using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NotifierService
{
    public class NotifierHttpServer: HttpServerBase
    {
        public NotifierHttpServer(int port) : base(port)
        {
        }

        public override void OnResponse(ref HTTPRequestStruct request, ref HTTPResponseStruct response)
        {
            if (request.Method=="GET" && request.Args.ContainsKey("text"))
            {
                SpeechAgent.Notify(request.Args["text"].Replace("_"," "));
            }
            else if (request.Method=="POST")
            {
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                string str = enc.GetString(request.BodyData);
                SpeechAgent.Notify(str);
            }
        }
    }
}