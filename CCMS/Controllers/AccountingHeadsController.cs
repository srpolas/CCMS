using CCMS.Data;
using CCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Controllers
{
    public class AccountingHeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountingHeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountingHeads
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountingHeads.ToListAsync());
        }

        // GET: AccountingHeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingHead = await _context.AccountingHeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountingHead == null)
            {
                return NotFound();
            }

            return View(accountingHead);
        }

        // GET: AccountingHeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountingHeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountingHeadId,AccountingHeadName,HeadType,HeadCategory,HeadDescription,IsHeadActive")] AccountingHead accountingHead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountingHead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountingHead);
        }

        // GET: AccountingHeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingHead = await _context.AccountingHeads.FindAsync(id);
            if (accountingHead == null)
            {
                return NotFound();
            }
            return View(accountingHead);
        }

        // POST: AccountingHeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountingHeadId,AccountingHeadName,HeadType,HeadCategory,HeadDescription,IsHeadActive")] AccountingHead accountingHead)
        {
            if (id != accountingHead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountingHead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingHeadExists(accountingHead.Id))
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
            return View(accountingHead);
        }

        // GET: AccountingHeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingHead = await _context.AccountingHeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountingHead == null)
            {
                return NotFound();
            }

            return View(accountingHead);
        }

        // POST: AccountingHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountingHead = await _context.AccountingHeads.FindAsync(id);
            if (accountingHead != null)
            {
                _context.AccountingHeads.Remove(accountingHead);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountingHeadExists(int id)
        {
            return _context.AccountingHeads.Any(e => e.Id == id);
        }
    }
}
