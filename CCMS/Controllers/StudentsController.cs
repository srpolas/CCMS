using CCMS.Data;
using CCMS.Models;
using CCMS.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Controllers
{
	public class StudentsController : Controller
	{
		private readonly ApplicationDbContext dbContext;
		public StudentsController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
			
		}
		
		
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddStudentViewModel viewModel)
		{
			var student = new Student
			{
				Name = viewModel.Name,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				Subscribed = viewModel.Subscribed
			};
			await dbContext.Students.AddAsync(student);

			await dbContext.SaveChangesAsync();


            return RedirectToAction("List", "Students");
        }

		[HttpGet]
        public async Task<IActionResult> List()
        {
			var students = await dbContext.Students.ToListAsync();
            return View(students);
        }


		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
            var student = await dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
			return View(student);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.PhoneNumber = viewModel.PhoneNumber;
                student.Subscribed = viewModel.Subscribed;
                await dbContext.SaveChangesAsync();
            }
            
            return RedirectToAction("List", "Students");
        }
		[HttpPost]
		public async Task<IActionResult> Delete(Guid id)
		{
			var student = await dbContext.Students.FindAsync(id);
			if (student is not null)
			{
				dbContext.Students.Remove(student);
				await dbContext.SaveChangesAsync();
			}
			return RedirectToAction("List", "Students");
		}
	}
}
