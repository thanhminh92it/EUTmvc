using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Models;
using EUTmvc.Models.Admin;

namespace EUTmvc.Controllers.Admin
{
    public class AdminExamActionController : Controller
    {
        //
        // GET: /AdminExamAction/

        public ActionResult Index()
        {
            return PartialView("_Index", AdminExamModel.ViewExam().ToList());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Result(AdminExamAddAction model)
        {
            AdminExamModel.AddExam(model);
            //ViewBag.Message = s;
            return View();
        }

    }
}
