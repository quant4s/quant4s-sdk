/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/6/11
 * Time: 12:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Quant4s_sdk
{
	/// <summary>
	/// Description of Strategy.
	/// </summary>
	public abstract partial class Strategy
	{
		private IDictionary<String, Action<String>> symbolDatas = new Dictionary<String, Action<String>>();
        
		public abstract int Id {get;}
		public abstract String Name{get;}


        public Strategy()
		{
        	// 提交一个策略到服务器端        	
        	_start();
        	
			// 初始化
			Initialize();
		}

        private void _SubmitStrategy() {
        	
        }
        
		
        protected void Run()
        {
            // 像招财云，订阅数据

        }

        /// <summary>
        /// 更新资金组合，包括现金，持仓
        /// </summary>
        /// <param name="cash"></param>
        protected void UpdatePortfolio(double cash) {
			// 更新到 服务器端
		}
		
		/// <summary>
		/// BAR 数据
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="Period"></param>
		protected void Subscribe(String symbol, int Period, Action<String> callback = null) {
			var req = String.Format("{0},BAR,{1}", symbol, Period);
            _subscribeData(req);
           monitorZeroMQ(req, callback);
        }
		
		private void onData(String data) {
			Console.WriteLine(data);
		}
		
		/// <summary>
		/// TICK 数据
		/// </summary>
		/// <param name="symbol"></param>
		protected void Subscribe(String symbol, Action<String> callback = null) {
			var req = String.Format("{0},TICK", symbol);
            _subscribeData(req);
           	monitorZeroMQ(req, callback);
		}

        protected void SubscribeIndicator(String symbol, int period, String name, Action<String> callback)
        {

        }
		
		protected abstract void Initialize();
		
		protected virtual void OnData(Slice data) {
			
		}
	}
}
