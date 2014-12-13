using System.Web.Mvc;
using EUTmvc.Models;

namespace EUTmvc.Controllers
{
    public class ExamController : Controller
    {
        //
        // GET: /Thi/
        public ActionResult Index()
        {
            var account = (string)Session["Account"];
            int k = AccountModel.CheckStatusAccount(account);
            if (k != 1)
            {
                return RedirectToAction("Login", "Account");
            }
            var subtests = new Subtests();
            return View(subtests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Subtests subtests)
        {
            if (ModelState.IsValid)
            {
                var account = (string)Session["Account"];
                int k = AccountModel.CheckStatusAccount(account);
                if (k != 1)
                {
                    return RedirectToAction("Login", "Account");
                }
                Session["TestResultID"] = null;
                Session["TestResultID"] = Models.Exam.BeginExam(subtests.SelectSubtests, account);
                return RedirectToAction("Exam", "Exam");
            }
            return View(subtests);
        }
        public JsonResult GetJsonData(int id)
        {
            var model = new Category();
            var list = model.Categories(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Learn()
        {
            var model = new Learn();
            return View(model);
        }
        public ActionResult Learning(Learn learn)
        {
            var model = Models.Learning.LoadEvaluation(learn);
            return View(model);
        }

        public ViewResult LearnResult(Evaluation eval)
        {
            var model = Models.Learning.LearnResult(eval);
            return View(model);
        }
        public ActionResult Exam()
        {
            var account = (string)Session["Account"];
            int k = AccountModel.CheckStatusAccount(account);
            if (k != 1)
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["TestResultID"] == null)
            {
                return RedirectToAction("Index", "Exam");
            }
            var id = (int)Session["TestResultID"];
            Session["TestResultID"] = null;
            //var exam = new Exam();
            if (id == 0)
            {
                ViewBag.Message =
                    "Xin lỗi, môn thi này chưa có đề thi.<div>Hệ thống sẽ cập nhật trong thời gian sớm nhất!</div>";
            }
            Evaluation evaluation = Models.Exam.LoadEvaluation(id, account);
            return View(evaluation);
        }

        public ActionResult TestResult(Evaluation model)
        {
            var account = (string)Session["Account"];
            int k = AccountModel.CheckStatusAccount(account);
            if (k != 1)
            {
                return RedirectToAction("Login", "Account");
            }
            model.Account = account;
            ViewBag.Id = model.ID;
            ViewBag.kq = Models.Exam.Grading(model);
            return View();
        }

        public ActionResult ViewTestResult(int id)
        {
            var account = (string)Session["Account"];
            int k = AccountModel.CheckStatusAccount(account);
            if (k != 1)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = Models.Exam.ViewTestResult(id, account);
            return View(model);
        }
    }
}
