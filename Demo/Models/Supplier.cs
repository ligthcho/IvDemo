using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
	/// <summary>
	/// 供应商表
	/// </summary>
	public class Supplier
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ID
		{
			get;
			set;
		}
		[DisplayName("供应商编号")]
		[Required(ErrorMessage = "必填字段！")]
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string SupplierID
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
		[Required(ErrorMessage = "必填字段！")]
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
		public SupplierType SupplierType
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
		[DisplayName("工作流")]
		/// <summary>
		/// 工作流
		/// </summary>
		public string SupplierWorkFlow
		{
			get;
			set;
		}
		[DisplayName("组织机构")]
		[Required(ErrorMessage = "必填字段！")]
		/// <summary>
		/// 组织机构
		/// </summary>
		public string SupplierOrganization
		{
			get;
			set;
		}
		[DisplayName("备注")]
		/// <summary>
		/// 备注
		/// </summary>
		public string SupplierRemarks
		{
			get;
			set;
		}
		[DisplayName("审核状态")]
		/// <summary>
		/// 审核状态
		/// </summary>
		public string SupplierAuditStatus
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
