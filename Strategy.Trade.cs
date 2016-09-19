/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/6/11
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Quant4s_sdk
{
	/// <summary>
	/// Description of Strategy.Trade.
	/// </summary>
	public partial class Strategy
	{
		
		private const int BUY = 1;
		private const int SELL = 2;
		
		private int _createOrderNo() {
			return 1;
		}
		public int Buy(String symbol, int quantity, float price, int tradeAccountId = 1) {
			int orderNo = _createOrderNo();
			var order = Order.createLimitOrder(orderNo,  symbol, price, quantity, BUY);
			order.tradeAccountId = tradeAccountId;
			
			_limitOrder(order);
			
			return orderNo;
		}
		
		
		public int Buy(String symbol, int quantity) {
			int orderNo = _createOrderNo();
//			var order = Order.createMarketOrder(1,
//			_marketOrder(order);
			return orderNo;
		}
		
		public int Sell(String symbol, int quantity, float price, int tradeAccountId = 1) {
			int orderNo = _createOrderNo();
			var order = Order.createLimitOrder(orderNo,  symbol, price, quantity, SELL);
			order.tradeAccountId = tradeAccountId;
			
			_limitOrder(order);
			
			return orderNo;
			
		}
		
		public int Sell(String symbol, int quantity) {
			int orderNo = _createOrderNo();

			return orderNo;
		
		}
		
		public int Cancel( int cancelOrderNo, int tradeAccountId = 1) {
			int orderNo = 2;// _createOrderNo();
			var order = new CancelOrder(orderNo) {cancelOrderNo = cancelOrderNo, tradeAccountId = tradeAccountId};
			_cancelOrder(order);
			
			return orderNo;
		}
		
		/// <summary>
		/// 成交回报 | 撤单成功回报
		/// </summary>
		protected void OnTransactionReport(string json) {
			
		}
	}
}
