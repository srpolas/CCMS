using CCMS.Data;
using CCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Controllers
{
	public class StudentSectionsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentSectionsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: StudentSections
		public async Task<IActionResult> Index()
		{
			return View(await _context.StudentSections.ToListAsync());
		}

		// GET: StudentSections/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var studentSection = await _context.StudentSections
				.FirstOrDefaultAsync(m => m.Id == id);
			if (studentSection == null)
			{
				return NotFound();
			}

			return View(studentSection);
		}

		// GET: StudentSections/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: StudentSections/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,SectionId,SectionName,ClassCode,SectionShift,TeacherId,SectionStatus")] StudentSection studentSection)
		{
			if (ModelState.IsValid)
			{
				_context.Add(studentSection);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(studentSection);
		}

		// GET: StudentSections/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var studentSection = await _context.StudentSections.FindAsync(id);
			if (studentSection == null)
			{
				return NotFound();
			}
			return View(studentSection);
		}

		// POST: StudentSections/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,SectionId,SectionName,ClassCode,SectionShift,TeacherId,SectionStatus")] StudentSection studentSection)
		{
			if (id != studentSection.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(studentSection);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StudentSectionExists(studentSection.Id))
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
			return View(studentSection);
		}

		// GET: StudentSections/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var studentSection = await _context.StudentSections
				.FirstOrDefaultAsync(m => m.Id == id);
			if (studentSection == null)
			{
				return NotFound();
			}

			return View(studentSection);
		}

		// POST: StudentSections/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var studentSection = await _context.StudentSections.FindAsync(id);
			if (studentSection != null)
			{
				_context.StudentSections.Remove(studentSection);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StudentSectionExists(int id)
		{
			return _context.StudentSections.Any(e => e.Id == id);
		}
	}
}
