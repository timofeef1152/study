using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class PositionController : Controller
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
            return View(Db.GetPositions());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Position());
        }

        [HttpPost]
        public ActionResult Add(Position p)
        {
            if (Db.AddPosition(p))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(Db.GetPosition(id));
        }

        [HttpPost]
        public ActionResult Edit(Position p)
        {
            if (Db.UpdatePosition(p))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeletePosition(id) });
        }
    }
}
