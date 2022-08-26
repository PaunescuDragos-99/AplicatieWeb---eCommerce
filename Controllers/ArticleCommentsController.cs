using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;
using TemaPawFinal1.ViewModel;

namespace TemaPawFinal1.Controllers
{
    public class ArticleCommentsController : Controller
    {
        private readonly BookDbContext _context;

        public ArticleCommentsController(BookDbContext context)
        {
            _context = context;
        }

        // GET: ArticleComments
        public async Task<IActionResult> Index()
        {
            var filmeContext = _context.ArticlesComments.Include(a => a.Filmes);
            return View(await filmeContext.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(ArticleCommentViewModel vm)
        {
            var comment = vm.Comment;
            var articleID = vm.ArticlesID;
            var rating = vm.Rating;

            ArticleComment artComment = new ArticleComment()
            {
                FilmesID = articleID,
                Comments = comment,
                Rating = rating,
                PublishedDate = DateTime.Now

            };

            _context.ArticlesComments.Add(artComment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Books", new { id = articleID });

        }


        // GET: ArticleComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.ArticlesComments
                .Include(a => a.Filmes)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articleComment == null)
            {
                return NotFound();
            }

            return View(articleComment);
        }

        // GET: ArticleComments/Create
        public IActionResult Create()
        {
            ViewData["FilmesID"] = new SelectList(_context.Books, "ID", "ID");
            return View();
        }

        // POST: ArticleComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Comments,PublishedDate,FilmesID,Rating")] ArticleComment articleComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmesID"] = new SelectList(_context.Books, "ID", "ID", articleComment.FilmesID);
            return View(articleComment);
        }

        // GET: ArticleComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.ArticlesComments.FindAsync(id);
            if (articleComment == null)
            {
                return NotFound();
            }
            ViewData["FilmesID"] = new SelectList(_context.Books, "ID", "ID", articleComment.FilmesID);
            return View(articleComment);
        }

        // POST: ArticleComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Comments,PublishedDate,FilmesID,Rating")] ArticleComment articleComment)
        {
            if (id != articleComment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleCommentExists(articleComment.ID))
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
            ViewData["FilmesID"] = new SelectList(_context.Books, "ID", "ID", articleComment.FilmesID);
            return View(articleComment);
        }

        // GET: ArticleComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleComment = await _context.ArticlesComments
                .Include(a => a.Filmes)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articleComment == null)
            {
                return NotFound();
            }

            return View(articleComment);
        }

        // POST: ArticleComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleComment = await _context.ArticlesComments.FindAsync(id);
            _context.ArticlesComments.Remove(articleComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleCommentExists(int id)
        {
            return _context.ArticlesComments.Any(e => e.ID == id);
        }
    }
}
