/*
 * Created by SharpDevelop.
 * User: joe
 * Date: 2016/7/8
 * Time: 8:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Quant4s_sdk
{
	/// <summary>
	/// 股票分类查找
	/// </summary>
	public partial class Strategy
	{
		public List<string> Filter(IndexCode ic) {
			ic.toCode();
			return null;
		}
		
		public List<string> FilterByIndexCode(String ic) {
			return null;
		}

	}
	
	public enum IndexCode {
		[Description("Q00001")]
		Energy,
		[Description("Q00002")]
		Materials
	}
	
	public static class IndexCodeExt {
		public static String toCode(this IndexCode value) {
			string description = value.ToString();  
	        var fieldInfo = value.GetType().GetField(description);  
	        var attributes =  
	            (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false);  
	        if (attributes != null && attributes.Length > 0)  
	        {  
	            description = attributes[0].Description;  
	        }  
	        return description;  
		}
	}
	

}
