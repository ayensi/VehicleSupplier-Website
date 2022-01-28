using OtoGaleri.Data.DataModel;
using OtoGaleri.Data.Entity;
using OtoGaleri.Data.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using System.Diagnostics;

namespace OtoGaleri.Controllers
{

    public class HomeController : Controller
    {
        private Entity db = new Entity();
        // GET: Home

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session["ClientId"] = null;
            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Client()
        {
            ViewModel model = new ViewModel();
            if (Session["ClientId"] != null)
            {
                int id = Convert.ToInt32(Session["ClientId"].ToString());
                model.ClientAddress = db.ClientAddress.Where(x=>x.client_id ==id).ToList();
                model.Client = db.Clients.Where(x => x.client_id == id).ToList();
                model.Order = db.Order.Where(x => x.client_id == id).ToList();
            }
            
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(Client client, string passwordcheck)
        {
            if (client.client_password == passwordcheck)
            {
                if (client.client_password.Length >= 8)
                {
                    var hash = SecurePasswordHasher.Hash(passwordcheck);
                    client.client_password = hash;
                    db.Clients.Add(client);
                    db.SaveChanges();
                    TempData["SuccessLayout"] = "Başarıyla kayıt oldunuz...";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorLayout"] = "Şifre 8 karakterden küçük olmamalı.";
                    return View("Index");
                }
            }
            else
            {
                TempData["ErrorLayout"] = "Şifreler uyuşmuyor.";
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult Login(Client client)
        {
            var passwordcheck = db.Clients.Where(x => x.client_email == client.client_email).FirstOrDefault();
            var result = SecurePasswordHasher.Verify(client.client_password, passwordcheck.client_password);
            if (result)
            {
                var clientLoggedin = db.Clients.Where(x => x.client_email == client.client_email).FirstOrDefault();
                TempData["SuccessLayout"] = "Başarıyla giriş yaptınız...";
                Session["ClientId"] = clientLoggedin.client_id;
                int id = clientLoggedin.client_id;
                return RedirectToAction("Index", "Home", new { id = id });
            }
            else
            {
                TempData["ErrorLayout"] = "Yanlış şifre girdiniz.";
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Support()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Support(string name, string email, string message)
        {
            Support support = new Support();
            support.support_name = name;
            support.support_email = email;
            support.support_message = message;
            support.support_date = DateTime.Now;
            db.Support.Add(support);
            await db.SaveChangesAsync();
            TempData["SuccessLayout"] = "En kısa zamanda size dönüş sağlayacağız.";
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult SendResponse(string responseemail, string responsename, string responsemessage)
        {
            return View();
        }
        public ActionResult Offices()
        {
            return View();
        }
        public async Task<ActionResult> Categories()
        {
            ViewModel model = new ViewModel();
            model.Categories = await db.Category.ToListAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> SaveClientAddress(ClientAddress data)
        {
            if (db.ClientAddress.Where(x => x.client_id == data.client_id).Any())
            {
                return Json(new
                {
                    success = true,
                    errormessage = "Sistemde zaten kayıtlı bir adresiniz var."
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                db.ClientAddress.Add(data);
                await db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public async Task<ActionResult> DeleteAddress(int clientid)
        {
            var address = db.ClientAddress.Where(x=>x.client_id == clientid).FirstOrDefault();
            db.ClientAddress.Attach(address);
            db.ClientAddress.Remove(address);
            await db.SaveChangesAsync();

            return Json(new
            {
                success = true,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> SavePersonalInfo(Client data)
        {
            var result = db.Clients.SingleOrDefault(b => b.client_id== data.client_id);
            if (result != null)
            {
                result.client_name = data.client_name;
                result.client_lastname = data.client_lastname;
                result.client_identity_number = data.client_identity_number;
                result.client_phone = data.client_phone;
                await db.SaveChangesAsync();
                return Json(new
                {
                    success = true,
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = true,
                    errormessage = "Böyle bir kullanıcı bulunamadı..."
                }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}