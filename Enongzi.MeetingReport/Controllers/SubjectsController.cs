using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enongzi.MeetingReport.Data;
using Enongzi.MeetingReport.Models;

namespace Enongzi.MeetingReport.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly MeetingDbContext _context;
       

        public SubjectsController(MeetingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MeetingSubjects(int id)
        {
            var meeting = _context.Meetings.Find(id);
            if (meeting is null)
                return NotFound();

            var list = await _context.Subjects.Include("Teacher").Where(m => m.MeetingId == meeting.Id).ToListAsync();
            ViewBag.Meeting = meeting;
            return View(list);

        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create(int id)
        {
            var meeting = _context.Meetings.Find(id);
            if(meeting is null)
            {
                return NotFound();
            }
            var meetings = _context.Meetings.ToList();
            //var teachers = _context.Teachers.ToList();

            List<SelectListItem> teachers = _context.Teachers.ToList().Select(m =>
            {
                return new SelectListItem
                {
                    Text = m.Name,
                    Selected = false,
                    Value = m.Id.ToString()
                };
            }).ToList();
            List<SelectListItem> list = meetings.Select(m =>
            {
                return new SelectListItem
                {
                    Text = m.Name,
                    Selected = m.Id == meeting.Id ? true : false,
                    Value = m.Id.ToString()
                };
            }).ToList();
            ViewBag.Meetings = list;
            ViewBag.Teachers = teachers;
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,TeacherId,StartTime,EndTime,MeetingId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("MeetingSubjects",new { id=subject.MeetingId });
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingId,StartTime,EndTime,Title")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .SingleOrDefaultAsync(m => m.Id == id);
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
            var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
