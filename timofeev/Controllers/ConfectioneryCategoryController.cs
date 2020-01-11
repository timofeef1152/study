using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class ConfectioneryCategoryController : Controller
    {
        // GET:
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetConfectioneryCategories());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new ConfectioneryCategory());
        }

        [HttpPost]
        public ActionResult Add(ConfectioneryCategory cc)
        {
            if (Db.AddConfectioneryCategory(cc))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(cc);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(Db.GetConfectioneryCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(ConfectioneryCategory cc)
        {
            if (Db.UpdateConfectioneryCategory(cc))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(cc);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeleteConfectioneryCategory(id) });
        }
    }
}