using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Models.Home;

namespace EUTmvc.Controllers
{
    public class ExamController : Controller
    {
        //
        // GET: /Exam/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExamEnglish()
        {
            return View(ExamStart.LoadExam(1));
        }
        public ActionResult ExamResult(Exam model)
        {
            return View(model);
        }
        public ActionResult ExamAnswer()
        {
            return View();
        }
    }
}
