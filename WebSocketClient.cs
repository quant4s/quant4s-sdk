using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Quant4s_sdk
{
    public class WebSocketClient
    {
        public static WebSocketClient CreateClient(String uri, Action<String> onMessage)
        {
            return new WebSocketClient(uri, onMessage);
        }
        private WebSocket wsClient = null;
        
        public  WebSocketClient(String uri, Action<String> callback)
        {
            wsClient = new WebSocket(uri);
            wsClient.OnMessage += (sender, e) => {
                // 将RawData 转换为 String
                callback(e.ToString());
            };

        }

    }
}
