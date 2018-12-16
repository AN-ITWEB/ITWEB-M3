using System.Collections.Generic;
using ITWEB_M3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITWEB_M3.Controllers
{
    public class ComponentController : Controller
    {
        public ComponentController()
        {

        }

        public ViewResult Index()
        {
            //DummyData
            var data = new Component
            {
                AdminComment = "asda",
                ComponentNumber = 12,
                ComponentTypeId = 123,
                CurrentLoanInformationId = 21,
                SerialNo = "asdasd",
                Status = ComponentTypeStatus.Available,
                UserComment = "asdasda"
            };
            var listOfComponents = new List<Component> {data};

            return View(listOfComponents);
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

            // insert
            return RedirectToAction(nameof(Index), "Component");
        }

        public ViewResult Edit(int id)
        {
            var data = new Component();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, Component data)
        {
            //edit
            return RedirectToAction(nameof(Index), "Component");
        }

        public ActionResult Delete(int id)
        {
            // _repo.Delete(_repo.Get(id));
            return RedirectToAction(nameof(Index), "Component");
        }
    }
}