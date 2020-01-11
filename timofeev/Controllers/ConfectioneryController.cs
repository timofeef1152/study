using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class ConfectioneryController : Controller
    {
        // GET: Confectionery
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetConfectioneries());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new ConfectioneryVM(Db.GetConfectioneryCategories()));
        }

        [HttpPost]
        public ActionResult Add(ConfectioneryVM cVM)
        {
            if (Db.AddConfectionery(cVM.Confectionery))
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
            return View(new ConfectioneryVM(Db.GetConfectioneryCategories(), Db.GetConfectionery(id)));
        }

        [HttpPost]
        public ActionResult Edit(ConfectioneryVM cVM)
        {
            if (Db.UpdateConfectionery(cVM.Confectionery)) 
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
            return RedirectToAction("GetAll", new { msg = Db.DeleteConfectionery(id) });
        }
    }
}