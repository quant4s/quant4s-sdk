
using System;

namespace Quant4s_sdk.example
{

	public class BasicTemplateStrategy : Strategy
	{
		public override int Id {
			get {
				return 1;
			}
		}
		
		public override string Name {
			get {
				return "基本策略";
			}
		}
		
		protected override void Initialize()
		{
			// 增加关注的股票 5f Bar 数据
			Subscribe("000001.XSHE", 5, OnData_000001);
			
			// Tick 数据
			Subscribe("000002.XSHE", OnData_000002_TICK);
			
			MACD("000001.XSHE",9,9,21, 5, this.onMacd);
		}
		
		private void OnData_000001(String data) {
			Console.WriteLine("自定义接收方法" + data);
			Buy("000001.XSHE", 100, 10);
			Sell("000001.XSHE", 100, 10);
		}
		
		private void OnData_000002_TICK(string data) {
			Console.WriteLine("自定义接收TICK方法" + data);
		}
		
		private void onMacd(string data) {
			Console.WriteLine("macd" + data);
		}
	}
}
