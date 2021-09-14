using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOVIEW.Context;
using MOVIEW.Models;

namespace MOVIEW.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviewDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public MoviesController(MoviewDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.strId == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // GET: Movies/Create
        //[Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize Roles]
        public async Task<IActionResult> Create([Bind("strId,strMovieName,strPrice,strDescription,ImageFile")] Movies movies)
        {
            if (ModelState.IsValid)
            {
               
                    string wwwRootPath = hostingEnvironment.WebRootPath;
                    string filename = Path.GetFileNameWithoutExtension(movies.ImageFile.FileName);
                    string extension = Path.GetExtension(movies.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/", filename);



                    var test =  filename;
                    movies.strimageurl = test;

                    //  return Content(strCategoryId);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await movies.ImageFile.CopyToAsync(fileStream);
                    }
                
                    _context.Add(movies);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(movies);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("strId,strMovieName,strPrice,strDescription")] Movies movies)
        {
            if (id != movies.strId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesExists(movies.strId))
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
            return View();
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.strId == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var movies = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(string id)
        {
            return _context.Movies.Any(e => e.strId == id);
        }
    }
}
