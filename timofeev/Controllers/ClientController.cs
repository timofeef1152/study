using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetClients());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Client());
        }

        [HttpPost]
        public ActionResult Add(Client c)
        {
            if (Db.AddClient(c))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(Db.GetClient(id));
        }

        [HttpPost]
        public ActionResult Edit(Client c)
        {
            if (Db.UpdateClient(c))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeleteClient(id) });
        }
    }
}