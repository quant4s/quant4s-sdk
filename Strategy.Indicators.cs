/*
 * 策略指标
 */
using System;
using System.Collections.Generic;

namespace Quant4s_sdk
{
	/// <summary>
	/// Description of Strategy.Indicators.
	/// </summary>
	public partial class Strategy
	{
		private IDictionary<String, Action<String>> callbacks =  new Dictionary<String, Action<String>>();
		
		public void MACD(String symbol, int fastPeriod, int slowPeriod, int signalPeriod, int period, Action<String> callback) {
			string param = String.Format("{0}~{1}~{2}", fastPeriod, slowPeriod, signalPeriod);
			string data = string.Format("{0},MACD,{1},{2}", symbol, period, param);
			
			_subscribeData(data, callback);			
           	// monitorZeroMQ(data, callback);
		}
	}
}
