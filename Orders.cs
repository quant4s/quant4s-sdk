/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/7/7
 * Time: 20:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Quant4s_sdk
{

	/// <summary>
	/// Description of Orders.
	/// </summary>
	public class Order
	{
		public Order(int orderNo) {
			this.orderNo = orderNo;
		}
		public int orderNo {get; private set;}
		public int tradeAccountId {get; set;}
		
		public static LimitOrder createLimitOrder(int orderNo, string symbol, float price, int quantity, int side) {
			return new LimitOrder(orderNo) {
				price = price,
				symbol = symbol,
				quantity = quantity,
				side = side,
			};
		}
	}
	
	public class LimitOrder : Order {
		public LimitOrder(int orderNo) : base(orderNo) {
		}
		public float price {get;set;}
		public int quantity {get;set;}
		public string symbol {get; set;}
		public int orderType { get {return 0;}}
		public int orderStatus { get {return 0;}}
		public int side { get; set;}
		public string openClose {get {return "";}}

	}
	
	public class CancelOrder : Order {
		public CancelOrder(int orderNo) : base(orderNo) {
		}
	}
	
	public class MarketOrder : Order {
		public MarketOrder(int orderNo) : base(orderNo) {
		}
		
	}
}
