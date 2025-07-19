using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;

namespace StudentManager.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;

        public SubjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var subjects = await _context.Subjects
                .Include(s => s.Teacher) 
                .ToListAsync();

            return View(subjects);
        }


        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(_context.Teachers, "Id", "FullName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Subjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject subject, string TeacherName)
        {
            Console.WriteLine("🚀 Entered Create POST");

            if (string.IsNullOrWhiteSpace(TeacherName))
            {
                Console.WriteLine("⚠️ Teacher name is missing");
                ModelState.AddModelError("TeacherName", "Teacher Name is required");
            }

            // ✅ This line is critical — prevents Razor from blocking on navigation property
            ModelState.Remove("Teacher");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState is invalid. Errors:");
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"🔴 {entry.Key}: {error.ErrorMessage}");
                    }
                }

                return View(subject);
            }

            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FullName == TeacherName);
            if (teacher == null)
            {
                Console.WriteLine("👤 Creating new teacher: " + TeacherName);
                teacher = new Teacher { FullName = TeacherName };
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
            }

            subject.TeacherId = teacher.Id;
            Console.WriteLine("✅ Saving subject: " + subject.Name);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            Console.WriteLine("🎉 Subject created successfully");
            return RedirectToAction(nameof(Index));
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects
                .Include(s => s.Teacher) // ← this is important
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
                return NotFound();

            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Name, string TeacherName)
        {
            var subject = await _context.Subjects
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(TeacherName))
            {
                ModelState.AddModelError("", "Both Subject and Teacher names are required.");
                return View(subject);
            }

            subject.Name = Name;
            subject.Teacher.FullName = TeacherName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.Teacher) // 👈 Include the Teacher
                .FirstOrDefaultAsync(m => m.Id == id);

            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }


        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
