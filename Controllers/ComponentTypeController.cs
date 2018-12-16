using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ITWEB_M3.Context;
using ITWEB_M3.Models;

namespace ITWEB_M3.Web
{
    public class ComponentTypeController : Controller
    {
        private readonly EmbededStockContext _context;
        public ComponentTypeController(EmbededStockContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var list = _context.ComponentTypes.ToList();

            return View(list);
        }

        // GET: /Category/Create
        public ViewResult Create()
        {
            var model = new ComponentType();
            return View(model);
        }

        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(ComponentType data)
        {
            _context.ComponentTypes.Add(data);
            _context.SaveChanges();
            // insert
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        public ViewResult Edit(long id)
        {
            var data = _context.ComponentTypes.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, ComponentType data)
        {
            _context.ComponentTypes.Update(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        public ActionResult Delete(int id)
        {
            _context.ComponentTypes.Remove(new ComponentType{ ComponentTypeId = id });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "ComponentType");
        }
    }
}