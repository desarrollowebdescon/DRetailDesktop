using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRtail
{
    class Socket
    {
        static public bool IsOffline = false;

        static public bool IsLine = false;

        static ClientWebSocket cws;
       
        public static async Task Conectar()
        {
            cws = new ClientWebSocket();
            Uri uri = new Uri("wss://localhost:44394/send");
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(120));
            try
            {
                await cws.ConnectAsync(uri, cts.Token);
                
                while (cws.State == WebSocketState.Open)
                {
                    IsLine = true;  
                }

                while (cws.State != WebSocketState.Open)
                {
                    IsLine = false;
                }

            }
            catch (WebSocketException wse)
            {
                Console.WriteLine(wse.Message);
            }

        }
    
        public async Task<bool> getInLine()
        {
            if (!IsLine)
            {
                await Conectar();
            }
            return IsLine;
        }
    }
}
