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

namespace Demo.Controllers
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
                .FirstOrDefaultAsync(m => m.SupplierID == id);
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
        public async Task<IActionResult> Create([Bind("SupplierID,SupplierName,SupplierAbbr,SupplierClassify,SupplierCompetentProducts,SupplierBuyer,SupplierProvince,SupplierCity,SupplierAddress,SupplierEnable")] Supplier supplier)
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
			if(id == null)
			{
				return NotFound();
			}

			var supplier = await _context.Supplier.SingleOrDefaultAsync(m => m.SupplierID == id);
			if(supplier == null)
			{
				return NotFound();
			}
			var supplierTypeList = _context.SupplierType.ToList();
			var selectItemList = new List<SelectListItem>() {
				new SelectListItem(){ Value="" ,Text="" }
			};
			//SelectList selectList = new SelectList(supplierTypeList,"TypeCode","TypeName");
			//selectItemList.AddRange(selectList);
			ViewBag.database = supplierTypeList;
			return View(supplier);
		}

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierID,SupplierName,SupplierAbbr,SupplierClassify,SupplierCompetentProducts,SupplierBuyer,SupplierProvince,SupplierCity,SupplierAddress,SupplierEnable")] Supplier supplier,string SupplierType)
        {
			var supplierType = await _context.SupplierType.SingleOrDefaultAsync(m => m.TypeCode == SupplierType);
			var sup = await _context.Supplier.Include("SupplierType").SingleOrDefaultAsync(m => m.SupplierID == supplier.SupplierID);
			if(id != supplier.SupplierID || sup == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
            {
                try
                {
					sup.SupplierName = supplier.SupplierName;
					sup.SupplierAbbr = supplier.SupplierAbbr;
					sup.SupplierProvince = supplier.SupplierProvince;
					sup.SupplierCity = supplier.SupplierCity;
					sup.SupplierAddress = supplier.SupplierAddress;
					sup.SupplierEnable = supplier.SupplierEnable;
					sup.SupplierType = null;
					sup.SupplierType = supplierType;
					_context.Supplier.Update(sup);
					await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierID))
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
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
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
