using CCMS.Data;
using CCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentSubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentSubjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentSubject.ToListAsync());
        }

        // GET: StudentSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // GET: StudentSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectCode,SubjectName,SubjectStatus,ClassCode,TeacherCode")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentSubject);
        }

        // GET: StudentSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject.FindAsync(id);
            if (studentSubject == null)
            {
                return NotFound();
            }
            return View(studentSubject);
        }

        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectCode,SubjectName,SubjectStatus,ClassCode,TeacherCode")] StudentSubject studentSubject)
        {
            if (id != studentSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectExists(studentSubject.Id))
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
            return View(studentSubject);
        }

        // GET: StudentSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentSubject = await _context.StudentSubject.FindAsync(id);
            if (studentSubject != null)
            {
                _context.StudentSubject.Remove(studentSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectExists(int id)
        {
            return _context.StudentSubject.Any(e => e.Id == id);
        }
    }
}
