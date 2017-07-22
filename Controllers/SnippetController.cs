using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iSnippets.Models;

namespace iSnippets.Controllers
{
    public class SnippetController : Controller
    {
        private readonly SnippetContext _context;

        public SnippetController(SnippetContext context)
        {
            _context = context;    
        }

        // GET: Snippet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Snippet.ToListAsync());
        }

        // GET: Snippet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await _context.Snippet
                .SingleOrDefaultAsync(m => m.ID == id);
            if (snippet == null)
            {
                return NotFound();
            }

            return View(snippet);
        }

        // GET: Snippet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Snippet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Language,Code_Snippet")] Snippet snippet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snippet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(snippet);
        }

        // GET: Snippet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await _context.Snippet.SingleOrDefaultAsync(m => m.ID == id);
            if (snippet == null)
            {
                return NotFound();
            }
            return View(snippet);
        }

        // POST: Snippet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Language,Code_Snippet")] Snippet snippet)
        {
            if (id != snippet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snippet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnippetExists(snippet.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(snippet);
        }

        // GET: Snippet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await _context.Snippet
                .SingleOrDefaultAsync(m => m.ID == id);
            if (snippet == null)
            {
                return NotFound();
            }

            return View(snippet);
        }

        // POST: Snippet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snippet = await _context.Snippet.SingleOrDefaultAsync(m => m.ID == id);
            _context.Snippet.Remove(snippet);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SnippetExists(int id)
        {
            return _context.Snippet.Any(e => e.ID == id);
        }
    }
}
