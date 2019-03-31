using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Demo.ViewComponents
{
	public class SupplierPv:ViewComponent
	{
		private readonly SupplierContext _context;
		public SupplierPv(SupplierContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke(string currentSort,int? page)
		{
			int pageIndex = 1;
			int pageSize = 5;
			//判断page是否有值，有的话就给值，没有就赋值1
			pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

			IPagedList<Supplier> lstStudent = null;

			lstStudent =  _context.Set<Supplier>().Include("SupplierType").OrderByDescending(s => s.SupplierName).ToPagedList(pageIndex,pageSize);

			return View(lstStudent);
		}
	}
}
