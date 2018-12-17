using System;
using System.Collections.Generic;
using System.Linq;
using ITWEB_M3.Context;
using ITWEB_M3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var list = _context.Components.Include(x => x.ComponentType).ToList();

            return View(list);
        }

        // GET: /Category/Create
        public ViewResult Create()
        {
            SetupViewBags();
            var model = new ComponentViewModel();
            return View(model);
        }

        private void SetupViewBags()
        {
            var componentTypeList = Enum.GetNames(typeof(ComponentStatus)).Select(componentTypeStatus => new SelectListItem { Text = componentTypeStatus, Value = componentTypeStatus }).ToList();
            ViewBag.ComponentStatusesList = componentTypeList;

            ViewBag.ComponentTypeList = getComponentList();
        }

        private List<SelectListItem> getComponentList()
        {
            var componentTypes = _context.ComponentTypes.ToList();
            return componentTypes.Select(x => new SelectListItem{Text = x.ComponentName, Value = x.ComponentTypeId.ToString()}).ToList();
        }

        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(ComponentViewModel data)
        {
            var componentType = _context.ComponentTypes.Find(data.ComponentTypeId);
            var component = Component.ParseToComponent(data, componentType);

            _context.Components.Add(component);
            _context.SaveChanges();
            // insert
            return RedirectToAction(nameof(Index), "Component");
        }

        public ViewResult Edit(long id)
        {
            SetupViewBags();
            var data = _context.Components.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, Component data)
        {
            data.ComponentId = id;
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