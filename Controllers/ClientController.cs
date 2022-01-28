using OtoGaleri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Controllers
{
    public class ClientController : Controller
    {
        private Entity db =new Entity();
        // GET: Client
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }
    }
}