/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/7/7
 * Time: 20:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
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
        private String restRiskRuleBaseUrl = "http://localhost:8888/strategy/addrisk/{0}/{1}/{2}";
        private String restRiskRuleEnableBaseUrl = "http://localhost:8888/strategy/enablerisk/{0}";
        private String restRiskRuleDisableBaseUrl = "http://localhost:8888/strategy/disablerisk/{0}";

        private RestClient rest = new RestClient();
          
		private void _start() {
        	string url = restStrategyBaseUrl + "/start/" + Id;
        	rest.Put(url);
		}
		
		private void _stop() {
        	string url = restStrategyBaseUrl + "/stop/" + Id;
        	var resp = rest.Put(url);
		}
   
        private void _addRiskRule(String riskName, String riskRule) {
        	var url = String.Format(restRiskRuleBaseUrl, this.Id, riskName, riskRule);
        	var resp = rest.Post(url);
        }
        
        private void _enableRiskControl() {
        	var url = String.Format(restRiskRuleEnableBaseUrl, this.Id);
        	var resp = rest.Put(url);
        }
        
        private void _disableRiskControl() {
        	var url = String.Format(restRiskRuleDisableBaseUrl, this.Id);
        	var resp = rest.Put(url);
        }
        
        private void _subscribeData(string data, Action<String> callback) {
        	
        	string url = restDataBaseUrl + "/" + data+"ggg3qg";
        	monitorZeroMQ(data, callback);
        	var resp = rest.Post(url, data);
        }
        
        private void _cancelOrder(CancelOrder order) {
        	string url = string.Format("{0}/{1}-{2}-{3}-{4}", restOrderBaseUrl, this.Id, order.orderNo, order.cancelOrderNo,order.tradeAccountId);
        	// string url = restOrderBaseUrl + "/" + this.id + "-" + order.orderNo + "";
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

