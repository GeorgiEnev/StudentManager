using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentManager.Models;

namespace StudentManager.Controllers
{
    public class ExamsController : Controller
    {
        private readonly AppDbContext _context;
        public ExamsController(AppDbContext context) => _context = context;

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            // Auto‑delete past exams
            var past = _context.Exams.Where(e => e.ExamDate.Date < DateTime.Today);
            if (past.Any())
            {
                _context.Exams.RemoveRange(past);
                await _context.SaveChangesAsync();
            }

            var exams = _context.Exams.Include(e => e.Subject);
            return View(await exams.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var exam = await _context.Exams
                                     .Include(e => e.Subject)
                                     .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null) return NotFound();
            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: Exams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamDate,Location,SubjectId")] Exam exam)
        {
            // Prevent validation errors on the Subject navigation property
            ModelState.Remove(nameof(exam.Subject));

            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SubjectId = new SelectList(_context.Subjects, "Id", "Name", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return NotFound();
            ViewBag.SubjectId = new SelectList(_context.Subjects, "Id", "Name", exam.SubjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExamDate,Location,SubjectId")] Exam exam)
        {
            if (id != exam.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Exams.Any(e => e.Id == exam.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SubjectId = new SelectList(_context.Subjects, "Id", "Name", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var exam = await _context.Exams
                                     .Include(e => e.Subject)
                                     .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null) return NotFound();
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
