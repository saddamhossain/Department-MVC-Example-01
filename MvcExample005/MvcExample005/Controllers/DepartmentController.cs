using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExample005.Models;

namespace MvcExample005.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentContainer aContainer = new DepartmentContainer();
        
        public ActionResult DepartmentList()
        {
           
            return View(aContainer.GetAllDepartments());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department aDepartment)
        {
            if (aDepartment.Name != null)
            {
                aContainer.Save(aDepartment);
            }
            return RedirectToAction("DepartmentList");
        }
	}
}