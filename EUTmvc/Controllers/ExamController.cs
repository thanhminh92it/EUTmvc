using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Models;
using EUTmvc.Models.Home;
using EUTmvc.Utils;

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
        public ActionResult BanDamKhong()
        {
            Session["Account"] = "vanha";
            var model = new FormInfo(4);
            return View(model);
        }

        [HttpPost]
        public ActionResult BanDamKhong(FormInfo model)
        {
            model.Account = Session["Account"].ToString();
            var exam = new ExamModel();
            var examQuestionId = exam.Begin(model);
            Session["examQuestionId"] = examQuestionId.ToString();
            return RedirectToAction("Papers");
        }

        public ActionResult Papers()
        {
            //var examQuestionId = (string)Session["examQuestionId"];
            var examQuestionId = "1";
            var papers = new Papers();
            if (examQuestionId != null)
            {
                papers = ExamModel.LoadPapers(1);
            }
            return View(papers);
        }
        public JsonResult GetJsonData(int id)
        {
            var model = new Category();
            var list = model.Categories(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public string Test()
        {
            //var examQuestionId = (string)Session["examQuestionId"];
            //if (examQuestionId != null)
            //{
            //    return examQuestionId;
            //}
            var db = new EUTContext();
            var s = "21";
            var q = db.tblQuestions.Find(int.Parse(s));
            if (q != null)
            {
                return q.Answer;
            }
            return "null";
        }
    }
}
