using OtoGaleri.Data.DataModel;
using OtoGaleri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Controllers
{
    public class SupportController : Controller
    {
        private Entity db = new Entity();
        // GET: Support
        //MAIL SERVICE 
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.Supports = db.Support.ToList();
            return View(model);
        }
    }
}