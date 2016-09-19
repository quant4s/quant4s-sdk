/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/7/7
 * Time: 20:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Quant4s_sdk
{
	/// <summary>
	/// Description of RestClient.
	/// </summary>
	public class RestClient
	{
		private HttpClient client = new HttpClient();
		public RestClient()
		{
		}
				
		
		public String Post(String url, String data = "") {
			return client.Post(url, data, "application/json");
		}
		
		public String Get(String url) {
			return client.Get(url);
			
		}
		
		public String Delete(String url) {
			return client.Delete(url);
		}
		

		public String Put(String url, String data = "") {
			return client.Put(url, data, "application/json");		
		}
	}
}
