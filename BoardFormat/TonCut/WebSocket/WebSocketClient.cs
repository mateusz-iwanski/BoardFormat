using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using WebSocket4Net;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net;

namespace TonCut
{
    public class WebSocketClient
    {

        private string cmd;
        public WebSocket websocketClient;
        private string url;
        private string protocol;
        private WebSocketVersion version;
        public bool disposed;
        private IWSClientCommander _WSClientCommander;

        public WebSocketClient(WSClientCommander _wSClientCommander)
        {
            this._WSClientCommander = _wSClientCommander._Command != null 
                ? _wSClientCommander 
                : throw new Exception("Set command for WSClientCommander first!");

            Setup("ws://localhost:8080", "basic", WebSocketVersion.Rfc6455);
            //Setup("ws://10.156.0.130:8080", "basic", WebSocketVersion.Rfc6455);
        }

        private void Setup(string url, string protocol, WebSocketVersion version)
        {
            this.url = url;
            this.protocol = protocol;
            this.version = WebSocketVersion.Rfc6455;
        }

        private async Task SendMessage(string message)
        {            
            while (this.websocketClient.State != WebSocketState.Open)
                await Task.Delay(200);
            this.websocketClient.Send(message);
        }

        public async Task Send() 
        {
            if (this._WSClientCommander.IsDone)
                throw new Exception("Can't use WSClientCommander which is done.");
            
            using (WebSocket webSC = new WebSocket(this.url) { EnableAutoSendPing = true, AutoSendPingInterval = 3 })
            {
                this.websocketClient = webSC;
                this.websocketClient.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocketClient_Error);
                this.websocketClient.Opened += new EventHandler(websocketClient_Opened);
                this.websocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocketClient_MessageReceived);                    
                // websocketClient.Closed += new EventHandler(Stop);
                this.websocketClient.Open();
                await SendMessage(this._WSClientCommander._Command.GetCommand());
                // Finish when message from server is not Event response but BaseCommand response
                while (!this._WSClientCommander.IsDone)
                    await Task.Delay(500);
            }
        }

        private void websocketClient_Opened(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Client successfully connected.");
            Console.WriteLine();
        }

        private void websocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Message Received. Server answered: " + e.Message);            
            this._WSClientCommander.Add(e.Message);            
        }

        private void websocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.GetType() + ": " + e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);

            if (e.Exception.InnerException != null)
            {
                Console.WriteLine(e.Exception.InnerException.GetType());
            }

            return;
        }

    }
}
