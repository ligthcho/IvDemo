using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ivDemo.Data;
using ivDemo.Models;
using X.PagedList;

namespace ivDemo.Controllers
{
    public class SuppliersController : Controller
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

			lstStudent = await _context.Set<Supplier>().
			OrderByDescending(s => s.SupplierName).
			ToPagedListAsync(pageIndex,pageSize);

			return View(lstStudent);
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .SingleOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,SupplierAbbr,SupplierClassify,SupplierCompetentProducts,SupplierBuyer,SupplierProvince,SupplierCity,SupplierAddress,SupplierEnable")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
			if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.SingleOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }
			var supplierTypeList = _context.SupplierType.ToList();
			var selectItemList = new List<SelectListItem>() {
				new SelectListItem(){Value="0",Text="",Selected=true}
			};
			var selectList = new SelectList(supplierTypeList,"TypeCode","TypeName");
			selectItemList.AddRange(selectList);
			ViewBag.database = selectItemList;
			return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierId,SupplierName,SupplierAbbr,SupplierClassify,SupplierCompetentProducts,SupplierBuyer,SupplierProvince,SupplierCity,SupplierAddress,SupplierEnable")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				try
				{
					_context.Update(supplier);
					if(await _context.SaveChangesAsync() > 0)
					{
						ViewData["SumbitMessge"] = "保存成功！";
					};
				}
				catch(DbUpdateConcurrencyException)
				{
					if(!SupplierExists(supplier.SupplierId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
               // return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .SingleOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string SupplierId)
        {
            var supplier = await _context.Supplier.SingleOrDefaultAsync(m => m.SupplierId == SupplierId);
            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(string id)
        {
            return _context.Supplier.Any(e => e.SupplierId == id);
        }
    }
}
