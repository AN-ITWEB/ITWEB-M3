using System.Linq;
using ITWEB_M3.Context;
using ITWEB_M3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITWEB_M3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EmbededStockContext _context;
        public CategoryController(EmbededStockContext context)
        {
            _context = context;
        }

        // GET: /Category/
        public ViewResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: /Category/Create
        public ViewResult Create()
        {
            var model = new Category();
            return View(model);
        }

        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(Category data)
        {
            _context.Categories.Add(data);
            _context.SaveChanges();
            // insert
            return RedirectToAction(nameof(Index), "Category");
        }

        public ViewResult Edit(long id)
        {
            var data = _context.Categories.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, Category data)
        {
            data.CategoryId = id;
            _context.Categories.Update(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Category");
        }

        public ActionResult Delete(int id)
        {
            _context.Categories.Remove(new Category{ CategoryId = id });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Category");
        }
    }
}