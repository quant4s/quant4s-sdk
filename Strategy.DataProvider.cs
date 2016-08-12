/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/6/11
 * Time: 12:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Quant4s_sdk
{
	/// <summary>
	/// Description of Strategy.DataProvider.
	/// </summary>
	public partial class Strategy
	{
		// 可交易证券代码列表
		private const String REST_SYMBOLS_EQUITY = "/data/symbols/equity";
		private const String REST_SYMBOLS_FUND = "/data/symbols/fund";
		private const String REST_SYMBOLS_INDEX = "/data/symbols/index";
		private const String REST_SYMBOLS_FUTURE = "/data/symbols/future";

		// 获取季报数据
		private const String REST_FINANCE_QR = "/data/finance/${0}/${1}";  // 0: symbol  1: 1|2|3|4
		
		// 股东数据
		private const String REST_SHARE_HOLDER_QR = "/data/shareholder/${0}/${1}"; // 0: symbol  1: 1|2|3|4
			
		protected IList<Security> getEquities() {
			return null;
		}
		
	}
	

}
