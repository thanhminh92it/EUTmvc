using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Models.Admin;

namespace EUTmvc.Controllers.Admin
{
    public class AdminNewsActionController : Controller
    {
        //
        // GET: /AdminNewsAction/

        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý tin tức";
            return PartialView("Index", AdminNewsModel.ViewNews().ToList());
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Sửa tin tức";
            return View(AdminNewsModel.EditViewNews(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(AdminNewsEditAction model)
        {
            if (ModelState.IsValid)
            {
                AdminNewsModel.EditSaveNews(model);
                return RedirectToAction("News", "Admin");
                string url = Url.Action("Index", "AdminPersonAction");
                return Json(new { success = true, url = url });
            }
            return View(model);

        }

        public ActionResult New()
        {
            ViewBag.Title = "Thêm tin tức";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult New(AdminNewsNewAction model)
        {
            if (ModelState.IsValid)
            {
                AdminNewsModel.NewNews(model);
                return RedirectToAction("News", "Admin");
                string url = Url.Action("Index", "AdminPersonAction");
                return Json(new { success = true, url = url });
            }
            return View(model);

        }

        public ActionResult Delete(int id)
        {
            AdminNewsModel.DeleteNews(id);
            return RedirectToAction("News", "Admin");
        }

    }
}
