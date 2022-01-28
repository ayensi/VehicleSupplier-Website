using OtoGaleri.Data.DataModel;
using OtoGaleri.Data.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Controllers
{
    public class ProductController : Controller
    {
        private Entity db = new Entity();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BuyAndRent()
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

        [HttpPost]
        public ActionResult FilterQuery(int? categoryid, int? brandid, int? fuelid, int? gearid, int? motorid,bool? isrentable, bool? isused)
        {
            int category_id, brand_id, fuel_id, gear_id, motor_id;
            category_id = Convert.ToInt32(categoryid);
            brand_id = Convert.ToInt32(brandid);
            fuel_id = Convert.ToInt32(fuelid);
            gear_id = Convert.ToInt32(gearid);
            motor_id = Convert.ToInt32(motorid);
            Model model = new Model();

            IQueryable<Model> q = db.Models;

            if (category_id != 0)
            {
                q = q.Where(p => p.category_id == category_id);
            }
            if (brand_id != 0)
            {
                q = q.Where(p => p.brand_id == brand_id);
            }
            if (fuel_id != 0)
            {
                q = q.Where(p => p.fueloption_id == fuel_id);
            }
            if (gear_id != 0)
            {
                q = q.Where(p => p.gearoption_id == gear_id);
            }
            if (motor_id != 0)
            {
                q = q.Where(p => p.motoroption_id == motor_id);
            }
            if (isrentable != null)
            {
                q = q.Where(p => p.model_isRentable == isrentable);
            }
            if (isused != null)
            {
                q = q.Where(p => p.model_isUsed == isused);
            }

            var result = q.ToList();

            //var Models = (from xs in db.Models
            //              let isCategory = xs.category_id == category_id
            //              let isBrand = xs.brand_id == brand_id
            //              let isFuel = xs.fueloption_id == fuel_id
            //              let isMotor = xs.motoroption_id == motor_id
            //              let isGear = xs.gearoption_id == gear_id
            //              where isCategory || isBrand || isFuel || isMotor || isGear
            //              select new
            //              {
            //                  category_id = (isCategory ? (int?)xs.category_id : null),
            //                  brand_id = (isBrand ? (int?)xs.brand_id : null),
            //                  fueloption_id = (isFuel ? (int?)xs.fueloption_id : null),
            //                  gearoption_id = (isGear ? (int?)xs.gearoption_id : null),
            //                  motoroption_id = (isMotor ? (int?)xs.motoroption_id : null),
            //                  model_id = xs.model_id,
            //                  model_name = xs.model_name,
            //                  model_description = xs.model_description,
            //                  model_age = xs.model_age,
            //                  model_km = xs.model_km,
            //                  model_image = xs.model_image,
            //                  model_isRentable = xs.model_isRentable,
            //                  model_price = xs.model_price,
            //                  color_id = xs.color_id

            //              }
            // ).ToList();


            var Models = result.Select(a => new
            {
                model_id = a.model_id,
                model_name = a.model_name,
                model_description = a.model_description,
                model_age = a.model_age,
                model_km = a.model_km,
                brand_id = a.brand_id,
                fueloption_id = a.fueloption_id,
                motoroption_id = a.motoroption_id,
                gearoption_id = a.gearoption_id,
                model_image = a.model_image,
                model_isRentable = a.model_isRentable,
                model_price = a.model_price,
                color_id = a.color_id,
                category_id = a.category_id,
                model_isUsed = a.model_isUsed
            }).ToList();

            return Json(new
            {
                error = false,
                success = true,
                model = Models
            }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult CheckForClientInfo(int clientid)
        {
            var client = db.Clients.Where(x => x.client_id == clientid).FirstOrDefault();
            var clientaddress = db.ClientAddress.Where(x => x.client_id == clientid).FirstOrDefault();
            if (client.client_identity_number == null || client.client_name == null || client.client_lastname == null || client.client_phone == null)
            {
                return Json(new
                {
                    success = true,
                    errormessage = "İlk önce kişisel bilgilerinizi doldurmalısınız!"
                }, JsonRequestBehavior.AllowGet);
            }
            else if(!db.ClientAddress.Where(x => x.client_id == clientid).Any())
            {
                return Json(new
                {
                    success = true,
                    errormessage = "Sepete eklemeden önce adres bilginizi girmeniz gerekiyor!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SendToCart(int model_id)
        {
            var cart = db.Models.Where(x => x.model_id == model_id).FirstOrDefault();

                Session["cart"] = cart;
                return Json(new
                {
                    error = false,
                    success = true
                }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult Cart()
        {
            ViewModel model = new ViewModel();
            model.Categories = db.Category.ToList();
            model.Brands = db.Brand.ToList();
            model.FuelOptions = db.FuelOption.ToList();
            model.Colors = db.Color.ToList();
            model.MotorOptions = db.MotorOption.ToList();
            model.GearOptions = db.GearOption.ToList();
            if (Session["cart"] != null)
            {
                var cart = (Model)Session["cart"];
                model.Models.Add(cart);
            }
            return View(model);
        }
        public async Task<ActionResult> OrderRental(int? modelid,int? clientid,int? daycount,DateTime? pickupdate,DateTime? returndate, decimal? rent_price)
        {
            Order order = new Order();
            order.client_id = clientid;
            order.model_id = modelid;
            order.order_daycount = Convert.ToInt32(daycount);
            order.order_pickupDate = Convert.ToDateTime(pickupdate);
            order.order_returnDate = Convert.ToDateTime(returndate);
            order.order_price = Convert.ToDecimal(rent_price);
            order.order_isRental = true;
            order.order_date = DateTime.Now;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                if (value < 0)
                {
                    value = value * -1;
                }
                order.order_number = value;
            }
            db.Order.Add(order);
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> OrderBuy(int? modelid, int? clientid)
        {
            Order order = new Order();
            order.order_price = db.Models.Where(x => x.model_id == modelid).FirstOrDefault().model_price;
            order.client_id = clientid;
            order.model_id = modelid;
            order.order_isRental = false;
            order.order_date = DateTime.Now;
            order.order_pickupDate = null;
            order.order_returnDate = null;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                if (value < 0)
                {
                    value = value * -1;
                }
                order.order_number = value;
            }
            db.Order.Add(order);
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

    }
}

