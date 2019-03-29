using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ivDemo.Models
{
	/// <summary>
	/// 供应商表
	/// </summary>
	public class Supplier
	{
		/// <summary>
		/// 供应商编号
		/// </summary>
		public Guid SupplierId
		{
			get;
			set;
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string SupplierName
		{
			get;
			set;
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string SupplierAbbr
		{
			get;
			set;
		}
		/// <summary>
		/// 所属分类
		/// </summary>
		public string SupplierClassify
		{
			get;
			set;
		}
		/// <summary>
		/// 供应类型
		/// </summary>
		public ICollection<SupplierType> SupplierType
		{
			get;
			set;
		}
		/// <summary>
		/// 主管产品
		/// </summary>
		public string CompetentProducts
		{
			get;
			set;
		}
		/// <summary>
		/// 采购员
		/// </summary>
		public string SupplierBuyer
		{
			get;
			set;
		}
		/// <summary>
		/// 省份
		/// </summary>
		public string SupplierProvince
		{
			get;
			set;
		}
		/// <summary>
		/// 城市
		/// </summary>
		public string SupplierCity
		{
			get;
			set;
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string SupplierAddress
		{
			get;
			set;
		}
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
