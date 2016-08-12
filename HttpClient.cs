
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quant4s_sdk
{
    public class HttpClient : WebClient
    {


        public string Post(string url, string body, string contentType = "application/x-www-form-urlencoded")
        {
        	return Submit("POST", url, body, contentType, Encoding.Default);
        }
        
        public String Put(string url, string body, string contentType = "application/x-www-form-urlencoded")
        {
        	return Submit("PUT", url, body, contentType, Encoding.Default);
        }

		public string Delete(string url)
		{
			return Submit("DELETE", url);
		}
		
        public string Submit(string method, string url) {
        	return Submit(method, url, "", "application/json", Encoding.Default);
        }
        
        public string Submit(string method, string url, string body, string contentType, Encoding encoding)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            httpWebRequest.Timeout = this.Timeout;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.CookieContainer = this.Cookies;

            if(method == "POST" || method == "PUT") {
	            byte[] btBodys = Encoding.UTF8.GetBytes(body);
	            httpWebRequest.ContentLength = btBodys.Length;
	            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding);
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        }

        public string Get(String address)
        {
            return Get(address, Encoding.Default);
        }

        public string Get(string address, Encoding encoding)
        {
        	return Submit("GET", address, "", "application/json", encoding);
//            HttpWebRequest httpWebRequest = null;
//            httpWebRequest = (HttpWebRequest)WebRequest.Create(address);
//            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;*/*;q=0.8";
//            httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
//            httpWebRequest.Headers.Add("UA-CPU", "x86");
//            httpWebRequest.Headers.Add("Accept-Charset", "utf8;q=0.8;");
//            httpWebRequest.ContentType = "application/json";
//            httpWebRequest.Method = "GET";
//            httpWebRequest.Timeout = this.Timeout;
//            httpWebRequest.KeepAlive = true;
//            httpWebRequest.CookieContainer = this.Cookies;
//
//            HttpWebResponse httpWebResponse = null;
//            StreamReader streamReader = null;
//            string responseContent = null;
//            try
//            {
//                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
//                streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding);
//                responseContent = streamReader.ReadToEnd();
//            }
//            catch (Exception e)
//            {
//                _log.Error("获取 {0} 时，发生异常 {1}", address, e.StackTrace);
//                // Console.WriteLine(e.StackTrace);
//            }
//            finally
//            {
//                if (httpWebResponse != null) httpWebResponse.Close();
//                if (streamReader != null) streamReader.Close();
//            }
//
//
//            return responseContent;
        }

        public string Referer
        {
            get; set;
        }

        public HttpClient() : this(new CookieContainer())
        {
        }

        public HttpClient(CookieContainer cookies)
        {
            this.Timeout = 0xea00;
            this.Referer = "";
            this.Cookies = cookies;
            this.Proxy = null;
            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
        }

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
            WebRequest webRequest = base.GetWebRequest(address);
            webRequest.Timeout = this.Timeout;
            if (webRequest is HttpWebRequest)
            {
                HttpWebRequest request2 = webRequest as HttpWebRequest;
                request2.Headers.Clear();
                request2.CookieContainer = this.Cookies; ;
                request2.Accept = "text/html,application/xhtml+xml,application/xml;*/*;q=0.8";
                request2.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                request2.Headers.Add("UA-CPU", "x86");
                request2.Headers.Add("Accept-Charset", "utf8;q=0.8;");
                if (this.IsGzip)
                {
                    request2.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                }
                if (this.Referer != "")
                {
                    request2.Referer = this.Referer;
                }
                // request2.UserAgent = "Baiduspider + (+http://www.baidu.com/search/spider.htm)";
                request2.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; zh-CN; rv:1.9.0.5) Gecko/2008120122 Firefox/3.0.5)";
                if (this.Referer != "")
                {
                    request2.Referer = this.Referer;
                }
                if (webRequest.Method.ToLower() == "post")
                {
                    request2.ContentType = "application/x-www-form-urlencoded";
                }
                this.Referer = address.ToString();
            }

            return webRequest;
        }


        /// <summary>
        /// 超时的操作
        /// </summary>
        /// <param name="userdata"></param>
        private void _timer_TimeOver(object userdata)
        {
            CancelAsync();
            if (DownloadStringTimeout != null)
                DownloadStringTimeout(this);
        }

        public delegate void DownloadStringTimeoutEventHandler(object sender);
        public event DownloadStringTimeoutEventHandler DownloadStringTimeout;

        // Properties
        public CookieContainer Cookies { get; set; }
        public bool IsGzip { get; set; }
        public int Timeout { get; set; }
    }
}
