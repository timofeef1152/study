using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET:
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Rating());
        }

        [HttpPost]
        public ActionResult Add(Rating r)
        {
            if (Db.AddRating(r))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(r);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(Db.GetRating(id));
        }

        [HttpPost]
        public ActionResult Edit(Rating r)
        {
            if (Db.UpdateRating(r))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(r);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeleteRating(id) });
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetRatings());
        }
    }
}