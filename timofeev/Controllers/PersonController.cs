using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetPersons());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Add(Person p)
        {
            if (Db.AddPerson(p))
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
            return View(Db.GetPerson(id));
        }

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            if (Db.UpdatePerson(p))
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
            return RedirectToAction("GetAll", new { msg = Db.DeletePerson(id) });
        }
    }
}