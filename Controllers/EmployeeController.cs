using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAssignment.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVCAssignment.Repository;

namespace MVCAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpRepo _repo;
        public ActionResult List()
        {
            _repo = new EmpRepo();
            var model = _repo.GetAllEmployees();
            return View(model);
        }
        public ActionResult AddEmp()
        {
            return View();
        }
            [HttpPost]
        public ActionResult AddEmp(EmpModel model)
        {
            _repo = new EmpRepo();
            _repo.AddEmployee(model);
            return RedirectToAction("List");
        }
      
        public ActionResult EditEmp(int Id)
        {
            _repo = new EmpRepo();
            var model = _repo.EditbyId(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateEmp(EmpModel model)
        {
            _repo = new EmpRepo();
            _repo.UpdateEmployee(model);
            return RedirectToAction("List");
        }
        public ActionResult DeletEmp(int Id)
        {
            _repo = new EmpRepo();
            _repo.DeleteEmployee(Id);
            return RedirectToAction("List");
        }
    }
}
