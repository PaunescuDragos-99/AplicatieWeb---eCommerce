using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TemaPawFinal1.Models;
using TemaPawFinal1.ViewModel;

namespace TemaPawFinal1.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(BookDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null)
                return View();

            var user = _context.Users.Where(u => u.Id.Equals(_userManager.GetUserId(User))).Include(u => u.Cart).FirstOrDefault();
            var item = _context.Books.Where(p => p.ID == id).FirstOrDefault();
            user.Cart.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id == null)
                return View();

            var user = _context.Users.Where(u => u.Id.Equals(_userManager.GetUserId(User))).Include(u => u.Cart).FirstOrDefault();
            var item = _context.Books.Where(p => p.ID == id).FirstOrDefault();
            user.Cart.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }

        public IActionResult Cart()
        {
            var user = _context.Users.Where(u => u.Id.Equals(_userManager.GetUserId(User))).Include(u => u.Cart).FirstOrDefault();
            return View(user.Cart.ToList());
        }


        
        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }


        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Filme filme = _context.Books.Find(id);
            ArticleCommentViewModel vm = new ArticleCommentViewModel();

            if (filme == null)
            {
                return NotFound();
            }

            vm.ArticlesID = id.Value;
            vm.Nume = filme.Name;
            var Comments = _context.ArticlesComments.Where(d => d.FilmesID.Equals(id.Value)).ToList();
            vm.ListOfComments = Comments;

            var ratings = _context.ArticlesComments.Where(d => d.FilmesID.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(vm);

        }

        // GET: Books/Create
        // [Authorize(Roles = "ADMIN")]
        public IActionResult Create()
        {

            return View();
        }

        
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([Bind("ID,Name,Author,Aparitie,Pret")] Filme book,IFormFile img)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                img.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            if (ModelState.IsValid)
            {
                book.Image = fileBytes;
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Author,Aparitie,Pret,Image")] Filme book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ID))
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
            return View(book);


        }

        // GET: Books/Delete/5
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Index(string Empsearch)
        {
            ViewData["GetBookdetails"] = Empsearch;

            var empquery = from x in _context.Books select x;
            if (!String.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.Name.Contains(Empsearch));

            }
            return View(await empquery.AsNoTracking().ToListAsync());
        }
        
        public IActionResult Search()
        {
                var item = _context.Books.ToList();
                return View(item);
        }


        //[Produces("application/json")]
        //[HttpGet("search")]
        //public async Task<IActionResult> Search()
        //{
        //    try
        //    {
        //        string term = HttpContext.Request.Query["term"].ToString();
        //        var postTitle = _context.Books.Where(p => p.Name.Contains(term))
        //                                    .Select(p => p.Name).ToList();
        //        return Ok(postTitle);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}






        //[HttpPost]
        //public JsonResult AutoComplete(string prefix)
        //{
        //    var product = (from N in _context.Books
        //                   where N.Name.StartsWith(prefix)
        //                   select new
        //                   {
        //                      N.Name,
        //                   }).ToList();

        //    return Json(product);
        //}

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var product = (from Book in this._context.Books
                           where Book.Name.StartsWith(prefix)
                           select new
                           {
                               label = Book.Name,
                               val = Book.ID
                           }).ToList();

            return Json(product);
        }

        [HttpGet]

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
