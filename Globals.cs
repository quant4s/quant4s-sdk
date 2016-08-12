/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/6/11
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Quant4s_sdk {
	public class Security {
		public String symbol { get; set; }
		public String name { get; set; }
	}
	
	public class Slice {
		public Ticks Ticks {
			get;
			set;
		}
		
		public TradeBars Bars {
			get;
			set;
		}
	}
	
	public class Tick {
		
	}
	
	public class TradeBar {
		
	}
	
	public class Ticks {
		
	}
	
	public class TradeBars {
		
	}
}