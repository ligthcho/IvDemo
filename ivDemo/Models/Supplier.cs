using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ivDemo.Models
{
	/// <summary>
	/// 供应商表
	/// </summary>
	public class Supplier
	{
		[DisplayName("供应商编号")]
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string SupplierId
		{
			get;
			set;
		}
		[DisplayName("供应商名称")]
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string SupplierName
		{
			get;
			set;
		}
		[DisplayName("简称")]
		/// <summary>
		/// 简称
		/// </summary>
		public string SupplierAbbr
		{
			get;
			set;
		}
		[DisplayName("所属分类")]
		/// <summary>
		/// 所属分类
		/// </summary>
		public string SupplierClassify
		{
			get;
			set;
		}
		[DisplayName("供应类型")]
		/// <summary>
		/// 供应类型
		/// </summary>
		public ICollection<SupplierType> SupplierType
		{
			get;
			set;
		}
		[DisplayName("主管产品")]
		/// <summary>
		/// 主管产品
		/// </summary>
		public string SupplierCompetentProducts
		{
			get;
			set;
		}
		[DisplayName("采购员")]
		/// <summary>
		/// 采购员
		/// </summary>
		public string SupplierBuyer
		{
			get;
			set;
		}
		[DisplayName("省份")]
		/// <summary>
		/// 省份
		/// </summary>
		public string SupplierProvince
		{
			get;
			set;
		}
		[DisplayName("城市")]
		/// <summary>
		/// 城市
		/// </summary>
		public string SupplierCity
		{
			get;
			set;
		}
		[DisplayName("联系地址")]
		/// <summary>
		/// 联系地址
		/// </summary>
		public string SupplierAddress
		{
			get;
			set;
		}
		[DisplayName("是否启用")]
		/// <summary>
		/// 是否启用
		/// </summary>
		public string SupplierEnable
		{
			get;
			set;
		}
	}
	/// <summary>
	/// Supplier状态
	/// </summary>
	public enum SupplierStatus:int
	{
		/// <summary>
		/// 禁用
		/// </summary>
		Disabled = 0,
		/// <summary>
		/// 正常
		/// </summary>
		Normal = 1
	}

}
