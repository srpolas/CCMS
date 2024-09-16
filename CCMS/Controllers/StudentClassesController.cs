using CCMS.Data;
using CCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Controllers
{
	public class StudentClassesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentClassesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: StudentClasses
		public async Task<IActionResult> Index()
		{
			return View(await _context.StudentClasses.ToListAsync());
		}

		// GET: StudentClasses/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var studentClass = await _context.StudentClasses
				.FirstOrDefaultAsync(m => m.Id == id);
			if (studentClass == null)
			{
				return NotFound();
			}

			return View(studentClass);
		}

		// GET: StudentClasses/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: StudentClasses/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,ClassCode,ClassName,ClassStatus")] StudentClass studentClass)
		{
			if (ModelState.IsValid)
			{
				_context.Add(studentClass);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(studentClass);
		}

		// GET: StudentClasses/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var studentClass = await _context.StudentClasses.FindAsync(id);
			if (studentClass == null)
			{
				return NotFound();
			}
			return View(studentClass);
		}

		// POST: StudentClasses/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,ClassCode,ClassName,ClassStatus")] StudentClass studentClass)
		{
			if (id != studentClass.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(studentClass);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StudentClassExists(studentClass.Id))
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
			return View(studentClass);
		}

		// GET: StudentClasses/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var studentClass = await _context.StudentClasses
				.FirstOrDefaultAsync(m => m.Id == id);
			if (studentClass == null)
			{
				return NotFound();
			}

			return View(studentClass);
		}

		// POST: StudentClasses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var studentClass = await _context.StudentClasses.FindAsync(id);
			if (studentClass != null)
			{
				_context.StudentClasses.Remove(studentClass);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StudentClassExists(int id)
		{
			return _context.StudentClasses.Any(e => e.Id == id);
		}
	}
}
