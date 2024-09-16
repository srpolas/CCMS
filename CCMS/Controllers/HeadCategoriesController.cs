using CCMS.Data;
using CCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Controllers
{
    public class HeadCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HeadCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeadCategories.ToListAsync());
        }

        // GET: HeadCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headCategory = await _context.HeadCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headCategory == null)
            {
                return NotFound();
            }

            return View(headCategory);
        }

        // GET: HeadCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeadCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HeadCategoryId,HeadCategoryName,HeadCategoryDescription,IsHeadCategoryActive")] HeadCategory headCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headCategory);
        }

        // GET: HeadCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headCategory = await _context.HeadCategories.FindAsync(id);
            if (headCategory == null)
            {
                return NotFound();
            }
            return View(headCategory);
        }

        // POST: HeadCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HeadCategoryId,HeadCategoryName,HeadCategoryDescription,IsHeadCategoryActive")] HeadCategory headCategory)
        {
            if (id != headCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadCategoryExists(headCategory.Id))
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
            return View(headCategory);
        }

        // GET: HeadCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headCategory = await _context.HeadCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headCategory == null)
            {
                return NotFound();
            }

            return View(headCategory);
        }

        // POST: HeadCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headCategory = await _context.HeadCategories.FindAsync(id);
            if (headCategory != null)
            {
                _context.HeadCategories.Remove(headCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeadCategoryExists(int id)
        {
            return _context.HeadCategories.Any(e => e.Id == id);
        }
    }
}
