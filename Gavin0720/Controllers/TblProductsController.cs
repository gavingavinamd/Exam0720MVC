using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gavin0720.Models;

namespace Gavin0720.Controllers
{
    public class TblProductsController : Controller
    {
        private readonly MvcDBContext _context;

        public TblProductsController(MvcDBContext context)
        {
            _context = context;
        }

        // GET: TblProducts
        public async Task<IActionResult> Index()
        {
            return _context.TblProducts != null ?
                        View(await _context.TblProducts.ToListAsync()) :
                        Problem("Entity set 'MvcDBContext.TblProducts'  is null.");
        }

        // GET: TblProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .FirstOrDefaultAsync(m => m.CId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: TblProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CId,CName,CPrice,CInventory,CCreateDt")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                tblProduct.CCreateDt = DateTime.Now;

                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Search));
            }
            return View(tblProduct);
        }

        // GET: TblProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            return View(tblProduct);
        }

        // POST: TblProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CId,CName,CPrice,CInventory,CCreateDt")] TblProduct tblProduct)
        {
            if (id != tblProduct.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.CId))
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
            return View(tblProduct);
        }

        // GET: TblProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .FirstOrDefaultAsync(m => m.CId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: TblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblProducts == null)
            {
                return Problem("Entity set 'MvcDBContext.TblProducts'  is null.");
            }
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct != null)
            {
                _context.TblProducts.Remove(tblProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
            return (_context.TblProducts?.Any(e => e.CId == id)).GetValueOrDefault();
        }

        [HttpGet]
        public IActionResult Search()
        {
            var searchViewModel = new SearchViewModel();

            ViewData["Message"] = "報名活動搜尋 GET => 取得表單";
            return View(searchViewModel);
        }

        [HttpPost]
        public IActionResult Search(FormSearchParams searchParams)
        {
            var searchViewModel = new SearchViewModel();

            var tblProducts = _context.TblProducts.ToList();

            if(searchParams.CName != null)
            {
                var nameResult = from products in tblProducts
                                 where products.CName.Contains(searchParams.CName)
                                 select products;
                searchViewModel.ProductResult = nameResult.ToList();
            }

            return View(searchViewModel);
        }
    }
}
