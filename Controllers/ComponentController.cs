using System.Collections.Generic;
using System.Linq;
using ITWEB_M3.Context;
using ITWEB_M3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITWEB_M3.Controllers
{
    public class ComponentController : Controller
    {
        private readonly EmbededStockContext _context;
        public ComponentController(EmbededStockContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var list = _context.Components.ToList();

            return View(list);
        }

        // GET: /Category/Create
        public ViewResult Create()
        {
            var model = new Component();
            return View(model);
        }

        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(Component data)
        {
            _context.Components.Add(data);
            _context.SaveChanges();
            // insert
            return RedirectToAction(nameof(Index), "Component");
        }

        public ViewResult Edit(long id)
        {
            var data = _context.Components.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, Component data)
        {
            _context.Components.Update(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Component");
        }

        public ActionResult Delete(long id)
        {
            _context.Components.Remove(new Component {ComponentId = id});
            _context.SaveChanges();
            // _repo.Delete(_repo.Get(id));
            return RedirectToAction(nameof(Index), "Component");
        }
    }
}