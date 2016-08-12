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
		public Order()
		{
		}
	}
	
	public class LimitOrder : Order {
		public float Price {get;set;}
		public int Quantity {get;set;}
		public string symbol {get; set;}
		public int Id {get;set;}
	}
	
	public class CancelOrder : Order {
		public int Id {get;set;}
	}
	
	public class MarketOrder : Order {
		
	}
}
