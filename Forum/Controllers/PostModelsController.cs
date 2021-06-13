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
    public class PostModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostModels
        [AllowAnonymous]
        public  IActionResult Index(int id)
        {
           if(id != 0)
            {
                return View(_context.Posty.Where(s => s.TematID == id).ToList());
            }
            return RedirectToAction("Index", "TematModels");
        }

        // GET: PostModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posty
                .FirstOrDefaultAsync(m => m.PostModelID == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // GET: PostModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostModelID,PostTemat,PostModelCialo,Tworca,DataDodania,TematID")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                postModel.DataDodania = DateTime.Now;
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PostModels", new { id = postModel.TematID });
               
            }
            return View(postModel);
        }

        // GET: PostModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posty.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }
            return View(postModel);
        }

        // POST: PostModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostModelID,PostTemat,PostModelCialo,Tworca,DataDodania,TematID")] PostModel postModel)
        {
            if (id != postModel.PostModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostModelExists(postModel.PostModelID))
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
            return View(postModel);
        }

        // GET: PostModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posty
                .FirstOrDefaultAsync(m => m.PostModelID == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // POST: PostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postModel = await _context.Posty.FindAsync(id);
            var Tematid = postModel.TematID;
            _context.Posty.Remove(postModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PostModels", new { id = Tematid });
        }

        private bool PostModelExists(int id)
        {
            return _context.Posty.Any(e => e.PostModelID == id);
        }
    }
}
