
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
		
		public override void SetStockPool()
		{
            // 根据历史数据选股（板块，指数，财务信息等等）
//			var bk = getSector("BK00001");
//			var index = getIndexCode("399001");

            // 对选股的内容做集合运算，并订阅数据
            // 并集
//            Subscribe(bk union index, 5, onData);			
//			// 差集
//			MACD(bk minus index, 9,9,21, 5, onMacdData);
//			// 交集
//			KAMA(bk intersection IndexCode, onKama)
		}
		
		private void onData(String json) {
			// 接收到所有关注股票的JSON bar 数据
		}
		
		private void onMacdData(String json) {
			// 接收到所有关注股票的macd 数据
		}
		
		protected override void Initialize()
		{
			AddBlankListRiskRule("000001.XSHE");
			RiskControlEnabled = true;
			RiskControlEnabled = false;
			// 增加关注的股票 5f Bar 数据
			Subscribe("000001.XSHE", 5, OnData_000001);
			RiskControlEnabled = false;
//			Subscribe("000001.XSHE", 5, OnData_000001_1);
			
			// Tick 数据
//			Subscribe("000002.XSHE", OnData_000002_TICK);
//			
//			MACD("000001.XSHE",9,9,21, 5, this.onMacd);
//			MACD("000001.XSHE",9,9,21, 15, this.onMacd15);
		}
		
		private void OnData_000001(String data) {
			 Console.WriteLine("0.自定义接收方法" + data);
			Buy("000001.XSHE", 100, 10);		// 默认使用编号为1的交易接口
//			Sell("000001.XSHE", 100, 10, 2);	// 使用编号为2的交易接口
//			Cancel(1);	// 默认使用编号为1 的交易接口
		}
			private void OnData_000001_1(String data) {
			 Console.WriteLine("1.自定义接收方法" + data);
//			Buy("000001.XSHE", 100, 10);		// 默认使用编号为1的交易接口
//			Sell("000001.XSHE", 100, 10, 2);	// 使用编号为2的交易接口
//			Cancel(1);	// 默认使用编号为1 的交易接口
		}	
		private void OnData_000002_TICK(string data) {
			// Console.WriteLine("自定义接收TICK方法" + data);
		}
		
		double macd5;
		private void onMacd(string data) {
			macd5 = 3;
//			Console.WriteLine( DateTime.Now + " macd" + data);
		}
		private void onMacd15(string data) {
			var macd15 = 3;
//			if(macd15 > macd5) Buy("000001.XSHE", 100, 10);
//			Console.WriteLine( DateTime.Now + " macd" + data);
		}
	}
}
