/*
 * 由SharpDevelop创建。
 * 用户： joe
 * 日期: 2016/8/1
 * 时间: 13:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using System.Windows.Forms;
using ZeroMQ;

namespace Quant4s_sdk
{
	/// <summary>
	/// Description of Strategy_ZeroMQ.
	/// </summary>
	public partial class Strategy
	{
		
		
		private void monitorZeroMQ(String topic, Action<String> callback) {
			if(callback == null) {
				callback = onData;
			}
			
			Thread t = new Thread(new ThreadStart(new MonitorData(topic, callback).run));
			t.Start();
			
		}
		
//		private void runMonitorMQThread(String topic, Action<String> callback) {
//			Thread t = new Thread(new ThreadStart(new MonitorData(topic).run));
//		}
		
		private class MonitorData {
			private const String connect_to = "tcp://127.0.0.1:8089";
			private String topic;
			private Action<String> callback;
			public MonitorData(String topic, Action<String> callback) {
				this.topic = topic;
				this.callback = callback;
			}
			
			public void run() {
				using( var subscriber = new ZSocket(ZSocketType.SUB)) {
					subscriber.Connect(connect_to);	
					// 启动一个线程监听数据
					subscriber.Subscribe(topic);
					while(true) {
						var replyFrames = (System.Collections.Generic.List<ZFrame>)subscriber.ReceiveFrames(2);
						var replyFrame = replyFrames[1];
						string reply = replyFrame.ReadString();
						if(callback != null)
							callback.Invoke(topic +  ": " + reply);
						
					}
				}			
			}
		}
	}
}
