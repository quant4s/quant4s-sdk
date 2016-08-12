/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/7/7
 * Time: 20:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;
namespace Quant4s_sdk
{
	/// <summary>
	/// Description of Strategy.Indicators.
	/// </summary>
	public partial class Strategy
	{
        private const string wsHost = "ws://localhost:8888/data/marketdata/{0}";
        private const string restHost = "http://localhost:8888/{0}";
        private string restStrategyBaseUrl = string.Format(restHost, "strategy");
        private string restOrderBaseUrl = string.Format(restHost, "order");
        private string restDataBaseUrl = string.Format(restHost, "data");

        private RestClient rest = new RestClient();
        
        /// <summary>
        /// 监控成交回报
        /// </summary>
        protected void monitorReport(string json) {
        	
        }
                
        private void register() {
        	
        }
        
		private void _start() {
        	string url = restStrategyBaseUrl;
        	string data = "{\"id\": 1,\"name\": \"实盘测试1\",\"runMode\":1, \"status\": 1, \"portfolio\": {\"cash\":1000000, \"date\":\"2004-09-04T18:06:22Z\"}}";
        	var resp = rest.Put(url, data);
        	//var ret = JsonConvert.DeserializeObject(resp, typeof(JsonStrategy));
		}
		
		private void _stop() {
        	string url = restStrategyBaseUrl + Id;
        	string data = "";
        	var resp = rest.Put(url, data);
		}
        
        private void _subscribeData(string data) {
        	string url = restDataBaseUrl + "/" + data;
        	var resp = rest.Post(url);
        }
        
        private void _cancelOrder(CancelOrder order) {
        	string url = restOrderBaseUrl + order.Id;
        	rest.Delete(url);
        }
        
        private void _limitOrder(LimitOrder order) {
        	string url = restOrderBaseUrl + "";
        	rest.Post(url);
        }
        
        private void _marketOrder(MarketOrder order) {
        	string url = restOrderBaseUrl + "";
        	rest.Post(url);
        }
        
	}
	

}

