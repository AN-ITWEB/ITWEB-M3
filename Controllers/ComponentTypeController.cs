﻿using System;
using System.Collections.Generic;
using System.Linq;
using ITWEB_M3.Context;
using ITWEB_M3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITWEB_M3.Controllers
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
            var list = _context.ComponentTypes.Include(x => x.CategoryToComponentTypes).ThenInclude(x => x.Category).Include(x => x.Components).ToList();

            return View(list);
        }

        // GET: /Category/Create
        [Authorize]
        public ViewResult Create()
        {
            SetupViewBagsForComponentTypeAndCategory();

            var model = new ComponentTypeViewModel();
            return View(model);
        }

        private void SetupViewBagsForComponentTypeAndCategory()
        {
            var componentTypeList = Enum.GetNames(typeof(ComponentTypeStatus)).Select(componentTypeStatus => new SelectListItem { Text = componentTypeStatus, Value = componentTypeStatus }).ToList();
            ViewBag.ComponentTypeStatusesList = componentTypeList;

            var categoryList = _context.Categories.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() }).ToList(); ;
            ViewBag.CategoryList = categoryList;
        }



        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(ComponentTypeViewModel data)
        {
            ComponentType componentType = GetComponentType(data);
            _context.Add(componentType);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "ComponentType");
        }

        private ComponentType GetComponentType(ComponentTypeViewModel data)
        {
            var componentType = ComponentType.ParseToComponent(data, null);
            List<Category> categories = GetCategoryList(data.CategoryIds);
            List<CategoryToComponentType> categoryToComponentTypes = GetCategoryToComponentList(componentType, categories);

            componentType.CategoryToComponentTypes = categoryToComponentTypes;
            return componentType;
        }

        private List<Category> GetCategoryList(IEnumerable<long> categoryIds)
        {
            return _context.Categories.Where(x => categoryIds.Contains(x.CategoryId)).ToList();
        }

        private static List<CategoryToComponentType> GetCategoryToComponentList(ComponentType componentType, List<Category> categories)
        {
            var categoryToComponentTypes = new List<CategoryToComponentType>();

            foreach (var categoryToComponentType in categories)
            {
                categoryToComponentTypes.Add(new CategoryToComponentType
                {
                    ComponentType = componentType,
                    ComponentTypeId = componentType.ComponentTypeId,
                    Category = categoryToComponentType,
                    CategoryId = categoryToComponentType.CategoryId
                });
            }

            return categoryToComponentTypes;
        }

        [Authorize]
        public ViewResult Edit(long id)
        {
            SetupViewBagsForComponentTypeAndCategory();
            var data = _context.ComponentTypes.Find(id);

            var componentTypeViewModel = ComponentTypeViewModel.ParseToComponentViewModel(data, _context.Categories.ToList());
            return View(componentTypeViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, ComponentTypeViewModel data)
        {
            var test = _context.ComponentTypes.First(x => x.ComponentTypeId == id);
            data.ComponentTypeId = id;
            var componentType = GetComponentType(data);
            ComponentType.OverWrite(test, componentType);
            

            _context.ComponentTypes.Update(test);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _context.ComponentTypes.Remove(new ComponentType{ ComponentTypeId = id });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "ComponentType");
        }
        public ViewResult View(long id)
        {
            var components = _context.ComponentTypes.Include(x => x.ComponentTypeId).Where(z => z.ComponentTypeId == id).SelectMany(y => y.Components).ToList();
            return View(components);
        }
    }
}