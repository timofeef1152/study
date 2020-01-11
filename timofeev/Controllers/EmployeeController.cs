using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timofeev.Models;

namespace timofeev.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll(string msg = "")
        {
            ViewBag.Message = msg;
            return View(Db.GetEmployees());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new EmployeeVM(Db.GetPersons(), Db.GetPositions(), Db.GetRatings()));
        }

        [HttpPost]
        public ActionResult Add(EmployeeVM eVM)
        {
            if (Db.AddEmployee(eVM.Employee))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(eVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(new EmployeeVM(Db.GetPersons(), Db.GetPositions(), Db.GetRatings(), Db.GetEmployee(id)));
        }

        [HttpPost]
        public ActionResult Edit(EmployeeVM eVM)
        {
            if (Db.UpdateEmployee(eVM.Employee))
            {
                return RedirectToAction("GetAll", new { msg = "Success" });
            }
            else
            {
                ViewBag.Message = "Error";
                return View(eVM);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return RedirectToAction("GetAll", new { msg = Db.DeleteEmployee(id) });
        }
    }
}