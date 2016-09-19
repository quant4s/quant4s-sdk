/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/6/11
 * Time: 20:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Quant4s_sdk.example;

namespace WebSocketTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("运行策略");
			
			var strategy = new BasicTemplateStrategy();
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			strategy.Close();
		}
		
	}
	
	
}