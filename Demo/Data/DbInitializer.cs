using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
	public class DbInitializer
	{
		public static void Initialize(SupplierContext context)
		{
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
				new Supplier{SupplierID="000345",SupplierName="辅料商",SupplierAbbr="fls",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="张生",SupplierProvince="广东省",SupplierCity="广州",SupplierOrganization="机构1",SupplierAddress="越秀区某街道",SupplierEnable=((int)SupplierStatus.Normal).ToString(),SupplierType = new SupplierType{ TypeCode ="1001"}},
				new Supplier{SupplierID="001019",SupplierName="浩宇面料商",SupplierAbbr="hyml",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="李生",SupplierProvince="广东省",SupplierCity="厦门",SupplierOrganization="机构2",SupplierAddress="厦门某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString(),SupplierType = new SupplierType{ TypeCode ="1001"}},
				new Supplier{SupplierID="001021",SupplierName="材料采购商",SupplierAbbr="",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="黄生",SupplierProvince="广东省",SupplierCity="深圳",SupplierOrganization="机构3",SupplierAddress="深圳某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString(),SupplierType = new SupplierType{ TypeCode ="1001"}},
				new Supplier{SupplierID="001034",SupplierName="甲公司a",SupplierAbbr="",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="郭生",SupplierProvince="湖南省",SupplierCity="香港",SupplierOrganization="机构4",SupplierAddress="香港某街道",SupplierEnable= ((int)SupplierStatus.Disabled).ToString(),SupplierType = new SupplierType{ TypeCode ="1002"}},
				new Supplier{SupplierID="001049",SupplierName="面料加工商",SupplierAbbr="mljgs",SupplierClassify="面料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="羊生",SupplierProvince="广东省",SupplierCity="广州",SupplierOrganization="机构5",SupplierAddress="番禺区某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString(),SupplierType = new SupplierType{ TypeCode ="1003"}},
				new Supplier{SupplierID="0022",SupplierName="广州市哈料辅料有限公司",SupplierAbbr="",SupplierClassify="辅料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="张生",SupplierProvince="广东省",SupplierCity="潮汕",SupplierOrganization="机构6",SupplierAddress="潮汕某街道",SupplierEnable= ((int)SupplierStatus.Disabled).ToString()},
				new Supplier{SupplierID="007001",SupplierName="材料工艺加工",SupplierAbbr="clgyjg",SupplierClassify="材料供应商",
				 SupplierCompetentProducts="",SupplierBuyer="王生",SupplierProvince="广东省",SupplierCity="广州",SupplierOrganization="机构7",SupplierAddress="白云区某街道",SupplierEnable= ((int)SupplierStatus.Disabled).ToString()},
				new Supplier{SupplierID="007002",SupplierName="产品工艺加工商",SupplierAbbr="",SupplierClassify="产品供应商",
				 SupplierCompetentProducts="",SupplierBuyer="吴生",SupplierProvince="广东省",SupplierCity="广州",SupplierOrganization="机构1",SupplierAddress="天河区某街道",SupplierEnable= ((int)SupplierStatus.Normal).ToString()}
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
