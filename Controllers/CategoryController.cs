using OtoGaleri.Data.DataModel;
using OtoGaleri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Controllers
{
    public class CategoryController : Controller
    {
        private Entity db = new Entity();
        // GET: Category
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.Models = db.Models.ToList();
            model.Categories = db.Category.ToList();
            model.Brands = db.Brand.ToList();
            model.FuelOptions = db.FuelOption.ToList();
            model.Colors = db.Color.ToList();
            model.MotorOptions = db.MotorOption.ToList();
            model.GearOptions = db.GearOption.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            TempData["SuccessAdminLayout"] = "Kategori başarılı şekilde eklendi...";
            return RedirectToAction("Index","Category");
        }
    }
}