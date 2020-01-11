using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetOrders());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new OrderVM(Db.GetClients(), Db.GetEmployees(), Db.GetOrderThemes()));
        }

        [HttpPost]
        public ActionResult Add(OrderVM cVM)
        {
            if (Db.AddOrder(cVM.Order))
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
            return View(new OrderVM(Db.GetClients(), Db.GetEmployees(), Db.GetOrderThemes(), Db.GetOrder(id)));
        }

        [HttpPost]
        public ActionResult Edit(OrderVM cVM)
        {
            if (Db.UpdateOrder(cVM.Order))
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
            return RedirectToAction("GetAll", new { msg = Db.DeleteOrder(id) });
        }
    }
}