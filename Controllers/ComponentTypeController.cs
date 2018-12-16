using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ITWEB_M3.Models;

namespace ITWEB_M3.Web
{
    public class ComponentTypeController : Controller
    {
        public ComponentTypeController()
        {

        }

        public ViewResult Index()
        {
            //DummyData
            var data = new ComponentType()
            {
                AdminComment = "asda",
                ComponentTypeId = 123,
                Status = ComponentTypeStatus.Available,
                ComponentInfo = "asdasd",
                ComponentName = "awsdasd"
            };
            var listOfComponentTypes = new List<ComponentType> { data };


            return View(listOfComponentTypes);
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

            // insert
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        public ViewResult Edit(int id)
        {
            var data = new Component();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, ComponentType data)
        {
            //edit
            return RedirectToAction(nameof(Index), "ComponentType");
        }

        public ActionResult Delete(int id)
        {
            // _repo.Delete(_repo.Get(id));
            return RedirectToAction(nameof(Index), "ComponentType");
        }
    }
}