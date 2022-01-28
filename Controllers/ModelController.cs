using OtoGaleri.Data.DataModel;
using OtoGaleri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OtoGaleri.Controllers
{
    public class ModelController : Controller
    {
        private Entity db = new Entity();
        // GET: Model
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
            Model model = new Model();
            model.BrandList = new SelectList(db.Brand, "brand_id", "brand_name");
            model.GearOptionList = new SelectList(db.GearOption, "gearoption_id", "gearoption_name");
            model.FuelOptionList = new SelectList(db.FuelOption, "fueloption_id", "fueloption_name");
            model.MotorOptionList = new SelectList(db.MotorOption, "motoroption_id", "motoroption_name");
            model.ColorList = new SelectList(db.Color, "color_id", "color_name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Model model, HttpPostedFileBase imageURL)
        {
            WebImage img = new WebImage(imageURL.InputStream);
            FileInfo info = new FileInfo(imageURL.FileName);
            string logoname = Guid.NewGuid().ToString() + info.Extension;
            img.Save("~/Uploads/Vehicles/img/" + logoname);
            model.model_image = "/Uploads/Vehicles/img/" + logoname;

            db.Models.Add(model);
            db.SaveChanges();

            TempData["SuccessAdminLayout"] = "Model başarılı şekilde eklendi...";
            return RedirectToAction("Index", "Model");
        }
    }
}