using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ITWEB_M3.Context;
using ITWEB_M3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var list = _context.ComponentTypes.Include(x => x.CategoryToComponentTypes).ThenInclude(x => x.Category).ToList();

            return View(list);
        }

        // GET: /Category/Create
        public ViewResult Create()
        {
            var componentTypeList = Enum.GetNames(typeof(ComponentTypeStatus)).Select(componentTypeStatus => new SelectListItem {Text = componentTypeStatus, Value = componentTypeStatus}).ToList();
            ViewBag.ComponentTypeStatusesList = componentTypeList;

            var categoryList = _context.Categories.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() }).ToList(); ;
            ViewBag.CategoryList = categoryList;

            var model = new ComponentTypeViewModel();
            return View(model);
        }



        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(ComponentTypeViewModel data)
        {
            var componentType = ComponentType.ParseToComponent(data, null);

            var categories = _context.Categories.Where(x => data.CategoryIds.Contains(x.CategoryId)).ToList();
            var categoryToComponentTypes = new List<CategoryToComponentType>();

            foreach (var categoryToComponentType in categories)
            {
                categoryToComponentTypes.Add(new CategoryToComponentType
                {
                    ComponentType = componentType,
                    Category = categoryToComponentType,
                    CategoryId = categoryToComponentType.CategoryId
                });
            }

            componentType.CategoryToComponentTypes = categoryToComponentTypes;
            _context.Add(componentType);
            _context.SaveChanges();

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
            data.ComponentTypeId = id;
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