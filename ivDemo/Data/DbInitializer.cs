﻿using System;
using System.Collections.Generic;
using System.Linq;
using ivDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ivDemo.Data
{
	public static class DbInitializer
	{
		public static void Initialize(SupplierContext context)
		{
			var SupplierTypes2 = new SupplierType[]
{
					new SupplierType{ TypeCode ="1005",TypeName="产品采购"},
					new SupplierType{ TypeCode ="1006",TypeName="材料加工"},
					new SupplierType{ TypeCode ="1007",TypeName="材料采购"}
};
			//自动创建数据库
			context.Database.EnsureCreated();
			if(!context.SupplierType.Any())
			{
				var SupplierTypes = new SupplierType[]
                {
				    new SupplierType{ TypeCode ="1001",TypeName="产品采购"},
				    new SupplierType{ TypeCode ="1002",TypeName="材料加工"},
				    new SupplierType{ TypeCode ="1003",TypeName="材料采购"}
                };
				foreach(SupplierType supplierType in SupplierTypes)
				{
					context.SupplierType.Add(supplierType);
				}
				context.SaveChanges();
			}
			if(!context.Supplier.Any())
			{
				var Suppliers = new Supplier[]
				{
				new Supplier{SupplierId="000345",SupplierName="辅料商",SupplierAbbr="fls",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="张生",SupplierProvince="广东省",SupplierCity="广州",SupplierAddress="越秀区某街道",SupplierEnable=((int)SupplierStatus.Normal).ToString(),SupplierType = SupplierTypes2},
				new Supplier{SupplierId="001019",SupplierName="浩宇面料商",SupplierAbbr="hyml",SupplierClassify="",
				 SupplierCompetentProducts="",SupplierBuyer="李生",SupplierProvince="广东省",SupplierCity="厦门",SupplierAddress="厦门某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString()},
				new Supplier{SupplierId="001021",SupplierName="材料采购商",SupplierAbbr="",SupplierClassify="",
				 SupplierCompetentProducts="",SupplierBuyer="黄生",SupplierProvince="广东省",SupplierCity="深圳",SupplierAddress="深圳某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString()},
				new Supplier{SupplierId="001034",SupplierName="甲公司a",SupplierAbbr="",SupplierClassify="",
				 SupplierCompetentProducts="",SupplierBuyer="郭生",SupplierProvince="湖南省",SupplierCity="香港",SupplierAddress="香港某街道",SupplierEnable= ((int)SupplierStatus.Disabled).ToString()},
				new Supplier{SupplierId="001049",SupplierName="面料加工商",SupplierAbbr="mljgs",SupplierClassify="面料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="羊生",SupplierProvince="广东省",SupplierCity="广州",SupplierAddress="番禺区某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString()},
				new Supplier{SupplierId="0022",SupplierName="广州市哈料辅料有限公司",SupplierAbbr="",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="张生",SupplierProvince="广东省",SupplierCity="潮汕",SupplierAddress="潮汕某街道",SupplierEnable= ((int)SupplierStatus.Disabled).ToString()},
				new Supplier{SupplierId="007001",SupplierName="材料工艺加工",SupplierAbbr="clgyjg",SupplierClassify="材料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="王生",SupplierProvince="广东省",SupplierCity="广州",SupplierAddress="白云区某街道",SupplierEnable= ((int)SupplierStatus.Disabled).ToString()},
				new Supplier{SupplierId="007002",SupplierName="产品工艺加工商",SupplierAbbr="",SupplierClassify="产品供应商",
				 SupplierCompetentProducts="",SupplierBuyer="吴生",SupplierProvince="广东省",SupplierCity="广州",SupplierAddress="天河区某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString()}
				};
				foreach(Supplier suppliers in Suppliers)
				{
					context.Supplier.Add(suppliers);
				}
				context.SaveChanges();
			}

		}
	}
}
