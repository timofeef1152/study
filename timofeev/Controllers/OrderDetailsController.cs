using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetailsDetails
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetOrderDetails());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new OrderDetailsVM(Db.GetConfectioneries(), Db.GetOrders()));
        }

        [HttpPost]
        public ActionResult Add(OrderDetailsVM cVM)
        {
            if (Db.AddOrderDetails(cVM.OrderDetails))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(cVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(new OrderDetailsVM(Db.GetConfectioneries(), Db.GetOrders(), Db.GetOrderDetails(id)));
        }

        [HttpPost]
        public ActionResult Edit(OrderDetailsVM cVM)
        {
            if (Db.UpdateOrderDetails(cVM.OrderDetails))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(cVM);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeleteOrderDetails(id) });
        }
    }
}