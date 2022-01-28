using OtoGaleri.Data.DataModel;
using OtoGaleri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Controllers
{
    public class BrandController : Controller
    {
        private Entity db = new Entity();
        // GET: Brand
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
        public ActionResult Create()
        {
            Brand model = new Brand();
            model.CategoryList = new SelectList(db.Category, "category_id", "category_name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            db.Brand.Add(brand);
            db.SaveChanges();
            TempData["SuccessAdminLayout"] = "Marka başarılı şekilde eklendi...";
            return RedirectToAction("Index", "Brand");
        }
    }
}