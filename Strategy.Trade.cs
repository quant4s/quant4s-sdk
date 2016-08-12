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
		public void Buy(String symbol, int quantity, float price) {
			
		}
		
		public void Buy(String symbol, int quantity) {
			
		}
		
		public void Sell(String symbol, int quantity, float price) {
			
		}
		
		public void Sell(String symbol, int quantity) {
			
		}
		
		/// <summary>
		/// 成交回报 | 撤单成功回报
		/// </summary>
		protected void OnTransactionReport(string json) {
			
		}
	}
}
