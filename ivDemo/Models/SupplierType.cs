using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ivDemo.Models
{
	/// <summary>
	/// 类型表
	/// </summary>
    public class SupplierType
    {
		[Key]
		/// <summary>
		/// 类型编号
		/// </summary>
		public string TypeCode
		{
			get;
			set;
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string TypeName
		{
			get;
			set;
		}
	}
}
