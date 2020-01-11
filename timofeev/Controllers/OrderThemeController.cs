using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class OrderThemeController : Controller
    {
        // GET: OrderTheme
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetOrderThemes());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new OrderTheme());
        }

        [HttpPost]
        public ActionResult Add(OrderTheme obj)
        {
            if (Db.AddOrderTheme(obj))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(obj);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(Db.GetOrderTheme(id));
        }

        [HttpPost]
        public ActionResult Edit(OrderTheme obj)
        {
            if (Db.UpdateOrderTheme(obj))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(obj);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeleteOrderTheme(id) });
        }
    }
}