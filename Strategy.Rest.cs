/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/7/7
 * Time: 20:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
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
        	string url = restOrderBaseUrl + "/" + this.Id + "-" + order.Id;
        	rest.Delete(url);
        }
        
        private void _limitOrder(LimitOrder order) {
        	var tran = new Transaction();
        	tran.strategyId = this.Id;
        	tran.orders.Add(order);
        	string url = restOrderBaseUrl;
        	var data = JsonConvert.SerializeObject(tran);
        	rest.Post(url, data);
        }
        
        private void _marketOrder(MarketOrder order) {
        	string url = restOrderBaseUrl + "";
        	rest.Post(url);
        }
        
        private class Transaction {
        	public int strategyId;
        	public List<LimitOrder> orders = new List<LimitOrder>();
        }
	}
	

}

