using CRUDUsingEF.Data;
using CRUDUsingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingEF.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        CategoryDAL categoryDAL;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
            categoryDAL = new CategoryDAL(db);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list = categoryDAL.GetAllCategories();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int cid)
        {
            var cate = categoryDAL.GetCategoryById(cid);
            
            return View(cate);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cate)
        {
            try
            {
                int result = categoryDAL.AddCategory(cate);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int cid)
        {
            var cate = categoryDAL.GetCategoryById(cid);
            return View(cate);

        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cate)
        {
            try
            {
                int result = categoryDAL.UpdateCategory(cate);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int cid)
        {
            var cate = categoryDAL.GetCategoryById(cid);
            return View(cate);

        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int cid)
        {
            try
            {
                int result = categoryDAL.DeleteCategory(cid);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
