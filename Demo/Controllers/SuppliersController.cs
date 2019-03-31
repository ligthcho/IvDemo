using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Models;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using Demo.ViewComponents;

namespace Demo.Controllers
{
	public class SuppliersController:Controller
	{
		private readonly SupplierContext _context;

		public SuppliersController(SupplierContext context)
		{
			_context = context;
		}

		// GET: Suppliers
		public async Task<IActionResult> Index(string currentSort,int? page)
		{
			int pageIndex = 1;
			int pageSize = 5;
			//判断page是否有值，有的话就给值，没有就赋值1
			pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
			IPagedList<Supplier> lstStudent = null;
			lstStudent = await _context.Set<Supplier>().Include("SupplierType").OrderByDescending(s => s.SupplierName).ToPagedListAsync(pageIndex,pageSize);

			return View(lstStudent);
		}

		public PartialViewResult sv()
		{
			return PartialView("SupplierPartialView");//返回部分视图,就是要展示在主视图上的数据内容板块
		}

		// GET: Suppliers/Create
		public IActionResult Create()
		{
			GetSupplierTypeList();
			return View();
		}

		// POST: Suppliers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("SupplierID,SupplierName,SupplierAbbr,SupplierClassify,SupplierCompetentProducts,SupplierBuyer,SupplierProvince,SupplierCity,SupplierAddress,SupplierEnable,SupplierAuditStatus,SupplierRemarks,SupplierOrganization,SupplierWorkFlow")] Supplier supplier,string SupplierType)
		{
			var supplierType = await _context.SupplierType.SingleOrDefaultAsync(m => m.TypeCode == SupplierType);
			var sup = new Supplier();
			if(sup == null)
			{
				return NotFound();
			}
			if(ModelState.IsValid)
			{
				if(SupplierExists(supplier.SupplierID))
				{
					ViewData.ModelState.AddModelError("SupplierID","供应商名不能重复！");
				}
				else
				{
					try
					{
						sup.SupplierID = supplier.SupplierID;
						sup.SupplierName = supplier.SupplierName;
						sup.SupplierAbbr = supplier.SupplierAbbr;
						sup.SupplierProvince = supplier.SupplierProvince;
						sup.SupplierCity = supplier.SupplierCity;
						sup.SupplierAddress = supplier.SupplierAddress;
						sup.SupplierEnable = supplier.SupplierEnable;
						sup.SupplierRemarks = supplier.SupplierRemarks;
						sup.SupplierWorkFlow = supplier.SupplierWorkFlow;
						sup.SupplierOrganization = supplier.SupplierOrganization;
						sup.SupplierAuditStatus = supplier.SupplierAuditStatus;
						sup.SupplierClassify = supplier.SupplierClassify;
						sup.SupplierType = null;
						sup.SupplierType = supplierType;
						_context.Supplier.Add(sup);
						await _context.SaveChangesAsync();
					}
					catch(DbUpdateConcurrencyException)
					{
						if(!SupplierExists(supplier.SupplierID))
						{
							return NotFound();
						}
						else
						{
							throw;
						}
					}
					return RedirectToAction(nameof(Index));
				}
			}
			GetSupplierTypeList();
			return View(supplier);
		}

		public async Task<IActionResult> Edit(Guid id)
		{
			if(id == null)
			{
				return NotFound();
			}
			var supplier = await _context.Supplier.SingleOrDefaultAsync(m => m.ID == id);
			if(supplier == null)
			{
				return NotFound();
			}
			GetSupplierTypeList();
			return View(supplier);
		}
		public void GetSupplierTypeList()
		{
			var supplierTypeList = _context.SupplierType.ToList();
			ViewBag.database = supplierTypeList;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id,[Bind("SupplierID,SupplierName,SupplierAbbr,SupplierClassify,SupplierCompetentProducts,SupplierBuyer,SupplierProvince,SupplierCity,SupplierAddress,SupplierEnable,SupplierRemarks")] Supplier supplier,string SupplierType)
		{
			var supplierType = await _context.SupplierType.SingleOrDefaultAsync(m => m.TypeCode == SupplierType);
			var sup = await _context.Supplier.Include("SupplierType").SingleOrDefaultAsync(m => m.ID == id);
			if(sup == null)
			{
				return NotFound();
			}
			if(ModelState.IsValid)
			{
				if(SupplierExists(supplier.SupplierID))
				{
					ViewData.ModelState.AddModelError("SupplierID","供应商名不能重复！");
				}
				else
				{
					try
					{
						sup.SupplierID = supplier.SupplierID;
						sup.SupplierName = supplier.SupplierName;
						sup.SupplierAbbr = supplier.SupplierAbbr;
						sup.SupplierProvince = supplier.SupplierProvince;
						sup.SupplierCity = supplier.SupplierCity;
						sup.SupplierAddress = supplier.SupplierAddress;
						sup.SupplierEnable = supplier.SupplierEnable;
						sup.SupplierRemarks = supplier.SupplierRemarks;
						sup.SupplierType = null;
						sup.SupplierType = supplierType;
						_context.Supplier.Update(sup);
						await _context.SaveChangesAsync();
					}
					catch(DbUpdateConcurrencyException)
					{
						if(!SupplierExists(supplier.SupplierID))
						{
							return NotFound();
						}
						else
						{
							throw;
						}
					}
					return RedirectToAction(nameof(Index));
				}
			}
			GetSupplierTypeList();
			return View(supplier);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string sid)
		{
			var supplier = await _context.Supplier.FindAsync(sid);
			_context.Supplier.Remove(supplier);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool SupplierExists(string id)
		{
			return _context.Supplier.Any(e => e.SupplierID == id);
		}
	}
}
