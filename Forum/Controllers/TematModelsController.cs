using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;

namespace Forum.Controllers
{
    [Authorize]
    public class TematModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TematModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: TematModels
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Tematy.ToListAsync());
        }

        // GET: TematModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var tematModel = await _context.Tematy
                .FirstOrDefaultAsync(m => m.TematID == id);
            if (tematModel == null)
            {
                return NotFound();
            }

            return View(tematModel);
        }

        // GET: TematModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TematModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TematID,Temat,TematImg,Tworca,DataDodania")] TematModel tematModel)
        {
            if (ModelState.IsValid)
            {
                tematModel.DataDodania = DateTime.Now;
                _context.Add(tematModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tematModel);
        }

        // GET: TematModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tematModel = await _context.Tematy.FindAsync(id);
            if (tematModel == null)
            {
                return NotFound();
            }
            return View(tematModel);
        }

        // POST: TematModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TematID,Temat,TematImg,Tworca,DataDodania")] TematModel tematModel)
        {
            if (id != tematModel.TematID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tematModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TematModelExists(tematModel.TematID))
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
            return View(tematModel);
        }

        // GET: TematModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tematModel = await _context.Tematy
                .FirstOrDefaultAsync(m => m.TematID == id);
            if (tematModel == null)
            {
                return NotFound();
            }

            return View(tematModel);
        }

        // POST: TematModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tematModel = await _context.Tematy.FindAsync(id);
            _context.Tematy.Remove(tematModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TematModelExists(int id)
        {
            return _context.Tematy.Any(e => e.TematID == id);
        }
    }
}
