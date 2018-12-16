using ITWEB_M3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITWEB_M3.Controllers
{
    public class CategoryController : Controller
    {

        public CategoryController()
        {
        }

        // GET: /Category/
        public ViewResult Index()
        {
            //DummyData
            var data = new Category[]{new Category{Name = "asdasdasd", CategoryId = 12, CategoryToComponentTypes = { new CategoryToComponentType{Category = new Category{Name = "asdasd"},ComponentType = new ComponentType{AdminComment = "asdasd"}}}}};
            return View(data);
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
            
            // insert
            return RedirectToAction(nameof(Index), "Category");
        }

        public ViewResult Edit(int id)
        {
            var data = new Category();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, Category data)
        {
            //edit
            return RedirectToAction(nameof(Index), "Category");
        }

        public ActionResult Delete(int id)
        {
            // _repo.Delete(_repo.Get(id));
            return RedirectToAction(nameof(Index), "Category");
        }
    }
}